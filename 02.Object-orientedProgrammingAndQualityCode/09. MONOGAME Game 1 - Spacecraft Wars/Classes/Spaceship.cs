using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacecraft_Wars
{
    public class Spaceship
    {
        public Vector2 Location;
        public Vector2 Velocity;
        private Texture2D image;
        public Rectangle Bounds;
        public int BulletCount;

        public Spaceship(Vector2 location, Texture2D image)
        {
            this.Location = location;
            this.image = image;
            this.Bounds = new Rectangle(0, 0, 71, 52);
            this.BulletCount = 5;
        }

        public void Update(float elapsed)
        {
            this.Location += Velocity * elapsed;

            Bounds.X = (int)Location.X;
            Bounds.Y = (int)Location.Y;

            if (this.Bounds.Top<0)
            {
                Location.Y = 0;
            }
            if (this.Bounds.Bottom>720)
            {
                this.Location.Y = 720-Bounds.Height;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, Location,Color.White);
        }
    }
}
