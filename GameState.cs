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

        public Tower[] TowerSlots = new Tower[5];
        public Enemy[] EnemySlots = new Enemy[9];

        public void AddTower(string type)
        {
            if (GameConfig.Tower.TryGetValue(type.ToLower(), out var config))
            {
                var tower = new Tower(config);
                Towers.Add(tower);
                AddTowerToBoard(tower);
                Logger.Log("AddTower", "GameState", "GameState", "A player has added a tower.");

            }
            else
            {
                Logger.Log("AddTower", "GameState", "GameState", "Tower Add failed.");
            }
        }

        public void AddEnemy(string type)
        {
            if (GameConfig.Enemy.TryGetValue(type.ToLower(), out var config))
            {
                var enemy = new Enemy(config);
                Enemies.Add(enemy);
                AddEnemyToBoard(enemy);
                Logger.Log("Spawn Enemy", "GameState", "GameState", "Enemy spawned.");
            }
        }

        public void AddTowerToBoard(Tower tower)
        {

            for (int i = 0; i < 5; i++)
            {
                if (TowerSlots[i] == null)
                {
                    TowerSlots[i] = tower;
                    return;
                }
            }

        }

        public void AddEnemyToBoard(Enemy enemy)
        {

            for (int i = 0; i < 9; i++)
            {
                if (EnemySlots[i] == null)
                {
                    EnemySlots[i] = enemy;
                    return;
                }
            }

        }

    }
}
