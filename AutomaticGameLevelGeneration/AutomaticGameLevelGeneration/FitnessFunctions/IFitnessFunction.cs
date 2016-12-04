namespace AutomaticGameLevelGeneration.FitnessFunctions
{
    public interface IFitnessFunction
    {
        double Compute(int[] values);
    }
}