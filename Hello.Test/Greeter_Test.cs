using Greeter;
using HelloProto;
using System;
using Xunit;

namespace Hello.Test
{
    public class Greeter_Test
    {
        private readonly GreeterImpl _greeterImpl;

        public Greeter_Test()
        {
            _greeterImpl = new GreeterImpl();
        }

        [Theory]
        [InlineData("Alex")]
        [InlineData("Wang")]
        public void SayHello_ReturnAddHelloBeforeName(string name)
        {
            var request = new HelloRequest
            {
                Name = name
            };

            var actual = _greeterImpl.SayHello(request, null).Result;

            Assert.Equal($"Hello {name}", actual.Message);
        }
    }
}
