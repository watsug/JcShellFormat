using System.Text;
using Watsug.JcShellFormat.Util;

namespace Watsug.JcShellFormat.Nodes
{
    public class AsciiToHexNode : BaseNode
    {
        public AsciiToHexNode(IExpressionNode parent) : base(parent)
        {
        }

        public override string Evaluate()
        {
            var tmp = base.Evaluate();
            return HexEncoding.BinToHex(Encoding.ASCII.GetBytes(tmp));
        }
    }
}