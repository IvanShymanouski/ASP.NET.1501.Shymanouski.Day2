using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCD = GreatestCommonDivisorLibrary.GreatestCommonDivisor;

namespace GreatestCommonDivisorLibrary.Tests
{
    [TestClass]
    public class GreatestCommonDivisorTest
    {
        public TestContext TestContext { get; set; }

        [DataSource(
           "Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\Euclidean.xml",
           "TestCase",
           DataAccessMethod.Sequential)]
        [DeploymentItem("GreatestCommonDivisor.Tests\\Euclidean.xml")]
        [TestMethod]
        public void EuclideanAlgorithmTest()
        {
            long timeTicks;
            Assert.AreEqual(GCD.EuclideanAlgorithmWithTiming(out timeTicks,
                                                             int.Parse((string)TestContext.DataRow["a"]),
                                                             int.Parse((string)TestContext.DataRow["b"])
                                                            ),
                            int.Parse((string)TestContext.DataRow["result"])
                           );
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);
        }

        [DataSource(
         "Microsoft.VisualStudio.TestTools.DataSource.XML",
         "|DataDirectory|\\Euclidean.xml",
         "TestCase",
         DataAccessMethod.Sequential)]
        [DeploymentItem("GreatestCommonDivisor.Tests\\Euclidean.xml")]
        [TestMethod]
        public void SteinAlgorithmTest()
        {
            long timeTicks;
            Assert.AreEqual(GCD.SteinAlgorithmWithTiming(out timeTicks,
                                                             int.Parse((string)TestContext.DataRow["a"]),
                                                             int.Parse((string)TestContext.DataRow["b"])
                                                            ),
                            int.Parse((string)TestContext.DataRow["result"])
                           );
            if (timeTicks<0) Assert.Fail("Time ticks : {0}", timeTicks);
        }

        [TestMethod]
        public void EuclideanAlgorithmTest2()
        {
            long timeTicks;
            Assert.AreEqual(GCD.EuclideanAlgorithmWithTiming(out timeTicks,0, 500, 19), 1);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.EuclideanAlgorithmWithTiming(out timeTicks, 38, 500, 19), 1);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.EuclideanAlgorithmWithTiming(out timeTicks, 38, 950, 19, 57), 19);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.EuclideanAlgorithmWithTiming(out timeTicks, 57), 57);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);
        }

        [TestMethod]
        public void SteinAlgorithmTest2()
        {
            long timeTicks;
            Assert.AreEqual(GCD.SteinAlgorithmWithTiming(out timeTicks, 0, 500, 19), 1);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.SteinAlgorithmWithTiming(out timeTicks, 38, 500, 19), 1);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.SteinAlgorithmWithTiming(out timeTicks, 38, 950, 19, 57), 19);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);

            Assert.AreEqual(GCD.SteinAlgorithmWithTiming(out timeTicks, 57), 57);
            if (timeTicks < 0) Assert.Fail("Time ticks : {0}", timeTicks);
        } 
    }
}
