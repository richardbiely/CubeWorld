using CubeWorld.Tiles;

namespace CubeWorld.Sectors
{
    public class Sector
    {
        public TilePosition sectorPosition;

        public World.CubeWorld world;

        public TilePosition tileOffset;

        private ISectorGraphics sectorGraphics;

        public bool insideInvalidateSectorQueue;
        public bool insideInvalidateLightQueue;
		
        public override int GetHashCode()
        {
            return sectorPosition.GetHashCode();
        }

        public Sector(World.CubeWorld world, TilePosition sectorPosition, TilePosition tileOffset)
        {
            this.world = world;
            this.tileOffset = tileOffset;
            this.sectorPosition = sectorPosition;
        }
		
		public void SetSectorGraphics(ISectorGraphics graphics)
		{
			if (sectorGraphics != null)
				sectorGraphics.SetSector(null);
			
			sectorGraphics = graphics;
			
			if (sectorGraphics != null)
				sectorGraphics.SetSector(this);
		}
		
		public ISectorGraphics GetSectorGraphics()
		{
			return sectorGraphics;
		}

        public void UpdateMesh()
        {
            if (sectorGraphics != null)
                sectorGraphics.UpdateMesh();
        }

        public void UpdateAmbientLight()
        {
            if (sectorGraphics != null)
                sectorGraphics.UpdateAmbientLight();
        }

        public void Clear()
        {
            world = null;
            sectorGraphics = null;
        }
    }
}