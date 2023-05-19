namespace PooyanGame1.GameObjects.Managers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using FlyingObjects;
    using System.Collections.Generic;

    public static class ArrowManager
    {
        public static List<Arrow> Arrows = new List<Arrow>();
        public static Texture2D arrowTexture;

        public static void AddNewArrow(Vector2 playerPosition)
        {
            ArrowManager.Arrows.Add(new Arrow(arrowTexture, 5, playerPosition));
        }

        public static void Update(GameTime gameTime)
        {
            for (int i = ArrowManager.Arrows.Count - 1; i >= 0; i--)
            {
                ArrowManager.Arrows[i].Update(gameTime);
                if (!ArrowManager.Arrows[i].IsAlive)
                {
                    ArrowManager.Arrows.Remove(ArrowManager.Arrows[i]);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var arrow in ArrowManager.Arrows)
            {
                arrow.Draw(spriteBatch);
            }
        }
    }
}
