namespace AutomaticGameLevelGeneration.Configuration
{
    public class LevelConfig
    {
        public int LevelWidth { get; set; }

        //TODO - should we invest here?
        public int MarioMaxJump { get; set; }

        public FitnessConfiguration BlockConfig { get; set; }
        public FitnessConfiguration CoinsConfig { get; set; }
        public FitnessConfiguration EnemyConfig { get; set; }
        public FitnessConfiguration GroundConfig { get; set; }


        public static LevelConfig GetDefault()
        {
            var config = new LevelConfig()
            {
                LevelWidth = 200,
                MarioMaxJump = 4,
                BlockConfig = new FitnessConfiguration()
                {
                    DesiredFitness = 1,
                    MaximumValue = 3,
                    PartsPerBatch = 10
                },
                CoinsConfig = new FitnessConfiguration()
                {
                    DesiredFitness = (float)0.5,
                    MaximumValue = 2,
                    PartsPerBatch = 10
                },
                EnemyConfig = new FitnessConfiguration()
                {
                    DesiredFitness = 0,
                    MaximumValue = 2,
                    PartsPerBatch = 20
                },
                GroundConfig = new FitnessConfiguration()
                {
                    DesiredFitness = 0,
                    MaximumValue = 2,
                    PartsPerBatch = 200,
                }
            };

            return config;
        }
    }
}