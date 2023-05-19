using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Timers;

namespace Spacecraft_Wars
{
    public class SpacecraftWars : Game
    {
        const int GAME_HEIGHT = 720;
        const int GAME_WIDTH = 1280;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Background background1;
        Background background2;

        Spaceship spaceship;

        List<Bullet> bullets;
        KeyboardState pastKeyState;

        List<List<Meteor>> meteors;
        int meteorVelocity;
        Random rng;

        List<Powerup> powerups;

        SpriteFont basicFont;
        Timer gameTimer;
        int score;
        int holeLength;
        string difficulty;

        public SpacecraftWars()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = GAME_HEIGHT;
            graphics.PreferredBackBufferWidth = GAME_WIDTH;
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            bullets = new List<Bullet>();
            meteors = new List<List<Meteor>>();
            rng = new Random();
            gameTimer = new Timer(1500);
            gameTimer.Elapsed += delegate
            {
                SpawnMeteorWall();
                SpawnPowerup();
            };
            gameTimer.Enabled = true;
            score = 0;
            difficulty = "Easy";
            holeLength = 10;
            meteorVelocity = 200;
            powerups = new List<Powerup>();
            base.Initialize();
        }
        private void SpawnPowerup()
        {
            if (rng.Next(0, 2) == 1)
                powerups.Add(new Powerup(new Vector2(rng.Next(1720, 2000), rng.Next(0, GAME_HEIGHT - 37)), Content.Load<Texture2D>("powerUp"), meteorVelocity));
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spaceship = new Spaceship(new Vector2(20, GAME_HEIGHT / 2), this.Content.Load<Texture2D>("ship"));
            background1 = new Background(new Vector2(0, -90), this.Content.Load<Texture2D>("space"));
            background2 = new Background(new Vector2(1453, -90), this.Content.Load<Texture2D>("spaceRev"));
            basicFont = Content.Load<SpriteFont>("Font");

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            background1.Velocity = new Vector2(-90, 0);
            background2.Velocity = new Vector2(-90, 0);
            spaceship.Velocity = new Vector2(0, 0);
            GameOverCondition();
            KeyHandler();
            Shoot();
            CheckPowerupCollision();
            CheckBulletWallCollision();
            RemoveDestroyedBullets();
            RemoveDestroyedWalls();
            RemoveDestroyedPowerups();
            SetDifficulty();
            UpdateEntities(elapsed);
            base.Update(gameTime);
        }
        private void UpdateEntities(float elapsed)
        {
            foreach (var wall in meteors)
                foreach (var meteor in wall)
                    meteor.Update(elapsed);
            foreach (var bullet in bullets)
                bullet.Update(elapsed);
            foreach (var powerup in powerups)
                powerup.Update(elapsed);
            background1.Update(elapsed);
            background2.Update(elapsed);
            spaceship.Update(elapsed);
            score++;
        }
        private void KeyHandler()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                spaceship.Velocity.Y = 500;
                background1.Velocity.Y = -50;
                background2.Velocity.Y = -50;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                spaceship.Velocity.Y = -500;
                background1.Velocity.Y = 50;
                background2.Velocity.Y = 50;
            }
        }
        private void RemoveDestroyedPowerups()
        {
            for (int i = 0; i < powerups.Count; i++)
                if (!powerups[i].IsVisible)
                    powerups.RemoveAt(i);
        }
        private void CheckPowerupCollision()
        {
            foreach (Powerup powerup in powerups)
                if (powerup.Bounds.Intersects(spaceship.Bounds))
                {
                    powerup.IsVisible = false;
                    spaceship.BulletCount += 2;
                }
        }
        private void SetDifficulty()
        {
            if (score >= 1500 && difficulty == "Easy")
            {
                difficulty = "Medium";
                meteorVelocity = 300;
                ChangeMeteorSpeed(meteorVelocity);
                ChangePowerupSpeed(meteorVelocity);
                holeLength -= 3;
            }
            if (score >= 3000 && difficulty == "Medium")
            {
                difficulty = "Hard";
                meteorVelocity = 450;
                ChangeMeteorSpeed(meteorVelocity);
                ChangePowerupSpeed(meteorVelocity);
                holeLength -= 3;
            }
        }
        private void ChangePowerupSpeed(int meteorVelocity)
        {
            foreach (var powerup in powerups)
                powerup.Velocity = new Vector2(-meteorVelocity, 0);
        }
        private void ChangeMeteorSpeed(int newSpeed)
        {
            foreach (var wall in meteors)
                foreach (var meteor in wall)
                    meteor.Velocity = new Vector2(-meteorVelocity, 0);
        }
        private void RemoveDestroyedWalls()
        {
            for (int i = 0; i < meteors.Count; i++)
            {
                var currentWall = meteors[i];
                for (int j = 0; j < currentWall.Count; j++)
                    if (!currentWall[j].IsVisible)
                        currentWall.RemoveAt(j);
            }
        }
        private void RemoveDestroyedBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
                if (!bullets[i].IsVisible)
                    bullets.RemoveAt(i);
        }
        private void CheckBulletWallCollision()
        {
            foreach (var wall in meteors)
                foreach (var meteor in wall)
                    foreach (var bullet in bullets)
                        if (bullet.Bounds.Intersects(meteor.Bounds))
                        {
                            bullet.IsVisible = false;
                            score += 100;
                            foreach (var bulletToDestroy in wall)
                                bulletToDestroy.IsVisible = false;
                        }
        }
        private void GameOverCondition()
        {
            foreach (var wall in meteors)
                foreach (var meteor in wall)
                    if (meteor.Bounds.Intersects(spaceship.Bounds))
                        Exit();
        }
        private void Shoot()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && pastKeyState.IsKeyUp(Keys.Space) && spaceship.BulletCount > 0)
            {
                spaceship.BulletCount--;
                bullets.Add(new Bullet(new Vector2(spaceship.Location.X, spaceship.Location.Y + 15), Content.Load<Texture2D>("rocket")));
            }
            pastKeyState = Keyboard.GetState();
        }
        private void SpawnMeteorWall()
        {
            List<Meteor> currentWall = new List<Meteor>();
            int holePosition = rng.Next(0, 25 - holeLength);
            for (int i = 0; i < 25; i++)
                if (i <= holePosition || i >= holePosition + holeLength)
                    currentWall.Add(new Meteor(new Vector2(GAME_WIDTH, i * 28 + 10), Content.Load<Texture2D>("rock"), meteorVelocity));
            meteors.Add(currentWall);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);
            spaceship.Draw(spriteBatch);
            foreach (var bullet in bullets)
                bullet.Draw(spriteBatch);
            foreach (var wall in meteors)
                foreach (var meteor in wall)
                    meteor.Draw(spriteBatch);
            foreach (var powerup in powerups)
                powerup.Draw(spriteBatch);
            spriteBatch.DrawString(basicFont, "Bullets: " + spaceship.BulletCount, new Vector2(0, 0), Color.CornflowerBlue);
            spriteBatch.DrawString(basicFont, "Score: " + score, new Vector2(0, 20), Color.Cyan);
            spriteBatch.DrawString(basicFont, "Difficulty: " + difficulty, new Vector2(0, 40), Color.ForestGreen);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
