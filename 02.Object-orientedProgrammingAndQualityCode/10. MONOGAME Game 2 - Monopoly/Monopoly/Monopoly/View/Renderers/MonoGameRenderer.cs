
namespace Monopoly.View.Renderers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using UI;
    using System.Collections.Generic;
    using System.Linq;

    public class MonoGameRenderer : AbstractRenderer
    {
        private ContentManager Content = EntryPoint.game.Content;
        private SpriteBatch SpriteBatch;

        public Button BuyButton;
        public Button RollButton;
        public Button EndTurnButton;

        public Dice FirstDice;
        public Dice SecondDice;

        public List<PlayerUI> PlayersUI;
        public PlayerUI FirstPlayer;
        public PlayerUI SecondPlayer;
        private int Velocity;
        private Rectangle TileDestination;
        public bool ShouldPlayerMove;

        private Background background;
        public TileOwnerNotification[] TileNotifications;
        public Rectangle[] TileColliders;
        private SpriteFont font; 

        public string NotificationText;
        public string PlayerOneMoney;
        public string PlayerTwoMoney;

        public MonoGameRenderer()
        {
            this.background = UIInitializer.CreateBackground(Content);
            this.BuyButton = UIInitializer.CreateBuyButton(Content);
            this.RollButton = UIInitializer.CreateRollButton(Content);
            this.EndTurnButton = UIInitializer.CreateEndTurnButton(Content);
            this.FirstDice = UIInitializer.CreateDice(Content, 1);
            this.SecondDice = UIInitializer.CreateDice(Content, 2);
            this.FirstPlayer = UIInitializer.CreatePlayer(Content, 1);
            this.SecondPlayer = UIInitializer.CreatePlayer(Content, 2);

            this.PlayersUI = new List<PlayerUI>();
            this.PlayersUI.Add(FirstPlayer);
            this.PlayersUI.Add(SecondPlayer);

            this.TileNotifications = UIInitializer.CreateTileOwnerNotifications(Content);
            this.TileColliders = UIInitializer.CreateTileColliders();
            this.Velocity = 400;
            this.ShouldPlayerMove = false;

            this.NotificationText = "Zariba Game Academy\n Monopoly";
            this.PlayerOneMoney = "1500$";
            this.PlayerTwoMoney = "1500$";
            this.font = Content.Load<SpriteFont>("Font");
        }
        public override void DrawBoard() 
        {
            this.SpriteBatch = EntryPoint.game.SpriteBatch;
            
            background.Draw(SpriteBatch);

            BuyButton.Draw(SpriteBatch);
            RollButton.Draw(SpriteBatch);
            EndTurnButton.Draw(SpriteBatch);

            FirstDice.Draw(SpriteBatch);
            SecondDice.Draw(SpriteBatch);

            foreach (var player in PlayersUI)
            {
                player.Draw(SpriteBatch);
            }

            foreach (var notification in TileNotifications)
            {
                notification.Draw(SpriteBatch);
            }

            SpriteBatch.DrawString(font, NotificationText,new Vector2(105,105),Color.Black);
            SpriteBatch.DrawString(font, PlayerOneMoney, new Vector2(150, 525), Color.Blue);
            SpriteBatch.DrawString(font, PlayerTwoMoney, new Vector2(150, 560), Color.Red);
        }

        public override void MovePlayer(int playerIndex, int currentPosition, int newPosition)
        {
            PlayerUI currentPlayer = PlayersUI[playerIndex];
            TileDestination = TileColliders[newPosition];
            if (TileDestination.Contains(currentPlayer.Sprite.Rectangle))
            {
                this.ShouldPlayerMove = false;
            }
            else
            {
                
                if(currentPlayer.Sprite.Rectangle.Y>606 && currentPlayer.Sprite.Rectangle.X>30)
                {
                    currentPlayer.Sprite.Rectangle.X -= (int)(Velocity * EntryPoint.game.Elapsed);
                }
                else if (currentPlayer.Sprite.Rectangle.X <= 50 && currentPlayer.Sprite.Rectangle.Y > 30)
                {
                    currentPlayer.Sprite.Rectangle.Y -= (int)(Velocity * EntryPoint.game.Elapsed);
                }
                else if (currentPlayer.Sprite.Rectangle.Y <= 50 && currentPlayer.Sprite.Rectangle.X <650)
                {
                    currentPlayer.Sprite.Rectangle.X += (int)(Velocity * EntryPoint.game.Elapsed);
                }
                else if (currentPlayer.Sprite.Rectangle.X >=620 && currentPlayer.Sprite.Rectangle.Y < 680)
                {
                    currentPlayer.Sprite.Rectangle.Y += (int)(Velocity * EntryPoint.game.Elapsed);
                }
            }
        }

        public override void ShowTileOwner(int playerIndex, int currentPlayerPosition)
        {
            for (int i = 0; i < this.TileNotifications.Count(); i++)
            {
                if (this.TileNotifications[i].BoardIndex == currentPlayerPosition)
                {
                    this.TileNotifications[i].SetOwner(Content, playerIndex+1);
                    break;
                }
            }
        }
    }
}
