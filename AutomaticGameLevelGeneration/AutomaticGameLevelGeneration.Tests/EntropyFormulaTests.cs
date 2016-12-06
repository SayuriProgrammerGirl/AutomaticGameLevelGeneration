namespace AutomaticGameLevelGeneration.Tests
{
    
    using AutomaticGameLevelGeneration.FitnessFunctions;

    using AutomaticGameLevelGeneration.Configuration;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EntropyFormulaTests
    {
        [TestMethod]
        public void TestEntropyComputation1()
        {
            var testValues = new[] { 0, 1, 0, 1 };

            var formula = new EntropyFormula(new FitnessConfiguration { MaximumValue = 1 });

            var result = formula.Compute(testValues);
            double expectedResult = 1;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestEntropyComputation2()
        {
            var testValues = new[] { 0, 1, 2, 2, 0, 1 };

            var formula = new EntropyFormula(new FitnessConfiguration { MaximumValue = 2 });

            double result = formula.Compute(testValues);
            double expectedResult = 1.58496250072116;

            Assert.AreEqual(expectedResult, result,0.0000001);
        }

        [TestMethod]
        public void TestEntropyComputation3()
        {
            var testValues = new[] { 0, 0, 0, 0, 0, 0 };

            var formula = new EntropyFormula(new FitnessConfiguration { MaximumValue = 2 });

            var result = formula.Compute(testValues);
            double expectedResult = 0;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
