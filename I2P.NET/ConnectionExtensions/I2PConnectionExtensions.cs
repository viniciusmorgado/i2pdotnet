using I2P.NET.SAM.Events;
using I2P.NET.SAM.Interfaces;

namespace I2P.NET.Demo.ConnectionExtensions;

public static class I2PConnectionExtensions
{
    public static void Session2OnIncomingConnection(IBaseSession sender, AcceptConnectionEventArgs e)
    {
        var reader = new BinaryReader(e.Client.GetStream());
        while (true)
            Console.WriteLine(">> Received: " + reader.ReadString());
    }
}
