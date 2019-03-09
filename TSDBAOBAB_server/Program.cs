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
                Ports = { new ServerPort("0.0.0.0", 12345, ServerCredentials.Insecure) }
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
        public enum Char {
            BG72,
            SG27,
        }
        [Key(0)]
        public Vector3 Position { get; set; }
        [Key(1)]
        public Quaternion Rotation { get; set; }
        [Key(2)]
        public Char Character { get; set; }
        [Key(3)]
        public int Id { get; set; }
    }
    public class MainHub : StreamingHubBase<IMainHub, IMainHubReceiver>, IMainHub {
        IGroup room = null;
        Player self;
        IInMemoryStorage<Player> storage = null;
        public async Task MatchMake(string pass) {
            self = new Player {
                Id = storage == null ? 0 : storage.AllValues.Count,
                Position = new Vector3(0, 0, 0),
                Rotation = new Quaternion(0, 0, 0, 0),
                Character = Player.Char.BG72,
            };
            Console.WriteLine("hello there");
            (room, storage) = await Group.AddAsync(pass, self);
            Broadcast(room).Log("there are: " + storage.AllValues.Count + " players");

        }
    }
}
