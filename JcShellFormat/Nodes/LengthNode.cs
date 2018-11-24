namespace Watsug.JcShellFormat.Nodes
{
    public class LengthNode : LengthBaseNode
    {
        public LengthNode(IExpressionNode parent) : base(parent)
        {
        }

        protected override string LengthToString(int length)
        {
            if ((length & 0xff000000) != 0)
            {
                return length.ToString("X8");
            }
            else if ((length & 0xffff0000) != 0)
            {
                return length.ToString("X6");
            }
            else if ((length & 0xffffff00) != 0)
            {
                return length.ToString("X6");
            }
            else
            {
                return length.ToString("X2");
            }
        }
    }
}