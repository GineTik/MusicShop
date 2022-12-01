using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.Utils
{
    public class HtmlContent
    {
        private string htmlContent;
        private Dictionary<string, string> values;

        public HtmlContent(string html)
        {
            htmlContent = html;
            values = new Dictionary<string, string>();
        }

        public void AppendValue(string templateValue, string value)
        {
            values.Add(templateValue, value);
        }
        public string Render()
        {
            string res = htmlContent;
            foreach (var key in values.Keys)
            {
                res = res.Replace("@" + key, values[key]);
            }

            return res;
        }
        public void ClearTemplateValues()
        {
            values.Clear();

        }
        public override string ToString()
        {
            return Render();
        }
    }
}
