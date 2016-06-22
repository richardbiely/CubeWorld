namespace CubeWorld.Gameplay
{
    public class BasicEnemiesGameplay : BaseGameplay
    {
        public BasicEnemiesGameplay() :
            base("basicEnemies")
        {
        }

        public override void WorldCreated()
        {
            base.WorldCreated();
            AddRandomEnemies(40);
        }
    }
}
