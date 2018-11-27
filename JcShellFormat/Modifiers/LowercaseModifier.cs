namespace Watsug.JcShellFormat.Modifiers
{
    public class LowercaseModifier : BaseModifier
    {
        public LowercaseModifier(string formatParameters)
        : base(formatParameters)
        {
        }

        public override string Transform(string text)
        {
            return text.ToLower();
        }
    }
}