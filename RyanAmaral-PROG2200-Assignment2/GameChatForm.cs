using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLib;
using System.Threading;
//using LogLib;
using AsynchronousNetworkClientLogingLIb;
using Microsoft.Practices.Unity;

namespace RyanAmaral_PROG2200_Assignment2
{
    public partial class GameChatForm : Form
    {
        ChatClient _client; // the client
        Thread _connectionThread; // thread for con and discon
        Thread _listeningThread; // thread for listening loop for messages
        Thread _sendMessageThread; // thread for sending a message

        /// <summary>
        /// Initializes the form.
        /// </summary>
        public GameChatForm(ILoggingService logger)
        {
            _client = new ChatClient(logger);
            InitializeComponent();
            
            // set the event listeners
            _client.MessageReceived += new MessageReceivedHandler(NewMessage);
            _client.MessageSentFailure += new MessageSentFailureHandler(MessageSendFail);
            _client.MessageSentSuccess += new MessageSentSuccessHandler(NewMessage);
            _client.ConnectToServerFailure += new ConnectToServerFailureHandler(ConnectFail);
            _client.ConnectToServerSuccess += new ConnectToServerSuccessHandler(ConnectSuccess);
            _client.DisconnectFromServerFailure += new DisconnectFromServerFailureHandler(DisconnectFailure);
            _client.DisconnectFromServerSuccess += new DisconnectFromServerSuccessHandler(DisconnectSuccess);
        }

        /// <summary>
        /// Tell user that we successfully Disconnected from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectSuccess(object sender, DisconnectFromServerSuccessEventArgs e)
        {
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText("Disconnected from server." + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText("Disconnected from server." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Tell user that we are unable to Disconnect from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectFailure(object sender, DisconnectFromServerFailureEventArgs e)
        {
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText("Something went wrong with disconnecting." + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText("Something went wrong with disconnecting." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Tell user that we connected to a server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectSuccess(object sender, ConnectToServerSuccessEventArgs e)
        {
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText("Connected to server!" + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText("Connected to server!" + Environment.NewLine);
            }

            // start the listening thread
            _listeningThread = new Thread(_client.ListenForMessages);
            _listeningThread.Name = "Listening Thread";
            _listeningThread.Start();
        }

        /// <summary>
        /// Tell user that we are unable to connect to a server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectFail(object sender, ConnectToServerFailureEventArgs e)
        {
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText("Unable to connect to a server." + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText("Unable to connect to a server." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Tell user that the message failed to be sent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageSendFail(object sender, MessageSentFailureEventArgs e)
        {
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText("Unable to send message." + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText("Unable to send message." + Environment.NewLine);
            }
        }

        /// <summary>
        /// Puts the new message from the server in the conversation box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMessage(object sender, MessageReceivedEventArgs e)
        {
            DisplayNewMessage(e.Message, false); // display the message
        }

        /// <summary>
        /// Puts the new sent message in the conversation box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewMessage(object sender, MessageSentSuccessEventArgs e)
        {
            DisplayNewMessage(e.Message, true); // display the message
        }

        /// <summary>
        /// Adds the new message to the conversation box.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isMe"></param>
        public void DisplayNewMessage(string message, bool isMe)
        {
            // add chevrons if sent from client
            message = (isMe) ? ">> " + message : message;
            if (textBoxConversation.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(
                        delegate
                        {
                            textBoxConversation.AppendText(message + Environment.NewLine);
                        }
                    );
                textBoxConversation.BeginInvoke(invoker);
            }
            else
            {
                textBoxConversation.AppendText(message + Environment.NewLine);
            }
        }

        private void GameChatForm_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Tries to connect to a server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_client.IsConnected) {
                // help from: http://stackoverflow.com/questions/14854878/creating-new-thread-with-method-with-parameter
                _connectionThread = new Thread(() => _client.ConnectToServer());
                _connectionThread.Name = "Connection Thread";
                _connectionThread.Start();
            }
        }

        /// <summary>
        /// Tries to disconnect from the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _connectionThread = new Thread(() => _client.DisconnectFromServer());
            _connectionThread.Name = "Connection Thread";
            _connectionThread.Start();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Send a message to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        /// <summary>
        /// Send the message if applicable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                SendMessage();
            }
        }

        /// <summary>
        /// Send a message that is in the message box if it is not empty.
        /// </summary>
        private void SendMessage()
        {
            // don't send if message is empty
            if (textBoxMessage.Text != "")
            {
                string message = textBoxMessage.Text;
                _sendMessageThread = new Thread(() => _client.SendMessage(message));
                _sendMessageThread.Name = "Send Message Thread";
                _sendMessageThread.Start();
                textBoxMessage.Text = "";
            }
        }

        /// <summary>
        /// Stop all other threads when form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // safely shut down threads

            if (_listeningThread != null && _listeningThread.IsAlive)
            {
                // stop listening
                _client.StopListening();
                _listeningThread.Join();
            }

            if(_connectionThread != null && _connectionThread.IsAlive)
            {
                // nothing but wait for timeout
                _connectionThread.Join();
            }

            if(_sendMessageThread != null && _sendMessageThread.IsAlive)
            {
                // nothing but wait for timeout
                _connectionThread.Join();
            }
        }

        /// <summary>
        /// Close the form. Goes to form close method for safe shutdown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
