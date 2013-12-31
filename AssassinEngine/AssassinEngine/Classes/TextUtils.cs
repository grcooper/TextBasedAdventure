using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class TextUtils
    {
        public static string ExtractCommand(string line)
        {
            //this extracts the command, the command is the first line so we find the space.
            int index = line.IndexOf(' ');
            //if we do find a space return nothing
            if (index == -1)
                return line;
            //otherwise return the word before the space
            else
                return line.Substring(0, index);
        }

        public static string ExtractArguments(string line)
        {
            //this extracts the argument, the argument is the word after the space, we need to find the space
            int index = line.IndexOf(' ');
            //if we do not find a space return nothing
            if (index == -1)
                return "";
                //otherwise return the word before the space
            else
                return line.Substring(index +1, line.Length - index -1);
        }

        public static string WordWrap(string text, int bufferWidth)
        {
            string result = "";
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                int lineLength = 0;
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (word.Length + lineLength >= bufferWidth -1)
                    {
                        result += "\n";
                        lineLength = 0;
                    }
                    result += word + " ";
                    lineLength += word.Length + 1;
                }
                result += "\n";
            }
            return result;
            
        }

        
    }
}
