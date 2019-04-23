using MagicOnion;
using System.Threading.Tasks;

namespace TSDBAOBAB_server {
    public interface IMainHub : IStreamingHub<IMainHub, IMainHubReceiver> {
        Task<PlayerNetworkObject> MatchMake(string pass);
        void PlayerStateUpdate(PlayerNetworkObject player);
        void SlaveStateUpdate(int keycode);
        void MasterStateUpdate(GameObject[] objects);
    }
}
