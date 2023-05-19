using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PooyanGame1.GameObjects.Entities;
using PooyanGame1.Utils;
using System.Collections.Generic;

namespace PooyanGame1.GameObjects.Managers
{
    public static class EnemyManager
    {
        public static int EnemiesKilled { get; set; } = 0;

        public static List<Texture2D> EnemyTextures { get; set; } = new List<Texture2D>();

        private static List<Enemy> Enemies { get; set; } = new List<Enemy>();

        private static float SpawnTimer { get; set; } = 0;

        public static void Update(GameTime gameTime)
        {
            EnemyManager.SpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (EnemyManager.SpawnTimer >= 1)
            {
                EnemyManager.GenerateEnemy();
                EnemyManager.SpawnTimer = 0;
            }

            foreach (var enemy in EnemyManager.Enemies)
            {
                enemy.Update(gameTime);

                foreach (var arrow in ArrowManager.Arrows)
                {
                    if (arrow.ArrowBounds().Intersects(enemy.CalculateEnemyBounds())
                        && enemy.IsAlive)
                        {
                        if (arrow.ArrowBounds().Intersects(enemy.CalculateBalloonBounds()))
                        {
                            enemy.Die();
                            arrow.Hit();
                            EnemyManager.EnemiesKilled++;
                        }
                        else
                        {
                            arrow.Deflect();
                        }
                    }
                }
            }
        }

        public static void GenerateEnemy()
        {
            int positionX = Globals.RNG.Next(1, Globals.ENEMY_MIN_POSITION_X);

            EnemyManager.Enemies.Add(new Enemy(EnemyTextures[0], EnemyTextures[1],
                EnemyTextures[2], EnemyTextures[3], EnemyTextures[4],
                Globals.RNG.Next(Globals.ENEMY_MIN_SPEED, Globals.ENEMY_MAX_SPEED),
                new Vector2(-positionX, Globals.RNG.Next(Globals.ENEMY_MIN_POS_Y, Globals.ENEMY_MAX_POS_Y))));
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in EnemyManager.Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
