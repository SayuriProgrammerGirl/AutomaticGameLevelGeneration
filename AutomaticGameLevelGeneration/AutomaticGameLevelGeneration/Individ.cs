namespace AutomaticGameLevelGeneration
{
    using System;
    using AutomaticGameLevelGeneration.Configuration;

    public class ArrayUtil
    {
        public static int[] GenerateRandomArray(LevelConfig cfg, int maxValue)
        {
            var array = new int[cfg.LevelWidth];

            for (int i = 0; i < cfg.LevelWidth; i++)
            {
                array[i] = Singletons.RandomInstance.Next(maxValue + 1);
            }

            return array;
        }

        public static int[] GenerateRandomArray(LevelConfig cfg, FitnessConfiguration config)
        {
            return GenerateRandomArray(cfg, config.MaximumValue);
        }

        public static int[] CloneArray(int[] source)
        {
            int[] copy = new int[source.Length];
            source.CopyTo(copy, 0);
            return copy;
        }

        public static void CopyValuesFromStartIndexToEndIndex(int[] source, int[] destination, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                destination[i] = source[i];
            }
        }
    }
    public class Individ : ICloneable
    {
        public int[] groundLevel;

        public int[] blockType;

        public int[] blockHeight;

        public int[] enemyType;

        public int[] coinHeight;

        public float? fitness = null;

        public Individ(int xxx)
        {
            this.groundLevel = ArrayUtil.GenerateRandomArray(Singletons.Configuration, Singletons.Configuration.GroundConfig);
            this.blockType = ArrayUtil.GenerateRandomArray(Singletons.Configuration, Singletons.Configuration.BlockConfig);
            this.blockHeight = ArrayUtil.GenerateRandomArray(Singletons.Configuration, Singletons.Configuration.MarioMaxJump);
            this.coinHeight = ArrayUtil.GenerateRandomArray(Singletons.Configuration, Singletons.Configuration.CoinsConfig);
            this.enemyType = ArrayUtil.GenerateRandomArray(Singletons.Configuration, Singletons.Configuration.EnemyConfig);
        }

        private Individ()
        {

        }

        public Individ Crossover(Individ other, int crossoverPoint)
        {
            var child = new Individ();
            child.groundLevel = new int[Singletons.Configuration.LevelWidth];
            child.blockHeight = new int[Singletons.Configuration.LevelWidth];
            child.blockType = new int[Singletons.Configuration.LevelWidth];
            child.coinHeight = new int[Singletons.Configuration.LevelWidth];
            child.enemyType = new int[Singletons.Configuration.LevelWidth];

            this.CopyRangeFromSourceToDestination(this,child,0,crossoverPoint-1);
            this.CopyRangeFromSourceToDestination(other,child,crossoverPoint,Singletons.Configuration.LevelWidth - 1);

            return child;
        }

        private void CopyRangeFromSourceToDestination(Individ source, Individ destination, int startIndex, int endIndex)
        {
            ArrayUtil.CopyValuesFromStartIndexToEndIndex(source.groundLevel, destination.groundLevel, startIndex, endIndex);
            ArrayUtil.CopyValuesFromStartIndexToEndIndex(source.blockHeight, destination.blockHeight, startIndex, endIndex);
            ArrayUtil.CopyValuesFromStartIndexToEndIndex(source.blockType, destination.blockType, startIndex, endIndex);
            ArrayUtil.CopyValuesFromStartIndexToEndIndex(source.coinHeight, destination.coinHeight, startIndex, endIndex);
            ArrayUtil.CopyValuesFromStartIndexToEndIndex(source.enemyType, destination.enemyType, startIndex, endIndex);
        }

        public static int GetRandomGroundLevel()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.GroundConfig.MaximumValue + 1);
        }

        public static int GetRandomBlockType()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.BlockConfig.MaximumValue + 1);
        }

        public static int GetRandomBlockHeight()
        {
            return Singletons.RandomInstance.Next(1, Singletons.Configuration.MarioMaxJump);
        }

        public static int GetRandomEnemyType()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.EnemyConfig.MaximumValue);
        }

        public static int GetRandomCoinHeight()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.CoinsConfig.MaximumValue);
        }

        public Individ Mutate()
        {
            Individ individ = (Individ)this.Clone();

            int indexToMutate = Singletons.RandomInstance.Next(100);

            this.groundLevel[indexToMutate] = GetRandomGroundLevel();
            this.blockHeight[indexToMutate] = GetRandomBlockHeight();
            this.blockType[indexToMutate] = GetRandomBlockType();
            this.coinHeight[indexToMutate] = GetRandomCoinHeight();
            this.enemyType[indexToMutate] = GetRandomEnemyType();

            return individ;
        }

        public object Clone()
        {
            Individ individ = new Individ
            {
                groundLevel = ArrayUtil.CloneArray(this.groundLevel),
                blockHeight = ArrayUtil.CloneArray(this.blockHeight),
                blockType = ArrayUtil.CloneArray(this.blockType),
                coinHeight = ArrayUtil.CloneArray(this.coinHeight),
                enemyType = ArrayUtil.CloneArray(this.enemyType)
            };

            return individ;
        }
    }
}