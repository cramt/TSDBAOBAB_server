using MagicOnion;
using System.Threading.Tasks;

namespace TSDBAOBAB_server {
    public interface IMainHub : IStreamingHub<IMainHub, IMainHubReceiver> {
        Task MatchMake(string pass);
    }
}
