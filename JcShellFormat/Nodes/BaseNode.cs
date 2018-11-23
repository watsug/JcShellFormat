using System.Text;

namespace Watsug.JcShellFormat.Nodes
{
    public abstract class BaseNode : IExpressionNode
    {
        protected StringBuilder _buff = new StringBuilder();

        public abstract string Evaluate();

        public virtual IExpressionNode Push(char c)
        {
            _buff.Append(c);
            return this;
        }

        public abstract IExpressionNode Push(IExpressionNode exprNode);
    }
}