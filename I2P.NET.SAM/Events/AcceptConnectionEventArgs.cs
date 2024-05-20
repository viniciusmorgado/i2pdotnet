using System.Net.Sockets;

namespace I2P.NET.SAM.Events;

public class AcceptConnectionEventArgs(TcpClient client, string remoteDestination) : EventArgs
{
    public TcpClient Client { get; } = client;
    public string RemoteDestination { get; } = remoteDestination;
}
