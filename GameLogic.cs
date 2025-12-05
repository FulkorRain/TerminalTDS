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
        public GameLogic(GameState state)
        {
            this.state = state;
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

            foreach(var unit in units)
            {
                double SPDFormula = (double)unit.Speed / 100;
                int ActionValue = (int)Math.Floor(SPDFormula);
                double LeftOverTurn = SPDFormula - ActionValue;

                unit.ActionValue = ActionValue;
                unit.LeftOverTurn += LeftOverTurn;
                Logger.Log("ActionValue Calculated", "GameLogic-InitActionValue", unit.name, $"ActionValue: {ActionValue} -> {unit.ActionValue}");
                Logger.Log("LeftOverTurn Calculated", "GameLogic-InitActionValue", unit.name, $"LeftOverTurn: {LeftOverTurn} -> {unit.LeftOverTurn}");

                if (unit.LeftOverTurn >= 1)
                {
                    int BonusTurns = (int)Math.Floor(unit.LeftOverTurn);
                    unit.LeftOverTurn -= BonusTurns;
                    unit.ActionValue += BonusTurns;
                    Logger.Log("ActionValue Calculated (Leftover)", "GameLogic-InitActionValue", unit.name, $"ActionValue: {unit.ActionValue - BonusTurns} -> {unit.ActionValue}");
                    Logger.Log("LeftOverTurn Calculated (Leftover)", "GameLogic-InitActionValue", unit.name, $"LeftOverTurn: {unit.LeftOverTurn + BonusTurns} -> {unit.LeftOverTurn}");
                }
            }
        }
    }
}
