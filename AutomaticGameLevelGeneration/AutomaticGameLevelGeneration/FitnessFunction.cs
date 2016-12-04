using AutomaticGameLevelGeneration.FitnessFunctions;

namespace AutomaticGameLevelGeneration
{
    public class FitnessFunction
    {
        public double EvaluateIndividual(Individ i)
        {
            //TODO - evaluate in batches

            //TODO - evaluate distance to desired values
            var entropy = new EntropyFormula(15, 100);
            var groundLevelEvaluation = entropy.Compute(i.groundLevel);
            var sparseness = new SparesenessFormula(100);
            var blockSparsenessEval = sparseness.Compute(i.blockHeight);
            var coinSparsenessEval = sparseness.Compute(i.coinHeight);
            var enemySparsenessEval = sparseness.Compute(i.enemyType);

            return groundLevelEvaluation + blockSparsenessEval + coinSparsenessEval + enemySparsenessEval;
        }
        
    }
}