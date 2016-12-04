namespace AutomaticGameLevelGeneration.Configuration
{
    public class LevelConfig
    {
        public int LevelWidth { get; set; }

        //TODO - should we invest here?
        public int MarioMaxJump { get; set; }

        public SparsenessConfiguration BlockConfig { get; set; }
        public SparsenessConfiguration CoinsConfig { get; set; }
        public SparsenessConfiguration EnemyConfig { get; set; }
        public EntropyConfiguration GroundConfig { get; set; }

        public static LevelConfig GetDefault()
        {
            var config = new LevelConfig()
            {
                LevelWidth = 200,
                MarioMaxJump = 4,
                BlockConfig = new SparsenessConfiguration()
                {
                    DesiredSparseness = 1,
                    MaxValue = 3,
                    SparsenessParts = 10
                },
                CoinsConfig = new SparsenessConfiguration()
                {
                    DesiredSparseness = (float)0.5,
                    MaxValue = 2,
                    SparsenessParts = 10
                },
                EnemyConfig = new SparsenessConfiguration()
                {
                    DesiredSparseness = 0,
                    MaxValue = 2,
                    SparsenessParts = 20
                },
                GroundConfig = new EntropyConfiguration()
                {
                    DesiredEntropy = 0,
                    MaximumValue = 2,
                    EntropyParts = 200,
                }
            };

            return config;
        }
    }
}