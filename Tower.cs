using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal class Tower
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public List<TowerAbility> Abilities { get; set; }
        public int ActionValue { get; set; }
        public double LeftOverTurn { get; set; }
        public Tower(TowerConfig config)
        {
            ID = config.ID;
            Name = config.Name;
            Attack = config.Attack;
            Speed = config.Speed;
            Level = config.Level;
            Abilities = config.Abilities;
        }
    }
}
