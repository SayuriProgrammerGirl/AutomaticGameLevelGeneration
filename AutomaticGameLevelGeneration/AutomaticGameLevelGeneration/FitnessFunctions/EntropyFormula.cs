namespace AutomaticGameLevelGeneration.FitnessFunctions
{
    using System;
    using System.Linq;

    using AutomaticGameLevelGeneration.Configuration;

    public class EntropyFormula : IFitnessFunction
    {
        private readonly FitnessConfiguration config;

        public EntropyFormula(FitnessConfiguration config)
        {
            this.config = config;
        }

        public double Compute(int[] values)
        {
            int[] valueCounts = this.GetValueCounts(values);
            double[] valueProbabilities = this.GetProbabilities(valueCounts, values.Length);
            double entropy = this.ComputeValueEntropy(valueProbabilities);
            return entropy;
        }



        internal double ComputeValueEntropy(double[] probabilities)
        {
            double sum = probabilities.Where(x => Math.Abs(x) > 0.00000001).Sum(x => x * Math.Log(x, 2));

            double entropy = -1 * sum;

            return entropy;
        }

        private int[] GetValueCounts(int[] values)
        {
            int[] counts = new int[this.config.MaximumValue + 1];

            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = 0;
            }

            foreach (int value in values)
            {
                counts[value]++;
            }

            return counts;
        }

        private double[] GetProbabilities(int[] valueCounts, int numberOfValues)
        {
            double[] valueProbability = new double[config.MaximumValue + 1];

            for (int i = 0; i < valueProbability.Length; i++)
            {
                double probability = valueCounts[i] / (double)numberOfValues;
                valueProbability[i] = probability;
            }

            return valueProbability;
        }
    }
}