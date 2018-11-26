using System;
using System.Collections.Generic;
using System.Linq;

namespace Watsug.JcShellFormat.Nodes
{
    public class VariableNode : BaseNode
    {
        public const char Separator = ';';
        public const string IntegerHexFormatting = "h";
        private IDictionary<string, string> _dict;

        public VariableNode(IExpressionNode parent, IDictionary<string, string> dict) : base(parent)
        {
            if (dict == null)
            {
                throw new JcShellFormatException("No dictionary provided!");
            }
            _dict = dict;
        }

        public override IExpressionNode Push(char c)
        {
            if (Tokens.VariableStart == c)
            {
                // skip start node
                // TODO: check if it is first token!
                return this;
            }

            if (Tokens.VariableEnd == c)
            {
                // the end of this node
                return Parent;
            }

            return base.Push(c);
        }

        public override string Evaluate()
        {
            string tmp = base.Evaluate();
            if (tmp.IndexOf(Separator) >= 0)
            {
                string[] split = tmp.Split(new char[] {Separator});
                if (split.Length != 2)
                {
                    throw new JcShellFormatException($"Unsupported format, ';' character should be included only once: {tmp}!");
                }

                string data = split[0].Trim();

                if (_dict.ContainsKey(data))
                {
                    data = _dict[data];
                }

                string format = split[1].Trim();
                if (format.StartsWith(IntegerHexFormatting))
                {
                    int length;
                    if (int.TryParse(format.Substring(1), out length))
                    {
                        long val;
                        if (Int64.TryParse(data, out val))
                        {
                            string outFormat = "X" + length.ToString();
                            return val.ToString(outFormat);
                        }
                        else
                        {
                            throw new JcShellFormatException($"Unable to parse numeric value: {data}!");
                        }
                    }
                    else
                    {
                        throw new JcShellFormatException($"Unable to parse integer/HEX length format: {format}!");
                    }
                }
                else
                {
                    throw new JcShellFormatException($"Unsupported format: {format}!");
                }
            }
            else
            {
                if (!_dict.ContainsKey(tmp))
                {
                    throw new JcShellFormatException($"Variable not found in the dictionary: {tmp}!");
                }
                return _dict[tmp];
            }
        }
    }
}