using Grpc.Core;
using MagicOnion.Server;
using MagicOnion.Server.Hubs;
using MessagePack;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace TSDBAOBAB_server {
    class Program {
        static void Main(string[] args) {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());

            // setup MagicOnion and option.
            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            var server = new Server {
                Services = { service },
                Ports = { new ServerPort("localhost", 12345, ServerCredentials.Insecure) }
            };

            // launch gRPC Server.
            server.Start();

            Task.Factory.StartNew(async () => {

            });

            // and wait.
            Console.ReadLine();
        }
    }
    [MessagePackObject]
    public class Player {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public Vector3 Position { get; set; }
        [Key(2)]
        public Quaternion Rotation { get; set; }
    }
    public class MainHub : StreamingHubBase<IMainHub, IMainHubReceiver>, IMainHub{
        IGroup room;
        IInMemoryStorage<Player> storage;
        public async Task MatchMake(string pass) {
            (room, storage) = await Group.AddAsync(pass, new Player());
            
        }
    }
}
