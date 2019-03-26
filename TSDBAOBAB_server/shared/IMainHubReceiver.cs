namespace TSDBAOBAB_server {
    public interface IMainHubReceiver {
        void Log(string str);
        void MatchMade(PlayerNetworkObject[] players);
        void OnPlayerStateUpdate(PlayerNetworkObject player);
    }
}
