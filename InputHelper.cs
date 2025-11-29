using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal static class InputHelper
    {

        public static string Ask(string prompt, params string[] choices)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                string input = (Console.ReadLine() ?? "").ToLower().Trim();
                if (choices.Contains(input))
                {
                    return input;
                }

                Console.WriteLine("Invalid Choice.");
            }

        }
    }
}
