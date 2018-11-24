namespace Watsug.JcShellFormat.Nodes
{
    public class BerLengthNode : LengthBaseNode
    {
        public BerLengthNode(IExpressionNode parent) : base(parent)
        {
        }

        protected override string LengthToString(int length)
        {
            if (length <= 0x7f)
            {
                return length.ToString("X2");
            }
            else if (length >= 0x80 && length <= 0xff)
            {
                return "81" + length.ToString("X2");
            }
            else if (length > 0xff && length <= 0xffff)
            {
                return "82" + length.ToString("X4");
            }
            else
            {
                throw new JcShellFormatException($"BER length bigger than FFFFh is not supported: {length.ToString(("X"))}h!");
            }
        }
    }
}