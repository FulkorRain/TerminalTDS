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
            if (state.TurnCount == 0)
            {
                Console.WriteLine("TerminalTDS 1.0");
                choice = InputHelper.Ask("Choose your starter tower: (A) Archer. (B) Mage. ", "a", "b");
                if (choice == "a") state.AddTower("archer"); else state.AddTower("mage");
                state.AddEnemy("Goblin");
            }

            while (state.GameOn)
            {
                state.AddEnemy("goblin");
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
            for (int i = 0; i < 9; i++)
            {
                if (state.EnemySlots[i] != null)
                {
                    Console.WriteLine(state.EnemySlots[i].Name + $"[{i}]");
                }
                else
                {
                    Console.WriteLine($"[{i}]" + " This slot is empty");
                }
                
            }
        }
    }
}
