using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PooyanGame1.Utils;

namespace PooyanGame1.GameObjects.Environment
{
    public class Level
    {
        public Level (Texture2D bg)
        {
            this.Background = bg;
        }

        private Texture2D Background { get; set; }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Background, new Rectangle(0, 0, Globals.GAME_WIDTH, 
                Globals.GAME_HEIGHT), Color.White);
        }
    }
}
