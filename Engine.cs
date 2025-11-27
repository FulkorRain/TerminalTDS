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

        public Engine()
        {
            state = new GameState();
            logic = new GameLogic(state);
        }

        public void Run()
        {
            while (state.GameOn)
            {
                
            }
        }
    }
}
