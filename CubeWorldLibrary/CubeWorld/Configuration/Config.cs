using CubeWorld.Tiles;
using CubeWorld.Items;
using CubeWorld.Avatars;
using CubeWorld.Gameplay;

namespace CubeWorld.Configuration
{
    public class Config
    {
        public ConfigWorldSize worldSize;
        public ConfigDayInfo dayInfo;
        public ConfigWorldGenerator worldGenerator;

        public TileDefinition[] tileDefinitions;
		public ItemDefinition[] itemDefinitions;
		public AvatarDefinition[] avatarDefinitions;

        public ConfigExtraMaterials extraMaterials;

        public GameplayDefinition gameplay;
    }
}
