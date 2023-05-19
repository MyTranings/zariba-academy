namespace PooyanGame1
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using PooyanGame1.GameObjects;
    using GameObjects.Entities;
    using Utils;
    using GameObjects.Environment;
    using GameObjects.Managers;
    using UserInterface;

    public class Pooyan : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Player player;
        private Level level;
        private Rope rope;

        public Pooyan()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = Globals.GAME_HEIGHT;
            graphics.PreferredBackBufferWidth = Globals.GAME_WIDTH;
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.level = new Level(this.Content.Load<Texture2D>("Graphics/LevelFont"));
            this.rope = new Rope(this.Content.Load<Texture2D>("Graphics/rope"));
            this.player = new Player(this.Content.Load<Texture2D>("Graphics/Player"), 5);
            ArrowManager.arrowTexture = this.Content.Load<Texture2D>("Graphics/Arrow");
            EnemyManager.EnemyTextures.Add(this.Content.Load<Texture2D>("Graphics/EnemyWalkingSheet"));
            EnemyManager.EnemyTextures.Add(this.Content.Load<Texture2D>("Graphics/EnemyDropping"));
            EnemyManager.EnemyTextures.Add(this.Content.Load<Texture2D>("Graphics/EnemyFalling"));
            EnemyManager.EnemyTextures.Add(this.Content.Load<Texture2D>("Graphics/EnemyWinWalkingSheet"));
            EnemyManager.EnemyTextures.Add(this.Content.Load<Texture2D>("Graphics/EnemyWinClimbingSheet"));
            UI.Font = this.Content.Load<SpriteFont>("Graphics/Font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.rope.Update(this.player.Position);
            this.player.Update(Keyboard.GetState(), gameTime);
            ArrowManager.Update(gameTime);
            EnemyManager.Update(gameTime);
            UI.Score = EnemyManager.EnemiesKilled;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            this.level.Draw(this.spriteBatch);
            this.rope.Draw(this.spriteBatch);
            this.player.Draw(this.spriteBatch);
            ArrowManager.Draw(this.spriteBatch);
            EnemyManager.Draw(this.spriteBatch);
            UI.Draw(this.spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
