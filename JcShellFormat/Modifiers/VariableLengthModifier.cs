namespace Watsug.JcShellFormat.Modifiers
{
    public class VariableLengthModifier : BaseModifier
    {
        public VariableLengthModifier(string formatParameters)
            : base(formatParameters)
        {
        }

        public override string Transform(string text)
        {
            return text.Length.ToString("D");
        }
    }
}