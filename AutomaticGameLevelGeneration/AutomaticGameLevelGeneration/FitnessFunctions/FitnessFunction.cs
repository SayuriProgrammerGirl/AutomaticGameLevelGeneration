﻿namespace AutomaticGameLevelGeneration.FitnessFunctions
{
    using System;

    using AutomaticGameLevelGeneration.Configuration;

    public class FitnessFunction
    {
        public double EvaluateIndividual(Individ individ)
        {
            var groundLevelEvaluation = this.EvalEntropy(individ, Singletons.Configuration.GroundConfig);
            var blockSparsenessEval = this.EvalSparseness(individ, Singletons.Configuration.BlockConfig);
            var coinSparsenessEval = this.EvalSparseness(individ, Singletons.Configuration.CoinsConfig);
            var enemySparsenessEval = this.EvalSparseness(individ, Singletons.Configuration.EnemyConfig);

            return (groundLevelEvaluation + blockSparsenessEval + coinSparsenessEval + enemySparsenessEval)/4;
        }

        private float EvalEntropy(Individ individ, FitnessConfiguration config)
        {
            return this.Eval(individ, config, new EntropyFormula(config));
        }

        private float EvalSparseness(Individ individ, FitnessConfiguration config)
        {
            return this.Eval(individ, config, new SparesenessFormula());
        }

        private float Eval(Individ individ, FitnessConfiguration config, IFitnessFunction func)
        {
            var levelWidth = Singletons.Configuration.LevelWidth;

            float batches = (float)Math.Ceiling((float)levelWidth / config.PartsPerBatch);

            float sumOfBatchesFitness = 0;
            for (int i = 0; i < batches; i++)
            {
                int minIndex = i * config.PartsPerBatch;
                int maxIndex = (minIndex + config.PartsPerBatch - 1);
                if (maxIndex >= levelWidth)
                {
                    maxIndex = levelWidth - 1;
                }

                var batchSize = maxIndex - minIndex - 1;

                int[] batchArray = new int[batchSize];
                for (int j = 0; j < batchSize; j++)
                {
                    batchArray[j] = individ.groundLevel[minIndex + j];
                }

                double result = func.Compute(batchArray);
                sumOfBatchesFitness += (float)Math.Abs(config.DesiredFitness - result);
            }

            float avg = sumOfBatchesFitness / batches;
            return avg;
        }
    }
}