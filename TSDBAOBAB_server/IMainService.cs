using MagicOnion;

namespace TSDBAOBAB_server {
    public interface IMainService : IService<IMainService> {
        // Return type must be `UnaryResult<T>` or `Task<UnaryResult<T>>`.
        // If you can use C# 7.0 or newer, recommend to use `UnaryResult<T>`.
        UnaryResult<int> SumAsync(int x, int y);
    }
}
