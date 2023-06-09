﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacecraft_Wars
{
    public class Background
    {
        public Vector2 Location;
        public Vector2 Velocity;
        private Texture2D image;
        public Rectangle Bounds;

        public Background(Vector2 location, Texture2D image)
        {
            this.Location = location;
            this.image = image;
            this.Bounds = new Rectangle(0, 0, 1453, 900);
            this.Velocity = new Vector2(0, 0);
        }

        public void Update(float elapsed)
        {
            this.Location += Velocity * elapsed;
            this.Bounds.X = (int)Location.X;
            this.Bounds.Y = (int)Location.Y;

            if (this.Bounds.Right<0)
            {
                this.Location.X = 1453;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, Location, Color.White);
        }
    }
}
