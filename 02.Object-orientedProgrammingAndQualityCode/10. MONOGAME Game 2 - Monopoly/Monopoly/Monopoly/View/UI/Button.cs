namespace Monopoly.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button
    {
        public Button(Sprite sprite, Texture2D hoverImage, Texture2D clickedImage, Texture2D inactiveImage)
        {
            this.Sprite = sprite;
            this.hoverImage = hoverImage;
            this.clickedImage = clickedImage;
            this.inactiveImage = inactiveImage;
        }

        public Sprite Sprite { get; set; }
        private Texture2D hoverImage { get; set; }
        private Texture2D clickedImage { get; set; }
        private Texture2D inactiveImage { get; set; }

        public void ChangeToHoverImage()
        {
            this.Sprite.Image = this.hoverImage;
        }

        public void ChangeToClickedImage()
        {
            this.Sprite.Image = this.clickedImage;
        }

        public void ChangeToInactiveImage()
        {
            this.Sprite.Image = this.inactiveImage;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Sprite.Image,this.Sprite.Rectangle,Color.White);
        }
    }
}
