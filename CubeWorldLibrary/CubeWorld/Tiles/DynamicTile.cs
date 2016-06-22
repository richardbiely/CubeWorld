using CubeWorld.World.Objects;

namespace CubeWorld.Tiles
{
	public class DynamicTile : CWObject
	{
		public TileDefinition tileDefinition;
		public TilePosition tilePosition;

        /*
         *  Dynamic tile timeout in ticks, NEVER modify this value directly,
         *  always use TileManager.SetTileDynamicTimeout()
         */
        public int timeout;

	    private readonly bool onFire;
		private readonly bool castShadow;
		private readonly bool lightSource;
		private readonly bool enqueued;
		private readonly byte ambientLuminance;
		private readonly byte lightSourceLuminance;
		private readonly bool dynamic;
        private readonly byte extraData;

	    public bool IsProxy { get; }

	    public bool OnFire
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).OnFire;
				else
					return onFire;
			}
		}
		
		public bool CastShadow
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).CastShadow;
				else
					return castShadow;
			}
		}
		
		public bool LightSource
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).LightSource;
				else
					return lightSource;
			}
		}
		
		public bool Enqueued
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).Enqueued;
				else
					return enqueued;
			}
		}


        public byte ExtraData
        {
            get
            {
                if (IsProxy)
                    return world.tileManager.GetTile(tilePosition).ExtraData;
                else
                    return extraData;
            }
        }
		
		public byte AmbientLuminance
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).AmbientLuminance;
				else
					return ambientLuminance;
			}
		}
		
		public byte LightSourceLuminance
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).LightSourceLuminance;
				else
					return lightSourceLuminance;
			}
		}
		
		public byte Energy
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).Energy;
				else
					return energy;
			}
		}
		
		public bool Destroyed
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).Destroyed;
				else
					return destroyed;
			}
		}
		
		public bool Dynamic
		{
			get 
			{ 
				if (IsProxy) 
					return world.tileManager.GetTile(tilePosition).Dynamic;
				else
					return dynamic;
			}
		}

        public bool Invalidated { get; set; }

	    public DynamicTile(World.CubeWorld world, TileDefinition tileDefinition, int objectId)
            : base(objectId)
		{
			this.world = world;
			definition = tileDefinition;
			this.tileDefinition = tileDefinition;
			
			onFire = false;
			castShadow = tileDefinition.castShadow;
			lightSource = tileDefinition.lightSourceIntensity > 0;
			enqueued = false;
			ambientLuminance = 0;
			lightSourceLuminance = tileDefinition.lightSourceIntensity;
			energy = (byte) tileDefinition.energy;
			destroyed = false;
			dynamic = true;
            extraData = 0;
		}

        public DynamicTile(World.CubeWorld world, TilePosition tilePosition, bool proxy, int objectId)
            : base(objectId)
		{
			this.world = world;
			this.tilePosition = tilePosition;
			position = Utils.Graphics.TilePositionToVector3(tilePosition);
			IsProxy = proxy;
			
			Tile tile = world.tileManager.GetTile(tilePosition);
			
			tileDefinition = world.tileManager.GetTileDefinition(tile.tileType);
			definition = tileDefinition;
			
			if (proxy == false)
			{
				onFire = tile.OnFire;
				castShadow = tile.CastShadow;
				lightSource = tile.LightSource;
				enqueued = tile.Enqueued;
				ambientLuminance = tile.AmbientLuminance;
				lightSourceLuminance = tile.LightSourceLuminance;
				energy = tile.Energy;
				destroyed = tile.Destroyed;
				dynamic = tile.Dynamic;
                extraData = tile.ExtraData;
			}
		}
		
		public Tile ToTile()
		{
			Tile tile = new Tile();
			
			tile.tileType = tileDefinition.tileType;
			tile.OnFire = OnFire;
			tile.CastShadow = CastShadow;
			tile.LightSource = LightSource;
			tile.Enqueued = Enqueued;
			tile.AmbientLuminance = AmbientLuminance;
			tile.LightSourceLuminance = LightSourceLuminance;
			tile.Energy = Energy;
			tile.Destroyed = Destroyed;
			tile.Dynamic = Dynamic;
            tile.ExtraData = extraData;
			
			return tile;
		}

        private bool insideUpdate;
        private bool makeStatic = false;

        public void MakeStatic()
        {
            if (insideUpdate)
                makeStatic = true;
            else
                world.tileManager.SetTileDynamic(tilePosition, false, false, 0);
        }

        public override void Update(float deltaTime)
        {
            insideUpdate = true;

            base.Update(deltaTime);

            insideUpdate = false;

            if (makeStatic)
                MakeStatic();
        }

        public void Invalidate()
        {
            Invalidated = true;
        }
    }
}
