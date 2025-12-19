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
                ID = "archer",
                Name = "Flame-Arrow Archer",
                Attack = 5,
                Speed = 135,
                Level = 1,
                Abilities = new List<TowerAbility>
                {
                    TowerAbility.None
                }
            },

            ["mage"] = new TowerConfig
            {
                ID = "mage",
                Name = "Frost Mage",
                Attack = 3,
                Speed = 98,
                Level = 1,
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
                ID = "goblin",
                Name = "Goblin",
                Health = 4,
                Defense = 0,
                Attack = 3,
                Speed = 121,
                Level = 1,
                Abilities = new List<EnemyAbility>
                {
                    EnemyAbility.None
                }
            },

            ["orc"] = new EnemyConfig
            {
                ID = "orc",
                Name = "Orc",
                Health = 13,
                Defense = 1,
                Attack = 10,
                Speed = 50,
                Level = 1,
                Abilities = new List<EnemyAbility>
                {
                    EnemyAbility.None
                }
            }
        };
    }

    internal class TowerConfig
    {
        public required string ID { get; set; }
        public required string Name { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }

        public required List<TowerAbility> Abilities { get; set; }

    }

    public enum TowerAbility
    {
        None,
    }

    internal class EnemyConfig
    {
        public required string ID { get; set; }
        public required string Name { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }

        public required List<EnemyAbility> Abilities { get; set; }


    }

    public enum EnemyAbility
    {
        None,
        TimedDeath,
        OnDeath,
    }
}
