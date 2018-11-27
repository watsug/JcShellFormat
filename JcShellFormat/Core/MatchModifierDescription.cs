using System;

namespace Watsug.JcShellFormat.Core
{
    public class MatchModifierDescription : ModifierDescription
    {
        public MatchModifierDescription(string token, Type implementation)
        : base(token, implementation)
        {
        }

        public override IVariableModifier CreateInstance(string format)
        {
            if(0 != String.Compare(format, _token, StringComparison.Ordinal))
            {
                return null;
            }

            // match - means no additional format parameters
            return (IVariableModifier) Activator.CreateInstance(_implementation, new object[] {""});
        }
    }
}