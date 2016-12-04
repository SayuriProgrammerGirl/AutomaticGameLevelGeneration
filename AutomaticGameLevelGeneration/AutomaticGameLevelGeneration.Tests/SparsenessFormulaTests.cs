namespace AutomaticGameLevelGeneration.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SparsenessFormulaTests
    {
        [TestMethod]
        public void TestOfSparsenessForTestData1()
        {
            int[] testValues = { 1, 0, 1, 1};
            double result = new SparesenessFormula(4).Compute(testValues);
            Assert.AreEqual(2,result);
        }
    }
}