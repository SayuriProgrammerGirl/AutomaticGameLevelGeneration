namespace AutomaticGameLevelGeneration
{
    using AutomaticGameLevelGeneration.Configuration;

    public class ArrayUtil
    {
        public static int[] GenerateRandomArray(LevelConfig cfg, int maxValue)
        {
            var array = new int[cfg.LevelWidth];

            for (int i = 0; i < cfg.LevelWidth; i++)
            {
                array[i] = Singletons.RandomInstance.Next(maxValue + 1);
            }

            return array;
        }

        public static int[] GenerateRandomArray(LevelConfig cfg, FitnessConfiguration config)
        {
            return GenerateRandomArray(cfg, config.MaximumValue);
        }

        public static int[] CloneArray(int[] source)
        {
            int[] copy = new int[source.Length];
            source.CopyTo(copy, 0);
            return copy;
        }

        public static void CopyValuesFromStartIndexToEndIndex(int[] source, int[] destination, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                destination[i] = source[i];
            }
        }
    }
}