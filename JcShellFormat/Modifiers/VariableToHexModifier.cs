namespace Watsug.JcShellFormat.Modifiers
{
    using System;

    public class VariableToHexModifier : BaseModifier
    {
        public VariableToHexModifier(string formatParameters)
            : base(formatParameters)
        {
        }

        public override string Transform(string text)
        {
            if (!int.TryParse(FormatParameters, out int length))
            {
                throw new JcShellFormatException($"Unable to parse format parameter: {FormatParameters}!");
            }

            if (!Int64.TryParse(text, out long val))
            {
                throw new JcShellFormatException($"Unable to parse numeric value: {text}!");
            }

            string outFormat = "X" + length;
            return val.ToString(outFormat);
        }
    }
}