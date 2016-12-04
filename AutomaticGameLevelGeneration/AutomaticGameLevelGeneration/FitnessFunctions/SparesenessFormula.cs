namespace AutomaticGameLevelGeneration.FitnessFunctions
{
    using System;

    public class SparesenessFormula : IFitnessFunction
    {
        private readonly int numberOfValues;

        public SparesenessFormula(int numberOfValues)
        {
            this.numberOfValues = numberOfValues;
        }

        //For coins, blocks, enemies
        public double Compute(int[] values)
        {
            var sum = this.GetSum(values);

            double sparseness = sum * this.GetMultiplicationCoefficient();

            return sparseness;
        }

        private double GetMultiplicationCoefficient()
        {
            return (double)2 / (this.numberOfValues * (this.numberOfValues - 1));
        }

        internal double GetSum(int[] values)
        {
            double sum = 0;

            for (int i = 0; i < this.numberOfValues; i++)
            {
                if (IsNotEmptyValue(values[i]))
                {
                    sum += this.GetSumOfAllDistancesFromValue(i, values);
                }
            }
            return sum;
        }

        internal double GetSumOfAllDistancesFromValue(int valuePosition, int[] values)
        {
            double sum = 0;

            for (int position = 0; position < this.numberOfValues; position++)
            {
                if (IsNotEmptyValue(values[position]))
                {
                    int distance = Math.Abs(valuePosition - position);
                    sum += distance;
                }
            }

            return sum;
        }

        internal static bool IsNotEmptyValue(int value)
        {
            return value != 0;
        }
    }
}