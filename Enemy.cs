using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public List<EnemyAbility> Abilities { get; set; }

        public Enemy(EnemyConfig config)
        {
            Name = config.Name;
            Health = config.Health;
            Defense = config.Defense;
            Attack = config.Attack;
            Speed = config.Speed;
            Level = config.Level;
            Abilities = config.Abilities;
        }

    }
}
