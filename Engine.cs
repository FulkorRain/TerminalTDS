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
            logic = new GameLogic(state, this);
            Logger.LoggerSetState(state);
        }

        public void Run()
        {
            if (state.TurnCount == 0)
            {
                Console.WriteLine("TerminalTDS 1.0");
                choice = InputHelper.Ask("Choose your starter tower: (A) Archer. (B) Mage. ", "a", "b");
                if (choice == "a") state.AddTower("archer"); else state.AddTower("mage");
                state.AddEnemy("goblin");
            }

            while (state.GameOn)
            {
                state.TurnCount += 1;
                CycleMenu();
                logic.InitCycle();
            }
        }

        public void CycleMenu()
        {
            choice = InputHelper.Ask("(A) Tower Menu. (B) Scout Enemy. (C) Continue.", "a", "b", "c");
            ProcessCycleMenu(choice);
            Logger.Log("Choose Menu", "CycleMenu", "ProcessMenu", $"Player opened CyclemMenu and picked {choice}");

        }

        public void MainMenu()
        {
            choice = InputHelper.Ask("(A) Attack Menu. (B) Scout Enemy.", "a", "b");
            ProcessMainMenu(choice);
            Logger.Log("Choose Menu", "MainMenu", "ProcessMenu", $"Player opened MainMenu and picked {choice}");

        }

        public void ProcessMainMenu(string input)
        {
            switch (input)
            {
                case "a":
                    AttackMenu();
                    break;
                case "b":
                    ScoutEnemyMenu();
                    break;
                default:
                    return;
            }
        }

        public void ProcessCycleMenu(string input)
        {
            switch (input)
            {
                case "a":
                    TowerMenu();
                    break;
                case "b":
                    ScoutEnemyMenu();
                    break;
                case "c":
                    Console.WriteLine("Skipped turn.");
                    break;
                default:
                    return;
            }
        }

        public void AttackMenu()
        {
            Console.WriteLine("You did an attack!");
        }

        public void TowerMenu()
        {
            Console.WriteLine("You did a Tower Menu!");
        }

        public void ScoutEnemyMenu()
        {
            for (int i = 0; i < GameState.EnemyMax; i++)
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
