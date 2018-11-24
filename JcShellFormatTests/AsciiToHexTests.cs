namespace Watsug.JcShellFormatTests
{
    using JcShellFormat;
    using NUnit.Framework;

    [TestFixture]
    public class AsciiToHexTests
    {
        [Test]
        public void PositiveSimpleAsciiToHex()
        {
            JcShellFormat jcs = new JcShellFormat("0102|ab|0304|cd");
            Assert.AreEqual("0102616203046364", jcs.Evaluate());
        }
        [Test]
        public void PositiveSimpleAsciiToHexWithLength()
        {
            JcShellFormat jcs = new JcShellFormat("01#(|ab|#{FEFF})");
            Assert.AreEqual("0105616202FEFF", jcs.Evaluate());
        }
    }
}