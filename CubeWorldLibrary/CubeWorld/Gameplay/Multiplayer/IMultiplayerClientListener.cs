namespace CubeWorld.Gameplay.Multiplayer
{
    public interface IMultiplayerClientListener
    {
        void ClientActionReceived(MultiplayerClient client, MultiplayerAction action);
    }
}
