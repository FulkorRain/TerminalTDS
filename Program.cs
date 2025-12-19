using System;
using System.IO;

namespace TerminalTDS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TerminalTDS 1.0
            Console.WriteLine("TerminalTDS 1.0");


            Console.WriteLine("All decisions would be either decided by you inputting numbers or letters which would be enclosed by (). NOT case sensitive");
            string choice = InputHelper.Ask("Start Game ? (Y) / (N) ", "y", "n");
            if (choice == "y")
            {
                Engine engine = new Engine();
                engine.Run();
            }
            else if (choice == "n") Console.WriteLine("Closing Game. . .");
            
        }
    }
}