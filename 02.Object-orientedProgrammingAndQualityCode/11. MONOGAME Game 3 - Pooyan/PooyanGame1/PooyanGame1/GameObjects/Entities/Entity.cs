using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PooyanGame1.Utils;

namespace PooyanGame1.GameObjects.Entities
{
    public abstract class Entity
    {
        public Entity(Texture2D texture, int speed)
        {
            this.Texture = texture;
            this.Speed = speed;

            this.IsAlive = true;
        }

        public bool IsAlive { get; protected set; }

        public Vector2 Position { get; protected set; }

        protected Texture2D Texture { get; set; }

        protected int Speed { get; set; }

        public virtual void Move(Vector2 direction)
        {
            this.Position += direction;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, 
                scale: new Vector2(Globals.ENTITY_SCALE, Globals.ENTITY_SCALE));
        }
    }
}
