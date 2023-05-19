namespace Crimsonland
{
    using GameObjects.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RogueSharp;
    using System;
    using System.Collections.Generic;

    public enum Direction { left, right, up, down };
    public class Player : Entity
    {
        private Direction currentDirection;

        private IMap map;

        public DateTime nextMovement;
        public TimeSpan moveDelay = new TimeSpan(0, 0, 0, 0, 100);

        public DateTime nextBullet;
        public TimeSpan bulletDelay = new TimeSpan(0, 0, 0, 0, 350);

        public List<Bullet> bullets;

        public bool isAlive;

        public bool screenBlinking;

        private List<Texture2D> playerSprites;

        private Texture2D redScreenBlink;

        public int numberOfBullets;
        public Player(ContentManager Content, int x, int y, float scale, IMap map)
            : base(Content)
        {
            this.X = x;
            this.Y = y;
            this.Scale = scale;
            this.map = map;
            this.playerSprites = new List<Texture2D>();
            this.bullets = new List<Bullet>();

            this.redScreenBlink = Content.Load<Texture2D>("red");
            this.Health = 100;

            this.numberOfBullets = 5;

            this.playerSprites.Add(Content.Load<Texture2D>("playerLeft"));
            this.playerSprites.Add(Content.Load<Texture2D>("playerUp"));
            this.playerSprites.Add(Content.Load<Texture2D>("playerRight"));
            this.playerSprites.Add(Content.Load<Texture2D>("playerDown"));

            this.Multiplier = this.Scale * this.playerSprites[0].Width;
        }

        public void Update(KeyboardState keyState)
        {
            this.HandleBullets();

            this.HandleInput(keyState);

            Global.Camera.CenterOn(new Vector2((int)(X * this.Multiplier), (int)(Y * this.Multiplier)));
        }

        public void ReceiveDamage()
        {
            this.Health -= 5;
            this.screenBlinking = true;
        }

        public void UpdatePlayerFieldOfView()
        {
            this.map.ComputeFov(X, Y, 30, true);
            foreach (Cell cell in this.map.GetAllCells())
            {
                if (this.map.IsInFov(cell.X, cell.Y))
                {
                    this.map.SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }

        public void Shoot()
        {
            if (nextBullet <= DateTime.Now && this.numberOfBullets > 0)
            {
                nextBullet = DateTime.Now + bulletDelay;
                this.bullets.Add(new Bullet(Content, 0.4f, new Vector2(this.X, this.Y), 0.25f, currentDirection, 0.5f));
                this.numberOfBullets--;
            }
        }

        public void HandleBullets()
        {
            for (int i = 0; i < this.bullets.Count; i++)
            {
                this.bullets[i].Update();
                if (this.bullets[i].isActive == false)
                {
                    this.bullets.Remove(this.bullets[i]);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (this.currentDirection == Direction.left)
            {
                spritebatch.Draw(this.playerSprites[0], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (this.currentDirection == Direction.up)
            {
                spritebatch.Draw(this.playerSprites[1], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (this.currentDirection == Direction.right)
            {
                spritebatch.Draw(this.playerSprites[2], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }
            else if (this.currentDirection == Direction.down)
            {
                spritebatch.Draw(this.playerSprites[3], new Vector2(this.X * this.Multiplier,
                    this.Y * this.Multiplier), scale: new Vector2(Scale, Scale));
            }

            foreach (Bullet bullet in this.bullets)
            {
                if (this.map.IsInFov((int)bullet.position.X, (int)bullet.position.Y))
                {
                    bullet.Draw(spritebatch);
                }
            }

            if(this.screenBlinking)
            {
                spritebatch.Draw(this.redScreenBlink,new Microsoft.Xna.Framework.Rectangle(0, 0, 2400, 1920), new Color(255,255,255,0));
                this.screenBlinking = false;
            }
        }

        public void HandleInput(KeyboardState keyState)
        {
            if (this.nextMovement <= DateTime.Now)
            {
                nextMovement = DateTime.Now + moveDelay;
                if (keyState.IsKeyDown(Keys.W))
                {
                    int tempY = Y - 1;
                    if (this.map.IsWalkable(X, tempY))
                    {
                        Y = tempY;
                        UpdatePlayerFieldOfView();
                    }
                    currentDirection = Direction.up;
                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    int tempX = X - 1;
                    if (this.map.IsWalkable(tempX, Y))
                    {
                        X = tempX;
                        UpdatePlayerFieldOfView();
                    }
                    currentDirection = Direction.left;
                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    int tempY = Y + 1;
                    if (this.map.IsWalkable(X, tempY))
                    {
                        Y = tempY;
                        UpdatePlayerFieldOfView();
                    }
                    currentDirection = Direction.down;
                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    int tempX = X + 1;
                    if (this.map.IsWalkable(tempX, Y))
                    {
                        X = tempX;
                        UpdatePlayerFieldOfView();
                    }
                    currentDirection = Direction.right;
                }

                if (keyState.IsKeyDown(Keys.Space))
                {
                    this.Shoot();
                }
            }
        }
    }
}
