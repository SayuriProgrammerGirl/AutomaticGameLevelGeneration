using System;
using AutomaticGameLevelGeneration.FitnessFunctions;

namespace AutomaticGameLevelGeneration
{
    public class FitnessFunction
    {
        public double EvaluateIndividual(Individ individ)
        {
            //float sumOfBatchesFitness = 0;
            //var entropyParts = Singletons.Configuration.GroundConfig.EntropyParts;
            //var levelWidth = Singletons.Configuration.LevelWidth;

            //float batches = (float)levelWidth / entropyParts;
            //batches = (float)Math.Ceiling(batches);

            //for (int i = 0; i < batches; i++)
            //{
            //    int minIndex = i * entropyParts;
            //    int maxIndex = (minIndex + entropyParts - 1);
            //    if (maxIndex >= levelWidth)
            //    {
            //        maxIndex = levelWidth - 1;
            //    }

            //    var batchSize = maxIndex - minIndex - 1;

            //    EntropyFormula ef = new EntropyFormula(
            //        Singletons.Configuration.GroundConfig.MaximumValue,
            //        batchSize);

            //    int[] batchArray = new int[batchSize];
            //    for (int j = 0; j < batchSize; j++)
            //    {
            //        batchArray[j] = individ.groundLevel[minIndex + j];
            //    }

            //    double result = ef.Compute(batchArray);
            //    sumOfBatchesFitness += (float)result;
            //}

            //float avg = sumOfBatchesFitness / batches;

            ////TODO - evaluate in batches
            ////TODO - evaluate distance to desired values
            //var entropy = new EntropyFormula(Singletons.Configuration.GroundConfig.MaximumValue, 100);
            //var groundLevelEvaluation = entropy.Compute(individ.groundLevel);
            //var sparseness = new SparesenessFormula(100);
            //var blockSparsenessEval = sparseness.Compute(individ.blockHeight);
            //var coinSparsenessEval = sparseness.Compute(individ.coinHeight);
            //var enemySparsenessEval = sparseness.Compute(individ.enemyType);

            //TODO - send config as parameter, no more primitive obsession
            var groundLevelEvaluation = EvalEntropy(individ, Singletons.Configuration.GroundConfig.EntropyParts,
                Singletons.Configuration.GroundConfig.MaximumValue, Singletons.Configuration.GroundConfig.DesiredEntropy);
            var blockSparsenessEval = EvalSparseness(individ, Singletons.Configuration.BlockConfig.SparsenessParts,
                Singletons.Configuration.BlockConfig.DesiredSparseness);
            var coinSparsenessEval = EvalSparseness(individ, Singletons.Configuration.CoinsConfig.SparsenessParts,
                Singletons.Configuration.CoinsConfig.DesiredSparseness);
            var enemySparsenessEval = EvalSparseness(individ, Singletons.Configuration.EnemyConfig.SparsenessParts,
                Singletons.Configuration.EnemyConfig.DesiredSparseness);

            return groundLevelEvaluation + blockSparsenessEval + coinSparsenessEval + enemySparsenessEval;

        }

        private float EvalEntropy(Individ individ, int numberOfParts, int maxValue, float desiredFunctionValue)
        {
            var levelWidth = Singletons.Configuration.LevelWidth;

            float batches = (float)Math.Ceiling((float)levelWidth / numberOfParts);

            float sumOfBatchesFitness = 0;
            for (int i = 0; i < batches; i++)
            {
                int minIndex = i * numberOfParts;
                int maxIndex = (minIndex + numberOfParts - 1);
                if (maxIndex >= levelWidth)
                {
                    maxIndex = levelWidth - 1;
                }

                var batchSize = maxIndex - minIndex - 1;

                EntropyFormula ef = new EntropyFormula(
                    maxValue,
                    batchSize);

                int[] batchArray = new int[batchSize];
                for (int j = 0; j < batchSize; j++)
                {
                    batchArray[j] = individ.groundLevel[minIndex + j];
                }

                double result = ef.Compute(batchArray);
                sumOfBatchesFitness += (float)Math.Abs(desiredFunctionValue - result);
            }

            float avg = sumOfBatchesFitness / batches;
            return avg;
        }

        private float EvalSparseness(Individ individ, int numberOfParts, float desiredFunctionValue)
        {
            var levelWidth = Singletons.Configuration.LevelWidth;

            float batches = (float)Math.Ceiling((float)levelWidth / numberOfParts);

            float sumOfBatchesFitness = 0;
            for (int i = 0; i < batches; i++)
            {
                int minIndex = i * numberOfParts;
                int maxIndex = (minIndex + numberOfParts - 1);
                if (maxIndex >= levelWidth)
                {
                    maxIndex = levelWidth - 1;
                }

                var batchSize = maxIndex - minIndex - 1;

                SparesenessFormula ef = new SparesenessFormula(levelWidth);

                int[] batchArray = new int[batchSize];
                for (int j = 0; j < batchSize; j++)
                {
                    batchArray[j] = individ.groundLevel[minIndex + j];
                }

                double result = ef.Compute(batchArray);
                sumOfBatchesFitness += (float)Math.Abs(desiredFunctionValue - result);
            }

            float avg = sumOfBatchesFitness / batches;
            return avg;
        }
    }
}