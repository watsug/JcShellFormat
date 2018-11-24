namespace Watsug.JcShellFormat.Nodes
{
    public class TextNode : BaseNode
    {
        public TextNode(IExpressionNode parent) : base(parent)
        {
        }

        public TextNode(IExpressionNode parent, string buff) : base(parent)
        {
            _buff.Append(buff);
        }
    }
}