using System;
using System.Threading.Tasks;
using Greeter;

namespace HelloProto
{
    public class GreeterImpl : Greeter.Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine("Request:" + request.Name);
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }

        public override Task<HelloReply> SayHelloAgain(HelloRequest request, Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine("Request:" + request.Name);
            return Task.FromResult(new HelloReply { Message = "Hello Again " + request.Name });
        }
    }
}