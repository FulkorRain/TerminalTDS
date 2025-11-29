using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal class GameState
    {

        public bool GameOn = true;
        public bool PlayerAlive = true;
        public int TurnCount = 0;

        public List<Tower> Towers = new();
        public List<Enemy> Enemies = new();

        public void AddTower(string type)
        {
            if (GameConfig.Tower.TryGetValue(type.ToLower(), out var config))
            {
                Towers.Add(new Tower(config));
                Logger.Log("", "", "", "");

            }
            else
            {
                Logger.Log("", "", "", "");
            }
        }

        public void AddEnemy(string type)
        {
            if (GameConfig.Enemy.TryGetValue(type.ToLower(), out var config))
            {
                Enemies.Add(new Enemy(config));
                Logger.Log("Spawn Enemy", "Engine", type, "Enemy spawned.");
            }
        }

    }
}
