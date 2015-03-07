using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace ClassNewtonMethodTask1.Tests
{
    [TestClass]
    public class NewtonMethodTest
    {
        public TestContext TestContext { get; set; }

        [DataSource(
           "Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\Newton.xml",
           "TestCase",
           DataAccessMethod.Sequential)]
        [DeploymentItem("ClassNewtonMethodTask1.Tests\\Newton.xml")]
        [TestMethod]
        public void RootCalculationTest1()
        {

            double value = double.Parse((string)TestContext.DataRow["value"], CultureInfo.InvariantCulture);
            double power = double.Parse((string)TestContext.DataRow["power"], CultureInfo.InvariantCulture);
            double accuracy = double.Parse((string)TestContext.DataRow["accuracy"], CultureInfo.InvariantCulture);

            double root = NewtonMethod.RootCalculation(value, power, accuracy);

            //it is obviously that NaN is equal to any number
            Assert.AreEqual(root, Math.Pow(value, 1 / power), accuracy);
        }
    }
}
