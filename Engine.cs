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
            Logger.Log("Choose Menu", "ShowMenu", "ProcessMenu", $"Player opened Main Menu and picked {choice}");

        }

        private void ProcessMenu(string input)
        {
            switch (input)
            {
                case "a":
                    AttackMenu();
                    break;
                case "b":
                    TowerMenu();
                    break;
                case "c":
                    ScoutEnemyMenu();
                    break;
            }
        }

        private void AttackMenu()
        {

        }

        private void TowerMenu()
        {

        }

        private void ScoutEnemyMenu()
        {

        }
    }
}
