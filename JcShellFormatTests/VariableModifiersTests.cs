namespace Watsug.JcShellFormatTests
{
    using NUnit.Framework;
    using JcShellFormat;
    using System.Collections.Generic;

    [TestFixture]
    public class VariableModifiersTests
    {
        [Test]
        public void PositiveH2Test()
        {
            var jcs = new JcShellFormat("FF${x1;h2}FF", new Dictionary<string, string>{{"x1", "21"}});
            Assert.AreEqual("FF15FF", jcs.Evaluate());
        }

        [Test]
        public void PositiveH4Test()
        {
            var jcs = new JcShellFormat("FF${21;h4}FF", new Dictionary<string, string> { { "x1", "21" } });
            Assert.AreEqual("FF0015FF", jcs.Evaluate());
        }

        [Test]
        public void PositiveLengthNoVarTest()
        {
            // TODO: still not decided how to support such case...?
            var jcs = new JcShellFormat("${abc;l}");
            Assert.AreEqual("3", jcs.Evaluate());
        }

        [Test]
        public void PositiveLengthTest()
        {
            var jcs = new JcShellFormat("${x1;l}", new Dictionary<string, string> { { "x1", "1234" } });
            Assert.AreEqual("4", jcs.Evaluate());
        }

        [Test]
        public void PositiveUppercaseTest()
        {
            var jcs = new JcShellFormat("${x1;uc}", new Dictionary<string, string> { { "x1", "WaTsUg" } });
            Assert.AreEqual("WATSUG", jcs.Evaluate());
        }

        [Test]
        public void PositiveSimpeLowercaseTest()
        {
            var jcs = new JcShellFormat("${x1;lc}", new Dictionary<string, string> { { "x1", "WaTsUg" } });
            Assert.AreEqual("watsug", jcs.Evaluate());
        }
    }
}