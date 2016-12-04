using System;

namespace AutomaticGameLevelGeneration
{
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
            child.groundLevel = new int[Singletons.Configuration.LevelWidth];
            child.blockHeight = new int[Singletons.Configuration.LevelWidth];
            child.blockType = new int[Singletons.Configuration.LevelWidth];
            child.coinHeight = new int[Singletons.Configuration.LevelWidth];
            child.enemyType = new int[Singletons.Configuration.LevelWidth];

            this.CopyRange(this.groundLevel, child.groundLevel, 0, crossoverPoint - 1);
            this.CopyRange(this.blockHeight, child.blockHeight, 0, crossoverPoint - 1);
            this.CopyRange(this.blockType, child.blockType, 0, crossoverPoint - 1);
            this.CopyRange(this.coinHeight, child.coinHeight, 0, crossoverPoint - 1);
            this.CopyRange(this.enemyType, child.enemyType, 0, crossoverPoint - 1);

            this.CopyRange(this.groundLevel, child.groundLevel, crossoverPoint, Singletons.Configuration.LevelWidth-1);
            this.CopyRange(this.blockHeight, child.blockHeight, crossoverPoint, Singletons.Configuration.LevelWidth - 1);
            this.CopyRange(this.blockType, child.blockType, crossoverPoint, Singletons.Configuration.LevelWidth - 1);
            this.CopyRange(this.coinHeight, child.coinHeight, crossoverPoint, Singletons.Configuration.LevelWidth - 1);
            this.CopyRange(this.enemyType, child.enemyType, crossoverPoint, Singletons.Configuration.LevelWidth - 1);
            
            return child;
        }

        private void CopyRange(int[] source, int[] destination, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                destination[i] = source[i];
            }
        }

        public static int GetRandomGroundLevel()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.GroundConfig.MaximumValue + 1);
        }

        public static int GetRandomBlockType()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.BlockConfig.MaxValue + 1);
        }

        public static int GetRandomBlockHeight()
        {
            return Singletons.RandomInstance.Next(1, Singletons.Configuration.MarioMaxJump);
        }

        public static int GetRandomEnemyType()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.EnemyConfig.MaxValue);
        }

        public static int GetRandomCoinHeight()
        {
            return Singletons.RandomInstance.Next(Singletons.Configuration.CoinsConfig.MaxValue);
        }

        public Individ Mutate()
        {
            Individ individ = (Individ)this.Clone();

            int indexToMutate = Singletons.RandomInstance.Next(100);

            this.groundLevel[indexToMutate] = GetRandomGroundLevel();
            this.blockHeight[indexToMutate] = GetRandomBlockHeight();
            this.blockType[indexToMutate] = GetRandomCoinHeight();
            this.enemyType[indexToMutate] = GetRandomEnemyType();

            return individ;
        }

        public object Clone()
        {
            Individ individ = new Individ
            {
                groundLevel = CloneArray(this.groundLevel),
                blockHeight = CloneArray(this.blockHeight),
                blockType = CloneArray(this.blockType),
                coinHeight = CloneArray(this.coinHeight),
                enemyType = CloneArray(this.enemyType)
            };

            return individ;
        }

        private int[] CloneArray(int[] source)
        {
            int[] copy = new int[source.Length];
            source.CopyTo(copy, 0);
            return copy;
        }
    }
}