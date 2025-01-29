using Microsoft.VisualStudio.TestTools.UnitTesting;
using CITest2;

namespace MathTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int result = AgainAMathClass.mathAdd(5, 15);
            Assert.AreEqual(result, 20);
        }
    }
}