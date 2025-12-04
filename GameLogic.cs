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
                unit.LeftOverTurn = LeftOverTurn;
            }
        }
    }
}
