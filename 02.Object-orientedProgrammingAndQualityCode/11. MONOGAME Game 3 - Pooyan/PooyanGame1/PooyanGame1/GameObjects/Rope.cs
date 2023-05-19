namespace PooyanGame1.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utils;
    using System.Collections.Generic;

    public class Rope
    {
        public Rope(Texture2D part)
        {
            this.Parts = new List<Texture2D>();
            this.Parts.Add(part);

            this.PartHeight = part.Height;
        }

        public List<Texture2D> Parts { get; private set; } 

        private int PartHeight { get; set; }

        public void Update(Vector2 playerPosition)
        {
            int partsCount = (int)((playerPosition.Y - Globals.ROPE_POSITION_Y) / this.PartHeight) + 1;

            while (partsCount != this.Parts.Count)
            {
                if (partsCount > this.Parts.Count)
                {
                    this.Parts.Add(this.Parts[0]);
                }
                else
                {
                    this.Parts.Remove(this.Parts[this.Parts.Count - 1]);
                }
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            for (int i = 0; i < this.Parts.Count; i++)
            {
                spriteBatch.Draw(this.Parts[i], new Vector2(Globals.ROPE_POSITION_X, 
                    Globals.ROPE_POSITION_Y + i * this.PartHeight));
            }
        }
    }
}
