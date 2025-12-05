using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal class GameLogic
    {

        private GameState state;
        private Engine engine;
        public GameLogic(GameState state, Engine engine)
        {
            this.state = state;
            this.engine = engine;
        }

        public void DealDMG(double DMGAmount)
        {

        }

        public void InitActionValue()
        {
            var units = state.GetAllUnits().ToList();

            if (units.Count == 0)
            {
                return;
            }

            foreach (var unit in units)
            {
                double SPDFormula = (double)unit.Speed / 100;
                int ActionValue = (int)Math.Floor(SPDFormula);
                double LeftOverTurn = SPDFormula - ActionValue;

                unit.ActionValue = ActionValue;
                unit.LeftOverTurn += LeftOverTurn;
                Logger.Log("ActionValue Calculated", "GameLogic-InitActionValue", unit.Name, $"ActionValue: {ActionValue} -> {unit.ActionValue}");
                Logger.Log("LeftOverTurn Calculated", "GameLogic-InitActionValue", unit.Name, $"LeftOverTurn: {LeftOverTurn} -> {unit.LeftOverTurn}");

                if (unit.LeftOverTurn >= 1)
                {
                    int BonusTurns = (int)Math.Floor(unit.LeftOverTurn);
                    unit.LeftOverTurn -= BonusTurns;
                    unit.ActionValue += BonusTurns;
                    Logger.Log("ActionValue Calculated (Leftover)", "GameLogic-InitActionValue", unit.Name, $"ActionValue: {unit.ActionValue - BonusTurns} -> {unit.ActionValue}");
                    Logger.Log("LeftOverTurn Calculated (Leftover)", "GameLogic-InitActionValue", unit.Name, $"LeftOverTurn: {unit.LeftOverTurn + BonusTurns} -> {unit.LeftOverTurn}");
                }
            }
        }

        public void InitCycle()
        {
            var units = state.GetAllUnits().ToList();

            if (units.Count == 0)
            {
                return;
            }

            InitActionValue();

            List<dynamic> queue = new List<dynamic>();

            foreach (var unit in units)
            {
                for (int i = 0; i < unit.ActionValue; i++)
                {
                    queue.Add(unit);
                }
            }

            ExecuteQueue(queue);
        }

        public void ExecuteQueue(List<dynamic> queue)
        {
            foreach (var unit in queue)
            {
                ExecuteTurns(unit);
            }
        }

        public void ExecuteTurns(dynamic unit)
        {

            if (unit is Tower t)
            {
                ExecuteTurnTower(t);
            }
            else if (unit is Enemy e)
            {
                ExecuteEnemyTower(e);
            }

        }

        public void ExecuteTurnTower(Tower tower)
        {
            engine.AttackMenu();
        }

        public void ExecuteEnemyTower(Enemy enemy)
        {
            Console.WriteLine($"{enemy.Name} has restored 5 HP!");
            enemy.Health += 5;
        }

    }
}
