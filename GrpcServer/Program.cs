using System;
using System.Threading.Tasks;
using Grpc.Core;
using static GrpcDefinition.SalutationServer;

namespace GrpcServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new Server
            {
                Ports = { new ServerPort("localhost", 50050, ServerCredentials.Insecure) },
                Services = { BindService(new SalutationServerImpl()) }
            };
            server.Start();
            Console.ReadKey();
            await server.ShutdownAsync();
        }
    }

    public class SalutationServerImpl : SalutationServerBase
    {
        public override Task<SampleResponse> Salute(SampleRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SampleResponse { Salutation = $"Salute {request.Name} from Server" });
        }
    }
}
