using CubeWorld.World.Objects;
using CubeWorld.Avatars.Components;

namespace CubeWorld.Avatars
{
    public class Avatar : CWObject
    {
        public AvatarInput input;

        public Avatar(World.CubeWorld world, AvatarDefinition avatarDefinition, int objectId)
            : base(objectId)
        {
            this.world = world;
			definition = avatarDefinition;

            input = new AvatarInput();

            AddComponent(new AvatarComponentPhysics());
        }
    }
}
