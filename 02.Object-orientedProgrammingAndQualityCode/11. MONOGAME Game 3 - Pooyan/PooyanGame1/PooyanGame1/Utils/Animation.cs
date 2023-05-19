using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PooyanGame1.Utils
{
    public class Animation
    {
        public Animation(Texture2D spritesheet, int framesCount, Vector2 frameBounds, bool loop = false)
        {
            this.Texture = spritesheet;
            this.FramesCount = framesCount;
            this.FrameBounds = new Rectangle(0, 0, (int)frameBounds.X, (int)frameBounds.Y);
            this.Loop = loop;
        }

        public bool Loop { get; set; }

        public Rectangle FrameBounds { get; private set; }

        private Vector2 Position { get; set; }

        private Texture2D Texture { get; set; }

        private int FramesCount { get; set; }

        private int CurrentFrame { get; set; } = 0;

        private double FrameDuration { get; set; } = 400;

        private double TimeSinceLastStateChange { get; set; } = 0;

        public void Update(GameTime gameTime, Vector2 position)
        {
            this.Position = position;
            this.TimeSinceLastStateChange += gameTime.ElapsedGameTime.Milliseconds;
            
            if (this.TimeSinceLastStateChange >= this.FrameDuration)
            {
                this.TimeSinceLastStateChange = 0;
                this.CurrentFrame++;

                if (this.CurrentFrame == this.FramesCount && this.Loop)
                {
                    this.FrameBounds = new Rectangle(0, 0, this.FrameBounds.Width, 
                        this.FrameBounds.Height);
                    this.CurrentFrame = 0;
                }
                else if (this.CurrentFrame < this.FramesCount)
                {
                    this.FrameBounds = new Rectangle(this.FrameBounds.X + this.FrameBounds.Width, 
                        this.FrameBounds.Y, this.FrameBounds.Width, this.FrameBounds.Height);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, sourceRectangle: this.FrameBounds, 
                scale: new Vector2(1.9f, 1.9f));
        }
    }
}
