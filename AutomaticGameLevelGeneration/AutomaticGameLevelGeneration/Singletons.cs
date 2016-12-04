using System;
using AutomaticGameLevelGeneration.Configuration;

namespace AutomaticGameLevelGeneration
{
    public class Singletons
    {
        private static Random random;

        private Singletons()
        {
            
        }

        public static Random RandomInstance
        {
            get
            {
                if (random == null)
                {
                    random = new Random();
                }

                return random;
            }
        }

        private static LevelConfig config;

        public static LevelConfig Configuration
        {
            get
            {
                if (config == null)
                {
                    config = LevelConfig.GetDefault();
                }

                return config;
            }
        }
    }
}