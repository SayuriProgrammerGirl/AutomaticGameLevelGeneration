using System;

namespace AutomaticGameLevelGeneration
{
    public class Individ
    {
        public int[] groundLevel;

        public int[] blockType;

        public int[] blockHeight;

        public int[] enemyType;

        public int[] coinHeight;

        public float? fitness = null;

        public Individ(int xxx)
        {
            groundLevel = GenerateRandomArray(
                                Singletons.Configuration.LevelWidth,
                                Singletons.Configuration.GroundConfig.MaximumValue);
            blockType = GenerateRandomArray(
                                Singletons.Configuration.LevelWidth,
                                Singletons.Configuration.BlockConfig.MaxValue);
            blockHeight = GenerateRandomArray(
                                Singletons.Configuration.LevelWidth,
                                Singletons.Configuration.MarioMaxJump);
            coinHeight = GenerateRandomArray(
                                Singletons.Configuration.LevelWidth,
                                Singletons.Configuration.CoinsConfig.MaxValue);
            enemyType = GenerateRandomArray(
                                Singletons.Configuration.LevelWidth,
                                Singletons.Configuration.EnemyConfig.MaxValue);
        }

        private int[] GenerateRandomArray(int length, int maxValue)
        {
            var array = new int[length];
            
            for (int i = 0; i < length; i++)
            {
                array[i] = Singletons.RandomInstance.Next(maxValue + 1);
            }

            return array;
        }



        private Individ()
        {

        }

        public Individ Crossover(Individ other, int crossoverPoint)
        {
            var child = new Individ();
            child.groundLevel = new int[this.groundLevel.Length];
            child.blockHeight = new int[this.blockHeight.Length];
            child.blockType = new int[this.blockType.Length];
            child.coinHeight = new int[this.coinHeight.Length];
            child.enemyType = new int[this.enemyType.Length];

            for (int i = 0; i < this.groundLevel.Length; i++)
            {
                if (i < crossoverPoint)
                {
                    child.groundLevel[i] = this.groundLevel[i];
                    child.blockHeight[i] = this.groundLevel[i];
                    child.blockType[i] = this.blockType[i];
                    child.coinHeight[i] = this.coinHeight[i];
                    child.enemyType[i] = this.enemyType[i];
                }
                else
                {
                    child.groundLevel[i] = other.groundLevel[i];
                    child.blockHeight[i] = other.groundLevel[i];
                    child.blockType[i] = other.blockType[i];
                    child.coinHeight[i] = other.coinHeight[i];
                    child.enemyType[i] = other.enemyType[i];
                }
            }

            return child;
        }

        public static int GetRandomGroundLevel()
        {
            return Singletons.RandomInstance.Next(16);
        }

        public static int GetRandomBlockType()
        {
            return Singletons.RandomInstance.Next(5);
        }

        public static int GetRandomBlockHeight()
        {
            return Singletons.RandomInstance.Next(1, 5);
        }

        public static int GetRandomEnemyType()
        {
            return Singletons.RandomInstance.Next(3);
        }

        public static int GetRandomCoinHeight()
        {
            return Singletons.RandomInstance.Next(11);
        }

        public Individ Mutate(Random rnd)
        {
            Individ individ = new Individ();
            individ.groundLevel = new int[this.groundLevel.Length];
            individ.blockHeight = new int[this.blockHeight.Length];
            individ.blockType = new int[this.blockType.Length];
            individ.coinHeight = new int[this.coinHeight.Length];
            individ.enemyType = new int[this.enemyType.Length];

            this.groundLevel.CopyTo(individ.groundLevel, 0);
            this.blockHeight.CopyTo(individ.blockHeight, 0);
            this.blockType.CopyTo(individ.blockType, 0);
            this.coinHeight.CopyTo(individ.coinHeight, 0);
            this.enemyType.CopyTo(individ.enemyType, 0);

            int indexToMutate = rnd.Next(100);
            this.groundLevel[indexToMutate] = GetRandomGroundLevel();
            this.blockHeight[indexToMutate] = GetRandomBlockHeight();
            this.blockType[indexToMutate] = GetRandomCoinHeight();
            this.enemyType[indexToMutate] = GetRandomEnemyType();

            return individ;
        }
    }
}