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
            int[] valueCounts = this.GetValueCounts(values);
            double[] valueProbabilities = this.GetProbabilities(valueCounts);
            double entropy = this.ComputeValueEntropy(valueProbabilities);
            return entropy;
        }

        internal double ComputeValueEntropy(double[] probabilities)
        {
            double sum = probabilities
                .Sum(x => x * Math.Log(x, 2));

            double entropy = -1 * sum;

            return entropy;
        }

        //TODO - extract to another class
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

        //TODO - extract to another class
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