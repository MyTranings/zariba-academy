using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooyanGame1.UserInterface
{
    public static class UI
    {
        public static SpriteFont Font { get; set; }

        public static int Score { get; set; }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(UI.Font, "Score: " + UI.Score, new Vector2(0, 20), 
                Color.BlanchedAlmond);
        }
    }
}
