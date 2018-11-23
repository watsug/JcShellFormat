using System.Collections.Generic;

namespace Watsug.JcShellFormat
{
    public class JcShellFormat : IEvaluate
    {
        private string _expr;
        private IDictionary<string, string> _dict;

        public JcShellFormat(string expr, IDictionary<string, string> dict = null)
        {
            _expr = expr;
            _dict = dict;
        }

        public string Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}