using System;

namespace ChatLib
{
    /// <summary>
    /// Event for when a message is sent to server without error.
    /// </summary>
    public class MessageSentSuccessEventArgs : EventArgs
    {
        private string _message;
        /// <summary>
        /// Gets the message that was sent.
        /// </summary>
        public string Message { get { return _message; } }

        /// <summary>
        /// Constructor for inputting message.
        /// </summary>
        /// <param name="message"></param>
        public MessageSentSuccessEventArgs(string message)
        {
            _message = message;
        }
    }
}