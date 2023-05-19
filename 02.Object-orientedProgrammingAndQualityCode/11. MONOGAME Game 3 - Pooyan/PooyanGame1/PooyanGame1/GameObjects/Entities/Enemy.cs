

namespace PooyanGame1.GameObjects.Entities
{
    using Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public enum EnemyState
    {
        WALKING,
        FALLING,
        DEAD,
        ONGROUND,
        ONLADDER,
    }

    public class Enemy : Entity
    {
        public Enemy(Texture2D walkingSheet, Texture2D fallingSheet, 
            Texture2D deadAnimationSheet, Texture2D onGroundWalkingSheet, Texture2D climbingSheet, 
            int speed, Vector2 position)
            :base(walkingSheet, speed)
        {
            this.Animations = new Dictionary<EnemyState, Animation>();
            this.Animations.Add(EnemyState.WALKING, new Animation(walkingSheet, 2, 
                new Vector2(20, 28), true));
            this.Animations.Add(EnemyState.FALLING, new Animation(fallingSheet, 1,
                new Vector2(18, 28), true));
            this.Animations.Add(EnemyState.DEAD, new Animation(deadAnimationSheet, 1,
                new Vector2(16, 16), true));
            this.Animations.Add(EnemyState.ONGROUND, new Animation(onGroundWalkingSheet, 3,
                new Vector2(20, 16), true));
            this.Animations.Add(EnemyState.ONLADDER, new Animation(climbingSheet, 8,
               new Vector2(15, 16), false));

            this.Position = position;
            this.State = EnemyState.WALKING;
            this.FallPositionX = Globals.RNG.Next(Globals.ENEMY_MIN_POSITION_X, 
                Globals.ENEMY_MAX_POSITION_X);
        }

        private EnemyState State { get; set; }

        private Dictionary<EnemyState, Animation> Animations { get; set; }

        private Animation ActiveAnimation
        {
            get
            {
                return this.Animations[this.State];
            }
        }

        private int FallPositionX { get; }

        public void Update(GameTime gameTime)
        {
            if (this.State == EnemyState.WALKING || this.State == EnemyState.ONGROUND)
            {
                this.Move(new Vector2(this.Speed, 0));
            }
            else if (this.State == EnemyState.FALLING)
            {
                this.Move(new Vector2(0, (float)(this.Speed * 0.5)));
            }
            else if (this.State == EnemyState.DEAD)
            {
                this.Move(new Vector2(0, (float)(this.Speed)));
            }
            else if (this.Position.X != Globals.LADDER_POSITION_X)
            {
                if (Globals.BusyLadders == 0)
                {
                    this.Position = new Vector2(Globals.LADDER_POSITION_X,
                        Globals.LadderPositionsY[0]);
                }
                else if (Globals.BusyLadders == 1)
                {
                    this.Position = new Vector2(Globals.LADDER_POSITION_X,
                        Globals.LadderPositionsY[1]);
                }
                else if (Globals.BusyLadders == 2)
                {
                    this.Position = new Vector2(Globals.LADDER_POSITION_X,
                        Globals.LadderPositionsY[2]);
                }
                else 
                {
                    this.Position = new Vector2(Globals.LADDER_POSITION_X,
                        Globals.LadderPositionsY[3]);
                }

                Globals.BusyLadders++;
            }

            if (this.Position.X >= this.FallPositionX && this.State == EnemyState.WALKING)
            {
                this.State = EnemyState.FALLING;
            }
            else if (this.Position.X >= Globals.PLAYER_POSITION_X && 
                this.State == EnemyState.ONGROUND)
            {
                this.State = EnemyState.ONLADDER;
            }

            if (this.Position.Y >= Globals.GROUND_POSITION_Y && this.State == EnemyState.FALLING)
            {
                this.State = EnemyState.ONGROUND;
            }

            this.ActiveAnimation.Update(gameTime, this.Position);
        }

        public Rectangle CalculateBalloonBounds()
        {
            return new Rectangle((int)this.Position.X, (int)this.Position.Y, 
                (int)(this.ActiveAnimation.FrameBounds.Width * 1.7f), 
                this.ActiveAnimation.FrameBounds.Height);
        }

        public Rectangle CalculateEnemyBounds()
        {
            return new Rectangle((int)this.Position.X, (int)this.Position.Y,
                (int)(this.ActiveAnimation.FrameBounds.Width * 1.7f) - 1, 
                (int)(this.ActiveAnimation.FrameBounds.Height * 1.7));
        }

        public void Die()
        {
            this.IsAlive = false;
            this.State = EnemyState.DEAD;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.ActiveAnimation.Draw(spriteBatch);
        }
    }
}
