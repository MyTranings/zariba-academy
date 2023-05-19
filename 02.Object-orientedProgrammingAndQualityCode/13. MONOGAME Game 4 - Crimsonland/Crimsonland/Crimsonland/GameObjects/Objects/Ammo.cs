namespace Crimsonland.GameObjects.Objects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    class Ammo
    {
        public bool isActive;

        public Vector2 position;

        private Texture2D sprite;

        private float scale;

        private float multiplier;

        public Ammo(ContentManager content, Vector2 randomPosition, float scale)
        {
            this.sprite = content.Load<Texture2D>("ammo2");
            this.position = randomPosition;
            this.isActive = true;
            this.scale = scale;
            this.multiplier = scale * this.sprite.Width;
        }

        private void Destroy()
        {
            this.sprite.Dispose();
            this.isActive = false;
        }

        public Rectangle CalculateAmmoBounds()
        {
            return new Rectangle((int)this.position.X, (int)this.position.Y, (int)this.multiplier, (int)this.multiplier);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, new Vector2(this.position.X * this.multiplier, this.position.Y * this.multiplier), scale: new Vector2(scale, scale));
        }
    }
}
