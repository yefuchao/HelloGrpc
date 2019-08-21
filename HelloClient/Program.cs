using Grpc.Core;
using System;

namespace HelloClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50001", ChannelCredentials.Insecure);

            var client = new Greeter.Greeter.GreeterClient(channel);

            string user = "Alex";

            var reply = client.SayHello(new Greeter.HelloRequest { Name = user });

            Console.WriteLine("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
