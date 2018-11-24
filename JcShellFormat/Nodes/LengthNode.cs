namespace Watsug.JcShellFormat.Nodes
{
    public class LengthNode : BaseNode
    {
        public LengthNode(IExpressionNode parent) : base(parent)
        {
        }

        public override IExpressionNode Push(char c)
        {
            if (Tokens.LengthStart == c)
            {
                // skip start node
                // TODO: check if it is first token!
                return this;
            }

            if (Tokens.LengthEnd == c)
            {
                // the end of this node
                return _parent;
            }

            return base.Push(c);
        }

        public override string Evaluate()
        {
            string tmp = base.Evaluate();
            return LengthToString(tmp.Length / 2) + tmp;
        }

        private string LengthToString(int length)
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