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
            // Working on Singleplayer version of this game right now, Player vs AI, expanding into P2P co-op vs AI later.
            // Folder structure: (This) Program.cs , GameState.cs , GameLogic.cs , GameConfing.cs , Engine.cs 
            // Engine.cs Handles the main loop
            // GameLogic.cs Handles caluclations, damage, healing, buying and selling towers, enemies dying, attacks etc.
            // GameState.cs Handles the CURRENT state of this turn , has all information needed for this turn, useful later too for online sync / integration
            // GameConfig.cs Handles most of the constant values, like tower types, names, hp, atk etcc


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