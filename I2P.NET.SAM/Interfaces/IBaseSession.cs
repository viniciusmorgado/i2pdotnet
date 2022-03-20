using I2P.NET.SAM.Events;

namespace I2P.NET.SAM.Interfaces
{
    public delegate void AcceptConnectionDelegate(IBaseSession sender, AcceptConnectionEventArgs e);
    public interface IBaseSession : IDisposable
    {
        event AcceptConnectionDelegate IncomingConnection;
        Task InitializeAsync();
        Task<Stream> ConnectAsync(string remoteDestination);
        Task ListenForIncomingConnectionsAsync();
        void StopListeningForIncomingConnections();
        Task<string> NameLookupAsync(string address);
    }
}