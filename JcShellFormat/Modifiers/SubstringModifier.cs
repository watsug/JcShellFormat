using System;

namespace Watsug.JcShellFormat.Modifiers
{
    public class SubstringModifier : BaseModifier
    {
        public SubstringModifier(string formatParameters)
            : base(formatParameters)
        {
        }

        public override string Transform(string text)
        {
            var p = FormatParameters.Split(',');
            int off = int.Parse(p[0]);
            if (off < 0 || off > text.Length)
            {
                throw new ArgumentOutOfRangeException($"Out of range offset: {off} (0 - {text.Length})!");
            }
            int len = -1;
            if (p.Length > 1)
            {
                len = int.Parse(p[1]);
            }

            if (len < 0)
            {
                len = text.Length - off;
            }

            if (off + len > text.Length)
            {
                throw new ArgumentOutOfRangeException($"Out of range length: {len} (0 - {text.Length - off})!");
            }

            return text.Substring(off, len);
        }
    }
}