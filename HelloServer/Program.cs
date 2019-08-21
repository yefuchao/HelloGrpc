using System;
using HelloProto;
using Grpc.Core;

namespace HelloServer
{
    class Program
    {
        const int port = 50001;

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.Greeter.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("Greeter server listening on port " + port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
