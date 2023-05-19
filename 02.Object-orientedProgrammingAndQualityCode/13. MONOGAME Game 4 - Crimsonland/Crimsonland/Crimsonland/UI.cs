namespace Crimsonland
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    class UI
    {
        public SpriteFont Font;

        private Player player;

        public UI(SpriteFont font)
        {
            this.Font = font;
        }

        public void Update(Player player)
        {
            this.player = player;
        }

        public void Draw (SpriteBatch spritebatch)
        {
            spritebatch.DrawString(this.Font, 
                "Health: " + this.player.Health, 
                new Vector2((this.player.X*this.player.Multiplier)-380, (this.player.Y * this.player.Multiplier)-300),
                Color.AntiqueWhite);
            spritebatch.DrawString(this.Font,
                "Bullets: " + this.player.numberOfBullets,
                new Vector2((this.player.X * this.player.Multiplier) + 300, (this.player.Y * this.player.Multiplier) - 300),
                Color.AntiqueWhite);
        }
    }
}
