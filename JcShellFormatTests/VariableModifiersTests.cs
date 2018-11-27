using System;

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
        public void PositiveLowercaseTest()
        {
            var jcs = new JcShellFormat("${x1;lc}", new Dictionary<string, string> { { "x1", "WaTsUg" } });
            Assert.AreEqual("watsug", jcs.Evaluate());
        }

        [Test]
        public void PositiveSubstringTest()
        {
            var jcs = new JcShellFormat("${text;s5,7}", new Dictionary<string, string> { { "text", "this is my test" } });
            Assert.AreEqual("is my t", jcs.Evaluate());
        }

        [Test]
        public void PositiveSubstringAtTheEndTest()
        {
            var jcs = new JcShellFormat("${text;s15}", new Dictionary<string, string> { { "text", "this is my test" } });
            Assert.AreEqual("", jcs.Evaluate());
        }

        [Test]
        public void PositiveSubstringAtTheEndNegativeLengthTest()
        {
            var jcs = new JcShellFormat("${text;s15,-1}", new Dictionary<string, string> { { "text", "this is my test" } });
            Assert.AreEqual("", jcs.Evaluate());
        }

        [Test]
        public void NegativeSubstringOneCharAfterTheEndTest()
        {
            var jcs = new JcShellFormat("${text;s16}", new Dictionary<string, string> { { "text", "this is my test" } });
            Assert.Throws<ArgumentOutOfRangeException>(() => jcs.Evaluate());
        }

        [Test]
        public void NegativeSubstringAtTheEndWithOffsetTest()
        {
            var jcs = new JcShellFormat("${text;s15,1}", new Dictionary<string, string> { { "text", "this is my test" } });
            Assert.Throws<ArgumentOutOfRangeException>(() => jcs.Evaluate());
        }
    }
}