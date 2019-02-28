using MagicOnion;
using MagicOnion.Server;

namespace TSDBAOBAB_server {
    public class MainService : ServiceBase<IMainService>, IMainService {
        // You can use async syntax directly.
        public async UnaryResult<int> SumAsync(int x, int y) {
            Logger.Debug($"Received:{x}, {y}");

            return x + y;
        }
    }
}
