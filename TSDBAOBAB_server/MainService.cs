using MagicOnion;
using MagicOnion.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TSDBAOBAB_server {
    public class MainService : ServiceBase<IMainService>, IMainService {
        Dictionary<string, TaskCompletionSource<Guid>> MatchMaker = new Dictionary<string, TaskCompletionSource<Guid>>();
        public async UnaryResult<Guid> MatchMake(string pass) {
            Guid guid;
            if (MatchMaker.ContainsKey(pass)) {
                guid = Guid.NewGuid();
                MatchMaker[pass].SetResult(guid);
                MatchMaker.Remove(pass);
            }
            else {
                TaskCompletionSource<Guid> tcs = new TaskCompletionSource<Guid>();
                MatchMaker.Add(pass, tcs);
                guid = await tcs.Task;
            }
            return guid;
        }

        public UnaryResult<Guid> StopMatchMake() {
            throw new NotImplementedException();
        }

        public async UnaryResult<Guid> Test() {
            return Guid.NewGuid();
        }
    }
}
