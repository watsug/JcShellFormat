using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Watsug.JcShellFormat.Nodes;

namespace Watsug.JcShellFormat
{
    public class JcShellFormat : IEvaluate
    {
        private readonly string _expr;
        private readonly Func<string, string> _resolver;
        private readonly Options _options = Options.None;

        [Flags]
        public enum Options
        {
            None = 0x00,
            KeyAsValueIfNotResolved = 0x01,
            LegacyVariables = 0x02
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
                _resolver = (v) =>
                {
                    if (!dict.ContainsKey(v))
                    {
                        throw new JcShellFormatException($"Key not found: {v}!");
                    }
                    return dict[v];
                };
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

            for(int i=0; i < _expr.Length; i++)
            {
                IExpressionNode tmp = null;

                switch (_expr[i])
                {
                    case Tokens.VariableMark:
                    {
                        // the next character exists, and is '{'
                        if (i + 1 < _expr.Length && _expr[i + 1] == Tokens.VariableStart)
                        {
                            // skip '{' - it belongs to '$'
                            tmp = new VariableNode(node, Resolve);
                            i++;
                        }
                        else
                        {
                            node = node.Push(_expr[i]);
                        }

                    } break;

                    case Tokens.VariableStart:
                        if (!_options.HasFlag(Options.LegacyVariables))
                        {
                            throw new JcShellFormatException("Legacy variables format is not enabled!");
                        }

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
                        node = node.Push(_expr[i]);
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