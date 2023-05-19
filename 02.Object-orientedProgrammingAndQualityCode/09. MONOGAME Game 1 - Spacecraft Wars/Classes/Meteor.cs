﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacecraft_Wars
{
    public class Meteor
    {
        public Vector2 Location;
        public Vector2 Velocity;
        private Texture2D image;
        public Rectangle Bounds;
        public bool IsVisible;

        public Meteor(Vector2 location, Texture2D image, int velocity)
        {
            this.Location = location;
            this.image = image;
            this.Velocity = new Vector2(-velocity, 0);
            this.Bounds = new Rectangle(0, 0, 27, 28);
            this.IsVisible = true;
        }

        public void Update(float elapsed)
        {
            this.Location += Velocity * elapsed;

            if (this.Location.X<-20)
            {
                this.IsVisible = false;
            }

            this.Bounds.X = (int)Location.X;
            this.Bounds.Y = (int)Location.Y;
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
