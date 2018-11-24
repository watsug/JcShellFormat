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

        [Test]
        public void PositiveLengthCalculate_Complex()
        {
            JcShellFormat jcs =
                new JcShellFormat("86#(A0#(80#()81#(01)82#(0102)83#(7777777777)84#(66)85#(01)86#(123456))A1#(80#(00111111)81#(01)82#(0101)83#(0011111111)84#(00)85#(01)86#(00FF00)))");
            Assert.AreEqual("863EA01B800081010182020102830577777777778401668501018603123456A11F8004001111118101018202010183050011111111840100850101860300FF00",
                jcs.Evaluate());
        }
    }
}