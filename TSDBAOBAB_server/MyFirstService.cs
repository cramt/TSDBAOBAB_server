using MagicOnion;
using MagicOnion.Server;

namespace TSDBAOBAB_server {
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService {
        // You can use async syntax directly.
        public async UnaryResult<int> SumAsync(int x, int y) {
            Logger.Debug($"Received:{x}, {y}");

            return x + y;
        }
    }
}
