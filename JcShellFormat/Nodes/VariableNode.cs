using System.Collections.Generic;

namespace Watsug.JcShellFormat.Nodes
{
    public class VariableNode : BaseNode
    {
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
                return _parent;
            }

            return base.Push(c);
        }

        public override string Evaluate()
        {
            string tmp = base.Evaluate();
            if (!_dict.ContainsKey(tmp))
            {
                throw new JcShellFormatException($"Variable not found in the dictionary: {tmp}!");
            }

            return _dict[tmp];
        }
    }
}