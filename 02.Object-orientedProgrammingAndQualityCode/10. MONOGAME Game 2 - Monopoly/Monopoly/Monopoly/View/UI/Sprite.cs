namespace Monopoly.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Sprite
    {
        public Sprite(Rectangle rectangle, Texture2D image)
        {
            this.Rectangle = rectangle;
            this.Image = image;
        }

        public Rectangle Rectangle;
        public Texture2D Image { get; set; }
    }
}
