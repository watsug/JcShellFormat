namespace Watsug.JcShellFormat.Modifiers
{
    public class UppercaseModifier : BaseModifier
    {
        public UppercaseModifier(string formatParameters)
            : base(formatParameters)
        {
        }

        public override string Transform(string text)
        {
            return text.ToUpper();
        }
    }
}