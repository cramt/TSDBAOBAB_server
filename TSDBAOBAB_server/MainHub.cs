﻿using MagicOnion.Server.Hubs;
using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace TSDBAOBAB_server {
    public class MainHub : StreamingHubBase<IMainHub, IMainHubReceiver>, IMainHub {
        IGroup room = null;
        PlayerNetworkObject self;
        IInMemoryStorage<PlayerNetworkObject> storage = null;
        public async Task<PlayerNetworkObject> MatchMake(string pass) {
            self = new PlayerNetworkObject {
                Id = storage == null ? 0 : storage.AllValues.Count,
                Position = new float[] { 0, 0, 0 },
                Rotation = new float[] { 0, 0, 0, 0 },
                Character = storage == null ? Char.BG72 : Char.SG27,
                Velocity = new float[] { 0, 0, 0 }
            };
            if (storage != null)
                if (storage.AllValues.Count > 1) {
                    return null;
                }
            (room, storage) = await Group.AddAsync(pass, self);
            if (storage.AllValues.Count == 2) {
                Broadcast(room).MatchMade(storage.AllValues.ToArray());
            }
            return self;
        }
    }
}
