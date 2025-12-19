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
            choice = InputHelper.Ask("(A) Tower Menu. (D) Scout Enemy. (C) Continue.", "a", "d", "c");
            ProcessCycleMenu(choice);
            Logger.Log("Choose Menu", "CycleMenu", "ProcessMenu", $"Player opened CyclemMenu and picked {choice}");

        }

        public void MainMenu()
        {
            choice = InputHelper.Ask("(A) Basic Attack. (B) Skill. (C) Ultimate. (D) Scout Enemy.", "a", "b", "c", "d");
            ProcessMainMenu(choice);
            Logger.Log("Choose Menu", "MainMenu", "ProcessMenu", $"Player opened MainMenu and picked {choice}");

        }

        public void ProcessMainMenu(string input)
        {
            switch (input)
            {
                case "a":
                    BasicAttack();
                    break;
                case "b":
                    Skill();
                    break;
                case "c":
                    Ultimate();
                    break;
                case "d":
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
                case "d":
                    ScoutEnemyMenu();
                    break;
                case "c":
                    Console.WriteLine("Skipped turn.");
                    break;
                default:
                    return;
            }
        }

        public void BasicAttack()
        {
            Console.WriteLine("Choose an enemy to attack: ");
            DisplayEnemyState();
            choice = InputHelper.PickEnemy(GetAliveEnemies());
        }

        public void Skill()
        {

        }

        public void Ultimate()
        {

        }

        public void TowerMenu()
        {
            Console.WriteLine("You did a Tower Menu!");
        }

        public void DisplayEnemyState()
        {
            for (int i = 0; i < GameState.EnemyMax; i++)
            {
                if (state.EnemySlots[i] != null)
                {
                    Console.WriteLine($"[{i}] " + state.EnemySlots[i].Name + $" {state.EnemySlots[i].Health} HP");
                }
                else
                {
                    Console.WriteLine($"[{i}]" + " This slot is empty");
                }

            }
        }

        public void ScoutEnemyMenu()
        {
            DisplayEnemyState();
        }

        public string[] GetAliveEnemies()
        {
            var validChoices = new List<string>();
            for (int i = 0; i < GameState.EnemyMax; i++)
            {
                if (state.EnemySlots[i] != null)
                {
                    validChoices.Add(i.ToString());
                }
            }

            return validChoices.ToArray();
        }
    }
}
