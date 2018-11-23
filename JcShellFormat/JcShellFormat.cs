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
            foreach (char c in _expr)
            {
                switch (c)
                {
                    case Tokens.VariableMark:
                        _node = new VariableNode();
                        break;

                    case Tokens.LengthMark:
                        _node = new LengthNode();
                        break;
                    case Tokens.LengthBerMark:
                        _node = new BerLengthNode();
                        break;

                    case Tokens.VariableStart:
                    case Tokens.VariableEnd:
                    case Tokens.LengthStart:
                    case Tokens.LengthEnd:
                        if (_node == null)
                        {
                            throw new JcShellFormatException($"Unexpected character found: '{c}'!");
                        }
                        _node = _node.Push(c);
                        break;

                    default:
                        if (_node == null)
                        {
                            _node = new TextNode();
                        }
                        _node = _node.Push(c);
                        break;
                }
            }

            return _node.Evaluate();
        }
    }
}