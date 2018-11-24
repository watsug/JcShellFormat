using SimpleBase;
using System.Text;

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
            return Base16.EncodeUpper(Encoding.ASCII.GetBytes(tmp));
        }
    }
}