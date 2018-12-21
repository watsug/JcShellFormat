using System;
using System.Collections.Generic;
using Watsug.JcShellFormat.Nodes;

namespace Watsug.JcShellFormat
{
    public class JcShellFormat : IEvaluate
    {
        private string _expr;
        private Func<string, string> _resolver;
        private Options _options = Options.None;

        [Flags]
        public enum Options
        {
            None = 0,
            KeyAsValueIfNotResolved = 1
        }

        public JcShellFormat(string expr, Options options = Options.None)
        {
            _expr = expr;
            _options = options;
        }

        public JcShellFormat(string expr, IDictionary<string, string> dict, Options options = Options.None)
        {
            _expr = expr;
            if (dict != null)
            {
                _resolver = (v) => dict[v];
            }
            _options = options;
        }

        public JcShellFormat(string expr, Func<string, string> resolver, Options options = Options.None)
        {
            _expr = expr;
            _resolver = resolver;
            _options = options;
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
                        tmp = new VariableNode(node, Resolve);
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

                if (tmp == null) continue;
                node.Push(tmp);
                node = tmp;
            }

            return root.Evaluate();
        }

        private string Resolve(string key)
        {
            var ret = InternalResolve(key);
            return ret ?? (_options == Options.KeyAsValueIfNotResolved ? key : null);
        }

        private string InternalResolve(string key)
        {
            return _resolver?.Invoke(key);
        }
    }
}