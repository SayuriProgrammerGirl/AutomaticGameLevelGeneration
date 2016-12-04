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

        public Individ(Random rnd)
        {
            groundLevel = new int[100];
            blockType = new int[100];
            blockHeight = new int[100];
            enemyType = new int[100];
            coinHeight = new int[100];

            for (int i = 0; i < 100; i++)
            {
                groundLevel[i] = GetRandomGroundLevel(rnd);
                blockType[i] = GetRandomBlockType(rnd);
                blockHeight[i] = GetRandomGroundLevel(rnd);
                enemyType[i] = GetRandomEnemyType(rnd);
                coinHeight[i] = GetRandomCoinHeight(rnd);
            }
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

        public static int GetRandomGroundLevel(Random rnd)
        {
            return rnd.Next(16);
        }

        public static int GetRandomBlockType(Random rnd)
        {
            return rnd.Next(5);
        }

        public static int GetRandomBlockHeight(Random rnd)
        {
            return rnd.Next(1, 5);
        }

        public static int GetRandomEnemyType(Random rnd)
        {
            return rnd.Next(3);
        }

        public static int GetRandomCoinHeight(Random rnd)
        {
            return rnd.Next(11);
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
            this.blockHeight.CopyTo(individ.blockHeight,0);
            this.blockType.CopyTo(individ.blockType,0);
            this.coinHeight.CopyTo(individ.coinHeight,0);
            this.enemyType.CopyTo(individ.enemyType,0);

            int indexToMutate = rnd.Next(100);
            this.groundLevel[indexToMutate] = GetRandomGroundLevel(rnd);
            this.blockHeight[indexToMutate] = GetRandomBlockHeight(rnd);
            this.blockType[indexToMutate] = GetRandomCoinHeight(rnd);
            this.enemyType[indexToMutate] = GetRandomEnemyType(rnd);

            return individ;
        }
    }
}