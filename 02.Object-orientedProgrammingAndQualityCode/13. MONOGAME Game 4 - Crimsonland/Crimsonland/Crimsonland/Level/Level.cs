namespace Crimsonland
{
    using GameObjects.Objects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using RogueSharp;
    using System;
    using System.Collections.Generic;

    class Level
    {
        private IMap map;
        private Texture2D floor;
        private Texture2D wall;

        private ContentManager content;

        private List<Ammo> ammo;

        public DateTime nextAmmo;
        public TimeSpan ammoSpawnDelay = new TimeSpan(0, 0, 0, 0, 350);

        public Level(ContentManager Content, IMap Map)
        {
            this.content = Content;
            this.floor = content.Load<Texture2D>("floor");
            this.wall = content.Load<Texture2D>("wall");
            this.map = Map;
            this.ammo = new List<Ammo>();
        }

        public void Update(Player player)
        {
            foreach (var ammo in ammo)
            {
                if(player.X == ammo.position.X && player.Y == ammo.position.Y && ammo.isActive)
                {
                    player.numberOfBullets += 5;
                    ammo.isActive = false;
                }
            }
            this.HandleAmmo();
        }

        public void SpawnAmmo(Cell randomCell)
        {
            if(nextAmmo <= DateTime.Now)
            {
                nextAmmo = DateTime.Now + ammoSpawnDelay;
                this.ammo.Add(new Ammo(this.content, new Vector2(randomCell.X, randomCell.Y), 0.5f));
            }
        }

        public void HandleAmmo()
        {
            for (int i = 0; i < this.ammo.Count; i++)
            {
                if(!this.ammo[i].isActive)
                {
                    this.ammo.Remove(this.ammo[i]);
                        i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int sizeOfSprites = 64;
            float scale = 0.5f;
            foreach (Cell cell in map.GetAllCells())
            {
                var position = new Vector2(cell.X * sizeOfSprites * scale,
                    cell.Y * sizeOfSprites * scale);
                if (!cell.IsExplored)
                {
                    continue;
                }
                Color tint = Color.White;
                if(!cell.IsInFov)
                {
                    tint = Color.Gray;
                }
                if(cell.IsWalkable)
                {
                    spriteBatch.Draw(this.floor, position, 
                        scale: new Vector2(scale, scale), color: tint);
                }
                else
                {
                    spriteBatch.Draw(this.wall, position,
                       scale: new Vector2(scale, scale), color: tint);
                }
            }

            foreach (var ammo in this.ammo)
            {
                if(this.map.IsInFov((int)ammo.position.X, (int)ammo.position.Y))
                {
                    ammo.Draw(spriteBatch);
                }
            }
        }
    }
}
