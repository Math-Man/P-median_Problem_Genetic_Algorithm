using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Median_Problem
{
    public class Logger
    {
        private List<string> Lines { get; }
        public string CurrentLine { get; set; }

        public Logger()
        {
            Lines = new List<string>();
        }

        /// <summary>
        /// Adds a complete line to the list of lines
        /// </summary>
        /// <param name="text"></param>
        public void AddLine(string text)
        {
            Lines.Add(text);
        }

        /// <summary>
        /// Adds a word to the current line, adds a spacebar between every added word
        /// </summary>
        /// <param name="word"></param>
        public void AddWord(string word)
        {
            CurrentLine += word + " ";
        }

        /// <summary>
        /// Adds the current line to the list of lines, wipes out the current line
        /// </summary>
        public void PushCurrentLine()
        {
            Lines.Add(CurrentLine);
            CurrentLine = "";
        }

        /// <summary>
        /// Builds the string from list of lines
        /// </summary>
        /// <returns></returns>
        public string GiveCompleteString()
        {
            string outputString = "";

            foreach (string s in Lines)
            {
                outputString += s + "\n";
            }

            return outputString;

        }

        public void clearLines()
        {
            Lines.Clear();
        }

    }
}
