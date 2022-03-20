using I2P.NET.SAM.Exceptions;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace I2P.NET.SAM.Connection
{
    internal class I2PSamConnection : IDisposable
    {
        private readonly int samPort;
        private TcpClient client;
        private StreamReader reader;
        private BinaryWriter writer;

        public I2PSamConnection(int samPort)
        {
            this.samPort = samPort;
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public NetworkStream GetStream() => client.GetStream();

        public async Task Connect()
        {
            client = new TcpClient();
            await client.ConnectAsync(IPAddress.Loopback, samPort);

            var stream = client.GetStream();

            writer = new BinaryWriter(stream);
            reader = new StreamReader(stream);

            await SendCommand("HELLO VERSION");
        }

        public Task<IDictionary<string, string>> SendCommand(string command)
        {
            Console.WriteLine("> " + command);

            writer.Write(Encoding.UTF8.GetBytes(command + "\n"));

            return Task.Run(() =>
            {
                var responseLine = reader.ReadLine();

                Console.WriteLine(responseLine);

                var response = responseLine.Split(' ');
                var responseDict = response.Skip(2)
                                            .Select(x => x.Split('='))
                                            .ToDictionary(x => x[0], x => x.Length < 2 ? x[0] : x[1]);

                responseDict["COMMAND"] = response[0];
                responseDict["METHOD"] = response[1];

                var result = responseDict["RESULT"];

                if (result != "OK")
                    throw new I2PException("Failed response to: " + command, result, responseLine);

                return (IDictionary<string, string>)responseDict;
            });
        }
    }
}