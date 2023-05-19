using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PooyanGame1.GameObjects.Entities;
using PooyanGame1.Utils;
using PooyanGameTest.Utils;

namespace PooyanGame1.GameObjects.FlyingObjects
{
    public class Arrow : Entity
    {
        public Arrow(Texture2D texture, int speed, Vector2 playerPosition)
            : base(texture, speed)
        {
            this.Position = playerPosition + Globals.ARROW_POSITION_OFFSET;
            this.Rotation = 0;
            this.HasDeflected = false;
        }

        private float Rotation { get; set; }

        private bool HasDeflected { get; set; }

        private DelayedAction DelAction { get; set; }

        public void Update(GameTime gameTime)
        {
            if (this.Position.X >= Globals.ARROW_RANGE_X)
            {
                if (this.HasDeflected)
                {
                    this.Move(new Vector2(0, this.Speed));
                }
                else
                {
                    this.Move(new Vector2(-this.Speed, 0));
                }
            }
            else if (this.DelAction == null)
            {
                this.DelAction = new DelayedAction(() =>
                {
                    this.IsAlive = false;
                }, 3);
            }

            if (this.DelAction != null)
            {
                this.DelAction.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public Rectangle ArrowBounds()
        {
            return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Texture.Width, 
                this.Texture.Height);
        }

        public void Hit()
        {
            this.IsAlive = false;
        }

        public void Deflect()
        {
            this.Rotation = -8;
            this.HasDeflected = true;
        }

        public override void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, rotation: this.Rotation, 
                scale: new Vector2(Globals.ENTITY_SCALE));
        }

    }
}
