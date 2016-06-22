namespace CubeWorld.World.Generator
{
    public class GeneratorProcess
    {
        private readonly CubeWorldGenerator generator;
        private readonly CubeWorld world;

        private bool finished = false;

        private readonly int totalCost;

        public GeneratorProcess(CubeWorldGenerator generator, CubeWorld world)
        {
            finished = false;
            this.generator = generator;
            this.world = world;

            generator.Prepare();
            totalCost = generator.GetTotalCost();
        }

        public bool Generate()
        {
            if (finished == false)
                if (generator.Generate(world) == true)
                    finished = true;

            return finished;
        }

        public int GetProgress()
        {
            if (totalCost != 0)
                return generator.GetCurrentCost() * 100 / totalCost;
            else
                return 100;
        }

        public bool IsFinished()
        {
            return finished;
        }

        public override string ToString()
        {
            return generator.ToString();
        }
    }
}
