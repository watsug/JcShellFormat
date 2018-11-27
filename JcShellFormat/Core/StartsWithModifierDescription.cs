using System;

namespace Watsug.JcShellFormat.Core
{
    public class StartsWithModifierDescription : ModifierDescription
    {
        public StartsWithModifierDescription(string token, Type implementation)
            : base(token, implementation)
        {
        }

        public override IVariableModifier CreateInstance(string format)
        {
            if (!format.StartsWith(_token))
            {
                return null;
            }
            return (IVariableModifier)Activator.CreateInstance(_implementation, new object[] { format .Substring(_token.Length)});
        }
    }
}