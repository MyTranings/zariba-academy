using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacecraft_Wars
{
    public class Bullet
    {
        public Vector2 Location;
        public Vector2 Velocity;
        private Texture2D image;
        public Rectangle Bounds;
        public bool IsVisible;

        public Bullet(Vector2 location, Texture2D image)
        {
            this.Location = location;
            this.image = image;
            this.Velocity = new Vector2(500, 0);
            this.Bounds = new Rectangle(0, 0, 73, 25);
            this.IsVisible = true;
        }

        public void Update(float elapsed)
        {
            this.Location += Velocity * elapsed;

            Bounds.X = (int)Location.X;
            Bounds.Y = (int)Location.Y;
        }

        public void Draw(SpriteBatch sb)
        {
            if (this.IsVisible)
            {
                sb.Draw(image, Location, Color.White);
            }
        }
    }
}
