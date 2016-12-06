namespace AutomaticGameLevelGeneration.Tests
{
    using AutomaticGameLevelGeneration.FitnessFunctions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SparsenessFormulaTests
    {
        [TestMethod]
        public void TestOfSparsenessForTestData1()
        {
            int[] testValues = { 1, 0, 1, 1 };
            double result = new SparesenessFormula().Compute(testValues);
            Assert.AreEqual((double)24 / 15, result,0.0000001);
        }

        [TestMethod]
        public void TestOfSparsenessForTestData2()
        {
            int[] testValues = { 1, 0, 2, 0 };
            double result = new SparesenessFormula().Compute(testValues);
            Assert.AreEqual((double)8 / 15, result,0.000001);
        }
    }
}