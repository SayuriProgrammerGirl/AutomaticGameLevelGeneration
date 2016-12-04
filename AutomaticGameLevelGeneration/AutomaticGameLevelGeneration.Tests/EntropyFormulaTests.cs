namespace AutomaticGameLevelGeneration.Tests
{
    using AutomaticGameLevelGeneration.FitnessFunctions;

    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntropyFormulaTests
    {
        [TestMethod]
        public void TestEntropyCountOfValuesOccurence()
        {
            var testValues = new[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            var formula = new EntropyFormula(
                                    maxValue: testValues.Max(),
                                    numberOfValues: testValues.Length);

            int[] result = formula.GetValueCounts(testValues);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(i, result[i]);
            }
        }

        [TestMethod]
        public void TestEntropyComputeProbabilityOfValueToAppear()
        {
            var testCounts = new[] { 0, 1, 1, 2 };
            var expectedResult = new[] { 0, 0.25, 0.25, 0.5 };

            var formula = new EntropyFormula(
                                    maxValue: 3,
                                    numberOfValues: testCounts.Sum());

            var result = formula.GetProbabilities(testCounts);

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod]
        public void TestEntropyComputationBasedOnProbabilities()
        {
            var testProbabilities = new[] { 0.5, 0.5 };

            var formula = new EntropyFormula(
                                    maxValue: 1,
                                    numberOfValues: 2);

            var result = formula.ComputeValueEntropy(testProbabilities);
            double expectedResult = 1;

            Assert.AreEqual(expectedResult, result);

        }
    }
}
