using System.Collections.Generic;
using System.Text;

namespace Watsug.JcShellFormat.Nodes
{
    public abstract class BaseNode : IExpressionNode
    {
        protected StringBuilder _buff = new StringBuilder();
        protected List<IExpressionNode> _children = new List<IExpressionNode>();

        protected BaseNode(IExpressionNode parent)
        {
            Parent = parent;
        }

        public IExpressionNode Parent { get; protected set; }

        public virtual IExpressionNode Push(char c)
        {
            _buff.Append(c);
            return this;
        }

        public virtual IExpressionNode Push(IExpressionNode exprNode)
        {
            if (_buff.Length > 0)
            {
                var tmpStr = _buff.ToString();
                _buff.Clear();
                var textNode = new TextNode(this, tmpStr);
                _children.Add(textNode);
            }
            _children.Add(exprNode);
            return this;
        }

        public virtual string Evaluate()
        {
            StringBuilder tmp = new StringBuilder();
            foreach (var child in _children)
            {
                tmp.Append(child.Evaluate());
            }

            tmp.Append(_buff);
            return tmp.ToString();
        }
    }
}