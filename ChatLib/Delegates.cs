namespace ChatLib
{
    /// <summary>
    /// Handler for event that fires when the client receives a message.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MessageReceivedHandler(object sender, MessageReceivedEventArgs e);

    /// <summary>
    /// Handler for event that fires when the client fails to send a message.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MessageSentFailureHandler(object sender, MessageSentFailureEventArgs e);

    /// <summary>
    /// Handler for event that fires when the client successfully sends a message to the server.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MessageSentSuccessHandler(object sender, MessageSentSuccessEventArgs e);

    /// <summary>
    /// Handler for event that fires when the client fails to connect to the server.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ConnectToServerFailureHandler(object sender, ConnectToServerFailureEventArgs e);

    /// <summary>
    /// Handler for event that fires when the client successfully connects to the server.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ConnectToServerSuccessHandler(object sender, ConnectToServerSuccessEventArgs e);

    /// <summary>
    /// Handler for event that fires when client fails to disconnect from the server.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DisconnectFromServerFailureHandler(object sender, DisconnectFromServerFailureEventArgs e);

    /// <summary>
    /// Handler for event that fires when the client successfully disconnects from the server.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DisconnectFromServerSuccessHandler(object sender, DisconnectFromServerSuccessEventArgs e);
}
