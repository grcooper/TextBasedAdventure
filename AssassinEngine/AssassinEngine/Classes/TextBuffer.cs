using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssassinEngine
{
    static class TextBuffer
    {
        private static string outputBuffer;

        //tells us that we should add the text we need to the output buffer, then place a new line
        public static void Add(string text)
        {
            outputBuffer += text + "\n";


        }

        public static void Display()
        {
            //whenever we display we clear the console so it does not fill up with code
            Console.Clear();

            //we need to word wrap what we see.
            Console.Write(TextUtils.WordWrap(outputBuffer, Console.WindowWidth));

            //this is what is written after every line to prompt the player to continue
            Console.WriteLine("What shall I do?");
            Console.Write(">");

            outputBuffer = "";
        }
    }
}
