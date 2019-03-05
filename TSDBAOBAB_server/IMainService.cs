using MagicOnion;
using System;

namespace TSDBAOBAB_server {
    public interface IMainService : IService<IMainService> {
        UnaryResult<Guid> MatchMake(string pass);
        UnaryResult<Guid> Test();
        UnaryResult<Guid> StopMatchMake();
    }
}
