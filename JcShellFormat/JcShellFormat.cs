using System.Collections.Generic;
using Watsug.JcShellFormat.Nodes;

namespace Watsug.JcShellFormat
{
    public class JcShellFormat : IEvaluate
    {
        private string _expr;
        private IDictionary<string, string> _dict;

        public JcShellFormat(string expr, IDictionary<string, string> dict = null)
        {
            _expr = expr;
            _dict = dict;
        }

        public string Evaluate()
        {
            IExpressionNode root = new TextNode(null);
            IExpressionNode node = root;

            foreach (char c in _expr)
            {
                IExpressionNode tmp = null;
                switch (c)
                {
                    case Tokens.VariableMark:
                        tmp = new VariableNode(node, _dict);
                        break;

                    case Tokens.LengthMark:
                        tmp = new LengthNode(node);
                        break;

                    case Tokens.LengthBerMark:
                        tmp = new BerLengthNode(node);
                        break;

                    case Tokens.AsciiToHex:
                        if (node is AsciiToHexNode)
                        {
                            node = node.Parent;
                        }
                        else
                        {
                            tmp = new AsciiToHexNode(node);
                        }
                        break;

                    default:
                        node = node.Push(c);
                        break;
                }

                if (tmp != null)
                {
                    node.Push(tmp);
                    node = tmp;
                }
            }

            return root.Evaluate();
        }
    }
}