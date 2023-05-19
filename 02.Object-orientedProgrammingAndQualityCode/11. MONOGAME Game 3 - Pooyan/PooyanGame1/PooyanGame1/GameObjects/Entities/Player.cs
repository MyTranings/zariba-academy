namespace PooyanGame1.GameObjects.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using Utils;
    using System;
    using FlyingObjects;
    using Managers;
    using PooyanGameTest.Utils;

    public class Player : Entity
    {
        public Player(Texture2D texture, int speed)
            : base(texture, speed)
        {
            this.Position = new Vector2(Globals.PLAYER_POSITION_X, Globals.PLAYER_POSITION_Y);
            this.Arrows = new List<Arrow>();
            this.GameOverDelay = new DelayedAction[4];
        }

        private KeyboardState PreviousKeyboardState { get; set; }

        private KeyboardState CurrentKeyboardState { get; set; }

        public List<Arrow> Arrows { get; set; }

        private DelayedAction[] GameOverDelay { get; set; }

        public void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            if (this.IsAlive)
            {
                this.HandleKeys(keyboardState);
                this.CheckForGameOver();

                foreach (var delay in this.GameOverDelay)
                {
                    if (delay != null)
                    {
                        delay.Update(gameTime.ElapsedGameTime.Seconds);
                    }
                }
            }
        }

        private void CheckForGameOver()
        {
            if (Globals.BusyLadders > 3)
            {
                this.IsAlive = false;
            }
            
            for (int i = 0; i < this.GameOverDelay.Length; i++)
            {
                if (Globals.BusyLadders == this.GameOverDelay.Length - i && 
                    this.GameOverDelay[i] == null && this.Position.Y > Globals.FIRST_RECTANGLE_TOP + 
                    (i * Globals.RECTANGLE_OFFSET) && 
                    this.Position.Y < Globals.FIRST_RECTANGLE_BOTTOM + i * Globals.RECTANGLE_OFFSET)
                {
                    int multiplier = i;
                    this.GameOverDelay[i] = new DelayedAction(() =>
                    {
                        if (this.Position.Y > Globals.FIRST_RECTANGLE_TOP +
                    (multiplier * Globals.RECTANGLE_OFFSET) &&
                    this.Position.Y < Globals.FIRST_RECTANGLE_BOTTOM + multiplier * 
                    Globals.RECTANGLE_OFFSET)
                        {
                            this.IsAlive = false;
                        }
                    }, 1);
                }
            }
        }

        private void HandleKeys(KeyboardState keyboardState)
        {
            this.PreviousKeyboardState = this.CurrentKeyboardState;
            this.CurrentKeyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && this.Position.Y > Globals.PLAYER_MIN_POSITION_Y)
            {
                this.Move(new Vector2(0, -this.Speed));
            }
            else if (keyboardState.IsKeyDown(Keys.Down) && this.Position.Y < Globals.PLAYER_MAX_POSITION_Y)
            {
                this.Move(new Vector2(0, this.Speed));
            }

            if (this.PreviousKeyboardState.IsKeyDown(Keys.Space) &&
                this.CurrentKeyboardState.IsKeyUp(Keys.Space))
            {
                this.Shoot();
            }
        }

        private void Shoot()
        {
            ArrowManager.AddNewArrow(this.Position);
        }
    }
}
