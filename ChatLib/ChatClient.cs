using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
//using LogLib;
using AsynchronousNetworkClientLogingLIb;

namespace ChatLib
{
    /// <summary>
    /// The client object that is used to connect to server, and send and receive messages.
    /// </summary>
    public class ChatClient
    {
        private bool _doListen; // flag for listening or not

        private TcpClient _client; // the network client
        private NetworkStream _stream; // the stream of data between this and server

        // default values for connectivity
        private const string DEF_ADDRESS = "127.0.0.1";
        private const int DEF_PORT = 13000;

        // tells whether the client is connected
        private bool _isConnected;
        /// <summary>
        /// Get if the client is currently connected.
        /// </summary>
        public bool IsConnected { get { return _isConnected; } }

        // logger object
        private ILoggingService _logger;

        // for events

        /// <summary>
        /// Fires when the client receives a message.
        /// </summary>
        public event MessageReceivedHandler MessageReceived;

        /// <summary>
        /// Fires when the client fails to send a message.
        /// </summary>
        public event MessageSentFailureHandler MessageSentFailure;

        /// <summary>
        /// Fires when the client successfully sends a message to the server.
        /// </summary>
        public event MessageSentSuccessHandler MessageSentSuccess;

        /// <summary>
        /// Fires when the client fails to connect to the server.
        /// </summary>
        public event ConnectToServerFailureHandler ConnectToServerFailure;

        /// <summary>
        /// Fires when the client successfully connects to the server.
        /// </summary>
        public event ConnectToServerSuccessHandler ConnectToServerSuccess;

        /// <summary>
        /// Fires when client fails to disconnect from the server.
        /// </summary>
        public event DisconnectFromServerFailureHandler DisconnectFromServerFailure;

        /// <summary>
        /// Fires when the client successfully disconnects from the server.
        /// </summary>
        public event DisconnectFromServerSuccessHandler DisconnectFromServerSuccess;

        /// <summary>
        /// Constructor to create client with logger.
        /// </summary>
        /// <param name="logger"></param>
        public ChatClient(ILoggingService logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Sends a message through this object's network stream.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            if (_isConnected)
            {
                try
                {
                    // convert the message to bytes to send accross network
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    _stream.Write(data, 0, data.Length);
                    // fire message send success event
                    if (MessageSentSuccess != null)
                    {
                        MessageSentSuccess(this, new MessageSentSuccessEventArgs(message));
                    }
                    _logger.Log(DateTime.Now.Day + "/" + DateTime.Now.Month +
                        "/" + DateTime.Now.Year + " " + DateTime.Now.TimeOfDay + 
                        " - Client: " + message);
                }
                catch (ArgumentNullException e)
                {
                    // fire message send failure event
                    if(MessageSentFailure != null)
                    {
                        MessageSentFailure(this, new MessageSentFailureEventArgs());
                    }   
                }
                catch (SocketException e)
                {
                    // fire message send failure event
                    if (MessageSentFailure != null)
                    {
                        MessageSentFailure(this, new MessageSentFailureEventArgs());
                    }
                }
                catch (IOException e)
                {
                    // fire message send failure event
                    if (MessageSentFailure != null)
                    {
                        MessageSentFailure(this, new MessageSentFailureEventArgs());
                    }
                }
            }
            else
            {
                // fire message send failure
                if (MessageSentFailure != null)
                {
                    MessageSentFailure(this, new MessageSentFailureEventArgs());
                }
            }
        }

        /// <summary>
        /// Makes the client start listening for objects comming in from the stream.
        /// </summary>
        public void ListenForMessages()
        {
            if (_isConnected) {
                _doListen = true; // make sure is listening
                                  // repeat listening
                while (_doListen)
                {
                    try
                    {
                        int numBytes; // the amount of bytes that the current message actually is
                        Byte[] bytes = new Byte[256]; // create a 256 byte buffer to receive data

                        // read message if there is one
                        if (_stream.DataAvailable)
                        {
                            // get how many bytes long the message is, and read it into byte array
                            numBytes = _stream.Read(bytes, 0, bytes.Length);
                            // get the message
                            string message = System.Text.Encoding.ASCII.GetString(bytes, 0, numBytes);
                            // fire message received event
                            if (MessageReceived != null)
                            {
                                MessageReceived(this, new MessageReceivedEventArgs(message));
                            }
                            _logger.Log(DateTime.Now.Day + "/" + DateTime.Now.Month +
                                "/" + DateTime.Now.Year + " " + DateTime.Now.TimeOfDay + 
                                " - Server: " + message);
                        }
                    }
                    catch (ArgumentNullException e) { }
                    catch (ArgumentOutOfRangeException e) { }
                    catch (IOException e) { }
                    catch (ObjectDisposedException e) { }
                }
            }
        }

        /// <summary>
        /// If client is listening, make it stop.
        /// </summary>
        public void StopListening()
        {
            _doListen = false;
        }

        /// <summary>
        /// Connect to a server on the specified ip address and port.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        public void ConnectToServer(string ipAddress = DEF_ADDRESS, int port = DEF_PORT)
        {
            try
            {
                // connect to the server and get reference to stream object
                _client = new TcpClient(ipAddress, port);
                _stream = _client.GetStream();
                _isConnected = true;
                // fire connect success event
                if(ConnectToServerSuccess != null)
                {
                    ConnectToServerSuccess(this, new ConnectToServerSuccessEventArgs());
                }
                _logger.Log(DateTime.Now.Day + "/" + DateTime.Now.Month +
                        "/" + DateTime.Now.Year + " " + DateTime.Now.TimeOfDay + 
                        " - Client connected to server at " + ipAddress + " port " + port.ToString());
            }
            catch (ArgumentNullException e)
            {
                _isConnected = false;
                // fire connect failure event
                if(ConnectToServerFailure != null)
                {
                    ConnectToServerFailure(this, new ConnectToServerFailureEventArgs());
                }
            }
            catch (SocketException e)
            {
                _isConnected = false;
                // fire connect failure event
                if (ConnectToServerFailure != null)
                {
                    ConnectToServerFailure(this, new ConnectToServerFailureEventArgs());
                }
            }
        }

        /// <summary>
        /// Disconnects from the server if it is connected.
        /// </summary>
        public void DisconnectFromServer()
        {
            // only disconnect if there is active connection
            if (_isConnected) {
                // stop listening
                if (_doListen)
                {
                    _doListen = false;
                }
                try
                {
                    _stream.Close();
                    _client.Close();
                    _isConnected = false;
                    // fire disconnect success event
                    if (DisconnectFromServerSuccess != null)
                    {
                        DisconnectFromServerSuccess(this, new DisconnectFromServerSuccessEventArgs());
                    }
                    _logger.Log(DateTime.Now.Day + "/" + DateTime.Now.Month +
                        "/" + DateTime.Now.Year + " " + DateTime.Now.TimeOfDay + 
                        " - Client disconnected. Chat session ended.");
                }
                catch (ArgumentNullException e)
                {
                    // fire disconnect failure event
                    if (DisconnectFromServerFailure != null)
                    {
                        DisconnectFromServerFailure(this, new DisconnectFromServerFailureEventArgs());
                    }
                }
                catch (IOException e)
                {
                    // fire disconnect failure event
                    if (DisconnectFromServerFailure != null)
                    {
                        DisconnectFromServerFailure(this, new DisconnectFromServerFailureEventArgs());
                    }
                }
                catch (SocketException e)
                {
                    // fire disconnect failure event
                    if (DisconnectFromServerFailure != null)
                    {
                        DisconnectFromServerFailure(this, new DisconnectFromServerFailureEventArgs());
                    }
                }
            }
        }
    }
}
