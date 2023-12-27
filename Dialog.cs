using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialog_Data_Structure
{
    public class Dialog
    {
        private String text;
        private Dictionary<String, Dialog> options;

        public Dialog()
        {

        }

        public Dialog(string text)
        {
            this.text = text;
            options = new Dictionary<String, Dialog>();
        }

        public String Text { get => text; set => text = value; }

        public void AddOption(String text, Dialog? next)
        {
            options.Add(text, next);
        }
    }
}
