using System;

namespace ChatLib
{
    /// <summary>
    /// Event for when the client receives a message.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        private string _message;
        /// <summary>
        /// Gets the message that was received.
        /// </summary>
        public string Message{get{ return _message;}}

        /// <summary>
        /// Constructor for inputting message.
        /// </summary>
        /// <param name="message"></param>
        public MessageReceivedEventArgs(string message)
        {
            _message = message;
        }
    }
}