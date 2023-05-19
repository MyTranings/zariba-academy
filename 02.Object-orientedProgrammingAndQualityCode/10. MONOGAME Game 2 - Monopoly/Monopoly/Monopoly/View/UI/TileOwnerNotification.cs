namespace Monopoly.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class TileOwnerNotification
    {
        public Sprite Sprite { get; set; }
        public bool IsActive { get; set; } = false;
        public int BoardIndex { get; private set; }
        public TileOwnerNotification(int index, Sprite sprite)
        {
            this.BoardIndex = index;
            this.Sprite = sprite;
        }

        public void SetOwner(ContentManager content,int ownerIndex)
        {
            this.IsActive = true;
            this.Sprite.Image = content.Load<Texture2D>("Owner" + ownerIndex.ToString());
        }
        public void Draw(SpriteBatch spritebatch)
        {
            if (IsActive)
            {
                spritebatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
            }
        }

    }
}
