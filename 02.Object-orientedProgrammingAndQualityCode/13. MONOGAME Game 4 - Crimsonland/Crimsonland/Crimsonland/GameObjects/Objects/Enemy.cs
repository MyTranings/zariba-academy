namespace Crimsonland.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using RogueSharp;
    using System;
    using System.Collections.Generic;

    public class Enemy : Entity
    {
        private readonly PathFinding path;
        private bool isAwareOfPlayer;

        private Player player;

        public DateTime nextMovement;
        public TimeSpan moveDelay = new TimeSpan(0, 0, 0, 0, 350);

        public DateTime nextAttack;
        public TimeSpan attackDelay = new TimeSpan(0, 0, 0, 1, 0);

        public bool isAlive = true;
        public bool isAttacking = false;

        private List<Texture2D> enemySprites;

        public Enemy(ContentManager content, PathFinding path, Player player, int x, int y, float scale)
            : base(content)
        {
            this.path = path;
            this.player = player;
            this.X = x;
            this.Y = y;
            this.Scale = scale;
            this.enemySprites = new List<Texture2D>();

            this.enemySprites.Add(Content.Load<Texture2D>("zombieleft"));
            this.enemySprites.Add(Content.Load<Texture2D>("zombieup"));
            this.enemySprites.Add(Content.Load<Texture2D>("zombieright"));
            this.enemySprites.Add(Content.Load<Texture2D>("zombiedown"));

            this.Multiplier = this.Scale * this.enemySprites[0].Width;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (path.NextStep.X < this.X)
            {
                spritebatch.Draw(this.enemySprites[0], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (path.NextStep.Y < this.Y)
            {
                spritebatch.Draw(this.enemySprites[1], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (path.NextStep.X > this.X)
            {
                spritebatch.Draw(this.enemySprites[2], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (path.NextStep.Y > this.Y)
            {
                spritebatch.Draw(this.enemySprites[3], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
        }

        public void Die()
        {
            this.isAlive = false;
        }

        public void Update(IMap map)
        {
            this.isAttacking = false;
            if (!this.isAwareOfPlayer)
            {
                if (map.IsInFov(X, Y))
                {
                    this.isAwareOfPlayer = true;
                }
            }
            else
            {
                if (nextMovement <= DateTime.Now)
                {
                    nextMovement = DateTime.Now + moveDelay;
                    if (!(this.player.X == this.path.FirstCell.X && this.player.Y == this.path.FirstCell.Y))
                    {
                        X = this.path.FirstCell.X;
                        Y = this.path.FirstCell.Y;
                        this.path.CreateFrom(X, Y);
                    }
                    else if(nextAttack<=DateTime.Now)
                    {
                        nextAttack = DateTime.Now + attackDelay;
                        this.isAttacking = true;
                    }
                }
            }
        }

        public Microsoft.Xna.Framework.Rectangle CalculateEnemyBounds()
        {
            return new Microsoft.Xna.Framework.Rectangle((int)(this.X * this.Multiplier),
                (int)(this.Y * this.Multiplier), (int)this.Multiplier, (int)this.Multiplier);
        }
    }
}
