namespace Watsug.JcShellFormatTests
{
    using JcShellFormat;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class LegacyVariablesTests
    {
        [Test]
        public void PositiveSimpleDictionaryTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "Hello"}
            };
            var jcs = new JcShellFormat("{x1}", dict, JcShellFormat.Options.LegacyVariables);
            Assert.AreEqual("Hello", jcs.Evaluate());
        }

        [Test]
        public void PositiveDoubleDictionaryTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "Hello"},
                {"x2", "1"}
            };
            var jcs = new JcShellFormat("{x{x2}}", dict, JcShellFormat.Options.LegacyVariables);
            Assert.AreEqual("Hello", jcs.Evaluate());
        }
    }
}