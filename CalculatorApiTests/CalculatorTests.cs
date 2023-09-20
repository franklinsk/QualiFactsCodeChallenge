using CalculatorApi.Models;
using CalculatorApi.MyUtils;

namespace CalculatorApiTests
{
    public class Tests
    {
        List<CalculationResult> results;

        [SetUp]
        public void Setup()
        {
            results = new List<CalculationResult>();
        }

        [Test]
        public void CalculateResults_SizeIsRight()
        {
            results = CalculatorUtils.calculateResult(2,3,20);


            Assert.AreEqual(20, results.Count);
        }

        [Test]
        public void CalculateResults_EqualsYes()
        {
            results = CalculatorUtils.calculateResult(2, 3, 20);


            Assert.AreEqual("yes", results[1].Result);
        }

        [Test]
        public void CalculateResults_EqualsNo()
        {
            results = CalculatorUtils.calculateResult(2, 3, 20);


            Assert.AreEqual("no", results[2].Result);
        }
    }
}