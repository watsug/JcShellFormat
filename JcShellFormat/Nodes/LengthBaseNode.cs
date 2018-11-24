namespace Watsug.JcShellFormat.Nodes
{
    public abstract class LengthBaseNode : BaseNode
    {
        public LengthBaseNode(IExpressionNode parent) : base(parent)
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
                return Parent;
            }

            return base.Push(c);
        }

        public override string Evaluate()
        {
            string tmp = base.Evaluate();
            return LengthToString(tmp.Length / 2) + tmp;
        }

        protected abstract string LengthToString(int length);
    }
}