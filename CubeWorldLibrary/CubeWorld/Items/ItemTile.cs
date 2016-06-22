namespace CubeWorld.Items
{
    public class ItemTile : Item
    {
        public ItemTileDefinition itemTileDefinition;

        public ItemTile(World.CubeWorld world, ItemTileDefinition itemTileDefinition, int objectId)
            : base(world, itemTileDefinition, objectId)
        {
            this.itemTileDefinition = itemTileDefinition;
        }
    }
}
