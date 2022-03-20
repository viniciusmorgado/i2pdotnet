using System.Net.Sockets;

namespace I2P.NET.SAM.Events
{
    public class AcceptConnectionEventArgs : EventArgs
    {
        public TcpClient Client { get; }
        public string RemoteDestination { get; }
        public AcceptConnectionEventArgs(TcpClient client, string remoteDestination)
        {
            Client = client;
            RemoteDestination = remoteDestination;
        }
    }
}