namespace Watsug.JcShellFormatTests
{
    using JcShellFormat;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class DictionaryTests
    {
        [Test]
        public void PositiveSimpeDictionaryTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "Hello"},
                {"x2", "1"}
            };
            JcShellFormat jcs = new JcShellFormat("${x1}", dict);
            Assert.AreEqual("Hello", jcs.Evaluate());

            jcs = new JcShellFormat("${x${x2}}", dict);
            Assert.AreEqual("Hello", jcs.Evaluate());
        }
    }
}