namespace AutomaticGameLevelGeneration.FitnessFunctions
{
    using System;

    public class SparesenessFormula : IFitnessFunction
    {
        //For coins, blocks, enemies
        public double Compute(int[] values)
        {
            var sum = this.GetSum(values);

            double sparseness = sum * this.GetMultiplicationCoefficient(values.Length);

            return sparseness;
        }

        private double GetMultiplicationCoefficient(int numberOfValues)
        {
            return (double)2 / (Math.Pow(numberOfValues, 2) - 1);
        }

        internal double GetSum(int[] values)
        {
            double sum = 0;

            for (int i = 0; i < values.Length; i++)
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

            for (int position = 0; position < values.Length; position++)
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