using System;
using System.Collections.Generic;
using Watsug.JcShellFormat.Core;
using Watsug.JcShellFormat.Modifiers;

namespace Watsug.JcShellFormat.Nodes
{
    public class VariableNode : BaseNode
    {
        public const char Separator = ';';
        private Func<string, string> _resolver;

        public VariableNode(IExpressionNode parent, Func<string, string> resolver) : base(parent)
        {
            _resolver = resolver;
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

                var tmpData = split[0].Trim();
                var data = _resolver(tmpData);
                if (data == null)
                {
                    throw new JcShellFormatException($"Unable to resolve the key value: {tmpData}!");
                }

                string format = split[1].Trim();
                foreach (var md in modifiers)
                {
                    IVariableModifier vm = md.CreateInstance(format);
                    if (vm != null)
                    {
                        return vm.Transform(data);
                    }
                }
                throw new JcShellFormatException($"Unsupported format: {format}!");
            }

            var ret = _resolver(tmp);
            if (ret == null)
            {
                throw new JcShellFormatException($"Variable not found in the dictionary: {tmp}!");
            }

            return ret;
        }

        private static List<ModifierDescription> modifiers;

        static VariableNode()
        {
            modifiers = new List<ModifierDescription>
            {
                new MatchModifierDescription(VariableModifiers.VariableLength, typeof(VariableLengthModifier)),
                new StartsWithModifierDescription(VariableModifiers.VariableToHex, typeof(VariableToHexModifier)),
                new StartsWithModifierDescription(VariableModifiers.Substring, typeof(SubstringModifier)),
                new MatchModifierDescription(VariableModifiers.Lowercase, typeof(LowercaseModifier)),
                new MatchModifierDescription(VariableModifiers.Uppercase, typeof(UppercaseModifier))
            };
        }
    }
}