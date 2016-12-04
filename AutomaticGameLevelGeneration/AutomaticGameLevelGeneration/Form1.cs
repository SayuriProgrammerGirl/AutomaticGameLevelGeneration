using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomaticGameLevelGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public class SparsenessFormula
    {
        
    }

    public class ApplicationLogic
    {
        public void Execute()
        {
            Random rnd = new Random();
            List<Individ> individs = new List<Individ>();
            for (int i = 0; i < 100; i++)
            {
                var individ = new Individ(rnd);

                individs.Add(individ);
            }
        }    
    }


    public class FitnessFunction
    {
        public double EvaluateIndividual()
        {
            return 0;
        }

        public double EvaluateGroundLevels(int[] groundLevels)
        {
            var entropyFormula = new EntropyFormula(15, 100);
            var entropy = entropyFormula.Compute(groundLevels);

            double fitness = 0;
            return fitness;
        }
    }

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
    }

    //public class Generation
    //{
    //    private Population population;
    //    public static Generation GetGenerationZero()
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class Population
    //{
    //    private List<Individ> individs;
    //}

    //internal class Individ
    //{
    //    private List<Chromosome> chromosomes;
    //    private float fitness;
    //}

    //internal class Chromosome
    //{
    //    private int groundLevel;

    //    private int blockType;

    //    private int blockHeight;

    //    private int enemyType;

    //    private int coinHeight;
    //}
}
