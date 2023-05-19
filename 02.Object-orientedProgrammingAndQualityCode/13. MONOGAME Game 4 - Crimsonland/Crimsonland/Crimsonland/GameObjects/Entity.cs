namespace Crimsonland
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Entity
    {
        public int X;
        public int Y;
        public Texture2D Sprite;
        protected ContentManager Content;
        public int Health;
        public float Scale;
        public float Multiplier;
        public Entity(ContentManager Content)
        {
            this.Content = Content;
        }

    }
}
