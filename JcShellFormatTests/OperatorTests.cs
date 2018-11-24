namespace Watsug.JcShellFormatTests
{
    using NUnit.Framework;
    using JcShellFormat;

    [TestFixture]
    public class OperatorTests
    {
        [Test]
        public void PositiveLengthCalculate()
        {
            JcShellFormat jcs = new JcShellFormat("#(AABBCC)");
            Assert.AreEqual("03AABBCC", jcs.Evaluate());
        }

        [Test]
        public void PositiveBerLengthCalculate_1byte()
        {
            JcShellFormat jcs = new JcShellFormat("%(112233)");
            Assert.AreEqual("03112233", jcs.Evaluate());
        }

        [Test]
        public void PositiveBerLengthCalculate_2bytes()
        {
            string data = new string('1',0x81 * 2);
            JcShellFormat jcs = new JcShellFormat($"%({data})");
            Assert.AreEqual($"8181{data}", jcs.Evaluate());
        }
    }
}