namespace AutomaticGameLevelGeneration
{
    using System;
    using System.Linq;

    public class EntropyFormula
    {
        private readonly int maxValue;
        private readonly int numberOfValues;

        public EntropyFormula(int maxValue, int numberOfValues)
        {
            this.maxValue = maxValue;
            this.numberOfValues = numberOfValues;
        }

        public double Compute(int[] values)
        {
            int[] valueCounts = GetValueCounts(values);
            double[] valueProbabilities = GetProbabilities(valueCounts);
            double entropy = ComputeValueEntropy(valueProbabilities);
            return entropy;
        }

        internal double ComputeValueEntropy(double[] probabilities)
        {
            double sum = probabilities
                .Sum(x => x * Math.Log(x, 2));

            double entropy = -1 * sum;

            return entropy;
        }

        internal int[] GetValueCounts(int[] values)
        {
            int[] counts = new int[maxValue + 1];

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

        internal double[] GetProbabilities(int[] valueCounts)
        {
            double[] valueProbability = new double[maxValue+1];

            for (int i = 0; i < valueProbability.Length; i++)
            {
                double probability = valueCounts[i] / (double)numberOfValues;
                valueProbability[i] = probability;
            }

            return valueProbability;
        }
    }
}