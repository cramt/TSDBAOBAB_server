using Grpc.Core;
using MagicOnion.Server;
using MessagePack.Resolvers;
using System;

namespace TSDBAOBAB_server {
    class Program {
        static void Main(string[] args) {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            var server = new Server {
                Services = { service },
                Ports = { new ServerPort("0.0.0.0", 12345, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.ReadLine();
        }
    }
}
