namespace Watsug.JcShellFormat.Modifiers
{
    using Core;

    public abstract class BaseModifier : IVariableModifier
    {
        protected string FormatParameters { get; private set; }

        protected BaseModifier(string formatParameters)
        {
            FormatParameters = formatParameters;
        }

        public abstract string Transform(string text);
    }
}