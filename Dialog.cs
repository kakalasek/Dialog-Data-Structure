using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dialog_Data_Structure
{

    //NOTE: I HATE C#! I really do. Easily the most annoying damn language I have ever seen. A crybaby with all of its restrictions. Wanted to kill myself several times doing this homework...

    public class Dialog
    {

        public static void SerializeJSON(Dialog dialog, String filePath)
        {
            var jsonString = JsonConvert.SerializeObject(dialog);
            File.WriteAllText(filePath, jsonString);
        }

        public static Dialog DeserializeJSON(String filePath)
        {
            String JSONString = File.ReadAllText(filePath);
            if (JSONString != null)
            {
                return JsonConvert.DeserializeObject<Dialog>(JSONString);
            }
            else throw new ArgumentException("File provided is empty");
        }


        private String text;    // Text of the dialog
        private Dictionary<String, Dialog?> options; // Available dialog responses <Response Text; if a subsequent dialog exists for the response, a pointer to that dialog (can be null if no subsequent dialog exists)>

        public Dialog(string text)
        {
            this.text = text;
            options = new Dictionary<String, Dialog?>();
        }

        public String Text { get => text; set => text = value; }
        public Dictionary<String, Dialog?> Options { get => options; }

        /// <summary>
        /// Method which add a new dialog option
        /// </summary>
        /// <param name="text">Text of the option</param>
        /// <param name="next">Subsequent dialog, if any (may be null)</param>
        public void AddOption(String text, Dialog? next)
        {
            options.Add(text, next);
        }

        /// <summary>
        /// Check if the dialog has any options
        /// </summary>
        /// <returns>True if there are options, False if there arent any</returns>
        public bool hasOptions()
        {
            return options.Count > 0;
        }

        /// <summary>
        /// Returns the whole dialog with options as a concatenated String
        /// </summary>
        /// <returns>Dialog text with all options, if any</returns>
        public String Get()
        {
            String output = text;
            if (hasOptions())
            {
                output += "\n";
                foreach (var option in options)
                {
                    output += "\n" + option.Key;
                }
            }
            return output;
        }

        /// <summary>
        /// Returns all the options, if any, as a concatenated String
        /// </summary>
        /// <returns>Text of all options, if any. If there arent any options, returns null</returns>
        public String? GetOptions()
        {
            String output = "";
            if (hasOptions())
            {
                foreach (var option in options)
                {
                    output += option.Key + "\n";
                }
            }
            return output;
        }

        /// <summary>
        /// Used to continue the dialog, by repeatedly providing options
        /// </summary>
        /// <param name="option">The chosen option for this dialog</param>
        /// <returns>The dialog subsequent for the provided option, if any (may return null)</returns>
        /// <exception cref="ArgumentException">If the chosen option is not valid, i. e. if it does not exist within the dialog options</exception>
        public Dialog? Next(String option)
        {
            if (!options.ContainsKey(option)) throw new ArgumentException("Option provided does not exist within this dialog!");
            return options[option];
        }
    }
}
