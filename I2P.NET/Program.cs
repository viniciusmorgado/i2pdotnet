
using I2P.NET.Demo.ConnectionExtensions;
using I2P.NET.SAM.Sessions;

Console.WriteLine("Starting first session ...");

var firstSession = new I2PSession(samPort: 7656);
firstSession.InitializeAsync().Wait();

Console.WriteLine("Looking up stats.i2p");
Console.WriteLine(firstSession.NameLookupAsync("stats.i2p").Result);

Console.WriteLine("Starting second session ...");

var secondSession = new I2PSession(7656, listenPort: 5001);
secondSession.InitializeAsync().Wait();

secondSession.IncomingConnection += I2PConnectionExtensions.Session2OnIncomingConnection;

Console.WriteLine("Setting up listening on session two");
secondSession.ListenForIncomingConnectionsAsync().Wait();

Task.Delay(1000).Wait();

Console.WriteLine("Connecting from session one to session two ...");

var stream = firstSession.ConnectAsync(secondSession.LocalDestination).Result;
var writer = new BinaryWriter(stream);
writer.Write("Testing ...\n");

Task.Delay(1000).Wait();

while (true)
{
    Console.Write("# ");
    string message = Console.ReadLine();
    if (message == null)
        return;
    writer.Write(message);
}
