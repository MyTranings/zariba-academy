namespace Crimsonland
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RogueSharp;
    using RogueSharp.MapCreation;

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IMap map;

        private Level level;

        private Player player;

        private EnemyManager enemyManager;

        private UI UI;
        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 640,
                PreferredBackBufferWidth = 800
            };

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IMapCreationStrategy<Map> mapCreationStrategy = new RandomRoomsMapCreationStrategy<Map>(50, 40, 100, 7, 3);

            Global.Camera.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            Global.Camera.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;

            this.map = Map.Create(mapCreationStrategy);

            Cell startingCell = GetRandomEmptyCell();
            this.player = new Player(this.Content, startingCell.X, startingCell.Y, 0.5f, map);
            this.player.UpdatePlayerFieldOfView();

            this.level = new Level(this.Content, this.map);

            this.UI = new UI(this.Content.Load<SpriteFont>("Font"));
            this.enemyManager = new EnemyManager(this.Content, this.map);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Cell randomCell = this.GetRandomEmptyCell();
            this.enemyManager.Update(randomCell, player);

            this.level.SpawnAmmo(randomCell);
            this.level.Update(player);

            this.player.Update(Keyboard.GetState());

            this.UI.Update(player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin(transformMatrix: Global.Camera.TranslationMatrix);

            this.level.Draw(this.spriteBatch);

            this.enemyManager.Draw(this.spriteBatch);

            this.player.Draw(this.spriteBatch);

            this.UI.Draw(this.spriteBatch);

            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        private Cell GetRandomEmptyCell()
        {
            while(true)
            {
                int x = Global.Random.Next(49);
                int y = Global.Random.Next(39);
                if(this.map.IsWalkable(x, y))
                {
                    return this.map.GetCell(x, y);
                }
            }
        }
    }
}
