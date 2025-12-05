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
        public int PlayerHP = 1000;
        public int TurnCount = 0;
        public const int EnemyMax = 9;
        public const int TowerMax = 5;

        public List<Tower> Towers = new();
        public List<Enemy> Enemies = new();

        public Tower[] TowerSlots = new Tower[TowerMax];
        public Enemy[] EnemySlots = new Enemy[EnemyMax];
        public List<int> TurnOrder = new();

        public void AddTower(string type)
        {
            if (GameConfig.Tower.TryGetValue(type.ToLower(), out var config))
            {
                var tower = new Tower(config);
                Towers.Add(tower);
                AddTowerToBoard(tower);
                Logger.Log("AddTower", "GameState", "TowerSlots", $"A Player has added {tower.Name} to TowerSlots");

            }
            else
            {
                Logger.Log("AddTower", "GameState", "General", $"Tower Add failed.");
            }
        }

        public void AddEnemy(string type)
        {
            if (GameConfig.Enemy.TryGetValue(type.ToLower(), out var config))
            {
                var enemy = new Enemy(config);
                Enemies.Add(enemy);
                AddEnemyToBoard(enemy);
            }
        }

        public void AddTowerToBoard(Tower tower)
        {

            for (int i = 0; i < TowerMax; i++)
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

            for (int i = 0; i < EnemyMax; i++)
            {
                if (EnemySlots[i] == null)
                {
                    EnemySlots[i] = enemy;
                    Logger.Log("AddEnemyToBoard", "AddEnemy", "EnemySlots", $"Enemy {enemy.Name} spawned.");
                    return;
                }
            }

        }

        public IEnumerable<dynamic> GetAllUnits()
        {
            foreach (var t in TowerSlots)
            {
                if (t != null)
                {
                    yield return t;
                }
            }

            foreach (var e in EnemySlots)
            {
                if (e != null)
                {
                    yield return e;
                }
            }
        }

    }
}
