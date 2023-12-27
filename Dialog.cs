using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialog_Data_Structure
{
    public class Dialog
    {
        private String text;    // Text of the dialog
        private Dictionary<String, Dialog> options; // Available dialog responses <Response Text; if a subsequent dialog exists for the response, a pointer to that dialog (can be null if no subsequent dialog exists)>

        public Dialog()
        {

        }

        public Dialog(string text)
        {
            this.text = text;
            options = new Dictionary<String, Dialog>();
        }

        public String Text { get => text; set => text = value; }

        /// <summary>
        /// Method which add a new dialog option
        /// </summary>
        /// <param name="text">Text of the option</param>
        /// <param name="next">Subsequent dialog, if any (may be null)</param>
        public void AddOption(String text, Dialog? next)
        {
            options.Add(text, next);
        }
    }
}
