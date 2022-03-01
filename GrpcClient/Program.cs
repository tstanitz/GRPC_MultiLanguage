using Grpc.Core;
using GrpcDefinition;
using System;
using System.Threading.Tasks;
using static GrpcDefinition.SalutationServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50050", ChannelCredentials.Insecure);

            var client = new SalutationServerClient(channel);

            var reply = await client.SaluteAsync(new SampleRequest { Name = "dotnet client" });

            Console.WriteLine(reply.Salutation);

            await channel.ShutdownAsync();
        }
    }
}
