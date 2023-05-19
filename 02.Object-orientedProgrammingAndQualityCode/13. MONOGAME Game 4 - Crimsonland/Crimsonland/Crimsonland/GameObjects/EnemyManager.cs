namespace Crimsonland
{
    using Crimsonland.GameObjects;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using RogueSharp;
    using System;
    using System.Collections.Generic;

    class EnemyManager
    {
        private List<Enemy> enemies;

        private IMap map;
        private ContentManager Content;

        public DateTime nextSpawn;
        public TimeSpan spawnDelay = new TimeSpan(0, 0, 0, 1, 0);

        public EnemyManager(ContentManager content, IMap map)
        {
            this.Content = content;
            this.map = map;
            this.enemies = new List<Enemy>();
        }

        public void Update(Cell randomCell, Player player)
        {
            if(nextSpawn<= DateTime.Now)
            {
                nextSpawn = DateTime.Now + spawnDelay;
                this.GenerateEnemy(randomCell, player);
            }

            foreach (var enemy in enemies)
            {
                enemy.Update(this.map);

                foreach (var bullet in player.bullets)
                {
                    if(bullet.CalculateBulletBounds().Intersects(enemy.CalculateEnemyBounds()) && enemy.isAlive)
                    {
                        enemy.Die();
                        bullet.Hit();
                    }
                }
                if(enemy.isAttacking)
                {
                    player.ReceiveDamage();
                }
            }
            this.HandleEnemies();
        }

        public void GenerateEnemy(Cell randomCell, Player player)
        {
            var pathFromEnemy = new PathFinding(player, this.map);
            pathFromEnemy.CreateFrom(randomCell.X, randomCell.Y);

            Enemy enemy = new Enemy(Content, pathFromEnemy, player, randomCell.X, randomCell.Y, 0.5f);
            this.enemies.Add(enemy);
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (var enemy in enemies)
            {
                if(this.map.IsInFov(enemy.X, enemy.Y))
                {
                    enemy.Draw(spriteBatch);
                }
            }
        }

        public void HandleEnemies()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                if (!this.enemies[i].isAlive)
                {
                    this.enemies.Remove(this.enemies[i]);
                    i--;
                }
            }
        }

    }
}
