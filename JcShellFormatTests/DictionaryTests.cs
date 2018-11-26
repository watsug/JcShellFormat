﻿namespace Watsug.JcShellFormatTests
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
                {"x1", "Hello"}
            };
            var jcs = new JcShellFormat("${x1}", dict);
            Assert.AreEqual("Hello", jcs.Evaluate());
        }

        [Test]
        public void PositiveSimpeDictionaryH2Test()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "21"}
            };
            var jcs = new JcShellFormat("FF${x1;h2}FF", dict);
            Assert.AreEqual("FF15FF", jcs.Evaluate());
        }

        [Test]
        public void PositiveSimpeDictionaryH4Test()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "21"}
            };
            var jcs = new JcShellFormat("FF${x1;h4}FF", dict);
            Assert.AreEqual("FF0015FF", jcs.Evaluate());
        }

        [Test]
        public void PositiveDoubleDictionaryTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"x1", "Hello"},
                {"x2", "1"}
            };
            var jcs = new JcShellFormat("${x${x2}}", dict);
            Assert.AreEqual("Hello", jcs.Evaluate());
        }
    }
}