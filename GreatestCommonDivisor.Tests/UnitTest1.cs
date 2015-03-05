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
            Assert.AreEqual(GCD.EuclideanAlgorithm(int.Parse((string)TestContext.DataRow["a"]), 
                                                   int.Parse((string)TestContext.DataRow["b"])
                                                  ),
                            int.Parse((string)TestContext.DataRow["result"])
                           );
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
            Assert.AreEqual(GCD.SteinAlgorithm(int.Parse((string)TestContext.DataRow["a"]),
                                               int.Parse((string)TestContext.DataRow["b"])
                                              ),
                            int.Parse((string)TestContext.DataRow["result"])
                           );
        }

        [TestMethod]
        public void EuclideanAlgorithmTest2()
        {
            Assert.AreEqual(GCD.EuclideanAlgorithm(0, 500, 19), 1);
            Assert.AreEqual(GCD.EuclideanAlgorithm(38, 500, 19), 1);
            Assert.AreEqual(GCD.EuclideanAlgorithm(38, 950, 19, 57), 19); 
            Assert.AreEqual(GCD.EuclideanAlgorithm(57), 57);
        }

        [TestMethod]
        public void SteinAlgorithmTest2()
        {
            Assert.AreEqual(GCD.SteinAlgorithm(0, 500, 19), 1);
            Assert.AreEqual(GCD.SteinAlgorithm(38, 500, 19), 1);
            Assert.AreEqual(GCD.SteinAlgorithm(57), 57);
        } 
    }
}
