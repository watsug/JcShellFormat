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
                IExpressionNode tmp = null;
                switch (c)
                {
                    case Tokens.VariableMark:
                        tmp = new VariableNode(_node, _dict);
                        break;

                    case Tokens.LengthMark:
                        tmp = new LengthNode(_node);
                        break;

                    case Tokens.LengthBerMark:
                        tmp = new BerLengthNode(_node);
                        break;

                    case Tokens.AsciiToHex:
                        if (_node is AsciiToHexNode)
                        {
                            _node = _node.Parent;
                        }
                        else
                        {
                            tmp = new AsciiToHexNode(_node);
                        }
                        break;

                    default:
                        _node = _node.Push(c);
                        break;
                }

                if (tmp != null)
                {
                    _node.Push(tmp);
                    _node = tmp;
                }
            }

            return _node.Evaluate();
        }
    }
}