namespace CubeWorld.Gameplay.Multiplayer
{
    public class MultiplayerStats
    {
        private MultiplayerStats()
        {
        }

        private static MultiplayerStats singleton;

        public static MultiplayerStats Singleton
        {
            get { if (singleton == null) singleton = new MultiplayerStats(); return singleton; }
        }

        public bool serverMode;
        public bool connected;
        public int multiplayerConnectedClients = 0;

        public int sentBytes;
        public int receivedBytes;
        public int[] sentActions = new int[(int) MultiplayerAction.Action.LEN];
        public int[] receivedActions = new int[(int)MultiplayerAction.Action.LEN];

        public int multiplayerSentTiles;

        

        public void Reset()
        {
            serverMode = false;
            connected = false;

            receivedBytes = 0;
            sentBytes = 0;
            multiplayerSentTiles = 0;
            multiplayerConnectedClients = 0;

            sentActions.Initialize();
            receivedActions.Initialize();
        }

        public override string ToString()
        {
            return "CC: " + multiplayerConnectedClients +  " ST: " + multiplayerSentTiles;
        }
    }
}
