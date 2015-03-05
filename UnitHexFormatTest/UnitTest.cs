using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomHexFormatProvider.Tests
{
    [TestClass]
    public class HexFormatTest
    {
        public TestContext TestContext { get; set; }

        [DataSource(
           "Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\Format.xml",
           "TestCase",
           DataAccessMethod.Sequential)]
        [DeploymentItem("CustomHexFormatProvider.Tests\\Format.xml")]
        [TestMethod]
        public void FormatTest1()
        {
            var provider = new HexFormat();
            var value = Convert.ToInt64(TestContext.DataRow["value"]);

            string s1 = string.Format(provider, Convert.ToString(TestContext.DataRow["testFormat"]), value);
            string s2 = string.Format(provider, Convert.ToString(TestContext.DataRow["checkFormat"]), value);

            Assert.AreEqual(s1,s2);
        }
    }
}
