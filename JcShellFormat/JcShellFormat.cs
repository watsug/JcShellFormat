using System.Collections.Generic;
using Watsug.JcShellFormat.Nodes;

namespace Watsug.JcShellFormat
{
    public class JcShellFormat : IEvaluate
    {
        private string _expr;
        private IDictionary<string, string> _dict;
        private IExpressionNode _node;

        public JcShellFormat(string expr, IDictionary<string, string> dict = null)
        {
            _expr = expr;
            _dict = dict;
        }

        public string Evaluate()
        {
            _node = new TextNode(null);
            foreach (char c in _expr)
            {
                switch (c)
                {
                    case Tokens.VariableMark:
                        _node = new VariableNode(_node, _dict);
                        break;

                    case Tokens.LengthMark:
                        _node = new LengthNode(_node);
                        break;
                    case Tokens.LengthBerMark:
                        _node = new BerLengthNode(_node);
                        break;

                    default:
                        _node = _node.Push(c);
                        break;
                }
            }

            return _node.Evaluate();
        }
    }
}