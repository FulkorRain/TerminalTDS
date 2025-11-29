using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal class Engine
    {
        private GameState state;
        private GameLogic logic;
        private string choice = "";

        public Engine()
        {
            state = new GameState();
            logic = new GameLogic(state);
            Logger.LoggerSetState(state);
        }

        public void Run()
        {
            while (state.GameOn)
            {
                ShowMenu();
            }
        }

        private void ShowMenu()
        {
            choice = InputHelper.Ask("(A) Attack Menu. (B) Tower Menu. (C) Scout Enemy.", "a", "b", "c");
            ProcessMenu(choice);

        }

        private void ProcessMenu(string input)
        {
            
        }
    }
}
