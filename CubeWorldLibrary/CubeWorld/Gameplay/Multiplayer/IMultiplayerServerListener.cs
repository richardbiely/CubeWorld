namespace CubeWorld.Gameplay.Multiplayer
{
    public interface IMultiplayerServerListener
    {
        void ClientConnected(MultiplayerClient client);
        void ClientDisconnected(MultiplayerClient client);
    }
}
