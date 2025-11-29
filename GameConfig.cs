using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal static class GameConfig
    {
        public static readonly Dictionary<string, TowerConfig> Tower = new()
        {
            ["archer"] = new TowerConfig
            {
                Name = "Flame-Arrow Archer",
                Attack = 5,
                Speed = 135,
                level = 1,
                Abilities = new List<TowerAbility>
                {
                    TowerAbility.None
                }
            },

            ["mage"] = new TowerConfig
            {
                Name = "Frost Mage",
                Attack = 3,
                Speed = 98,
                level = 1,
                Abilities = new List<TowerAbility>
                {
                    TowerAbility.None
                }
            }
        };

        public static readonly Dictionary<string, EnemyConfig> Enemy = new()
        {
            ["goblin"] = new EnemyConfig
            {
                Name = "Goblin",
                Health = 4,
                Defense = 0,
                Attack = 3,
                Speed = 121,
                level = 1,
                Abilities = new List<EnemyAbility>
                {
                    EnemyAbility.None
                }
            },

            ["orc"] = new EnemyConfig
            {
                Name = "Orc",
                Health = 13,
                Defense = 1,
                Attack = 10,
                Speed = 50,
                level = 1,
                Abilities = new List<EnemyAbility>
                {
                    EnemyAbility.None
                }
            }
        };
    }

    internal class TowerConfig
    {
        public required string Name { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int level { get; set; }

        public required List<TowerAbility> Abilities { get; set; }

    }

    public enum TowerAbility
    {
        None,
    }

    internal class EnemyConfig
    {

        public required string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int level { get; set; }

        public required List<EnemyAbility> Abilities { get; set; }


    }

    public enum EnemyAbility
    {
        None,
        TimedDeath,
        OnDeath,
    }
}
