namespace Crimsonland.GameObjects.Objects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    public class Bullet
    {
        public bool isActive;

        public Vector2 position;

        private Texture2D sprite;

        private float speed;

        private float scale;

        private Direction direction;

        private float multiplier;

        public Bullet(ContentManager content, float speed, Vector2 playerPosition, float scale, Direction direction, float multiplierScale)
        {
            this.sprite = content.Load<Texture2D>("bullet");
            this.speed = speed;
            this.position = playerPosition;
            this.isActive = true;
            this.scale = scale;
            this.direction = direction;
            this.multiplier = multiplierScale * this.sprite.Width;
        }

        public void Update()
        {
            if (this.direction == Direction.left)
            {
                this.Move(new Vector2(-1, 0));
            }
            else if (this.direction == Direction.up)
            {
                this.Move(new Vector2(0, -1));
            }
            else if (this.direction == Direction.right)
            {
                this.Move(new Vector2(1, 0));
            }
            else if (this.direction == Direction.down)
            {
                this.Move(new Vector2(0, 1));
            }
        }

        public void Move(Vector2 direction)
        {
            this.position += direction * speed;
        }

        public void Hit()
        {
            this.isActive = false;
        }

        public Rectangle CalculateBulletBounds()
        {
            return new Rectangle((int)(this.position.X * this.multiplier), (int)(this.position.Y * this.multiplier),
                (int)this.multiplier, (int)this.multiplier);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.sprite, new Vector2(this.position.X * this.multiplier, this.position.Y * this.multiplier), scale: new Vector2(scale, scale));
        }
    }
}
