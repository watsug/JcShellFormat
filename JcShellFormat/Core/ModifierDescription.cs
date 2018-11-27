using System;

namespace Watsug.JcShellFormat.Core
{
    public abstract class ModifierDescription
    {
        protected readonly string _token;
        protected readonly Type _implementation;

        protected ModifierDescription(string token, Type implementation)
        {
            _token = token;
            _implementation = implementation;
        }

        public abstract IVariableModifier CreateInstance(string format);
    }
}