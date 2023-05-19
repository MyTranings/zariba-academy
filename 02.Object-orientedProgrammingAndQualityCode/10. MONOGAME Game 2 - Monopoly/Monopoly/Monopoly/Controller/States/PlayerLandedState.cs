namespace Monopoly.Controller.States
{
    using View.Renderers;
    using Model.Tiles;
    using Model;
    using View.UI;
    using Microsoft.Xna.Framework.Input;

    public class PlayerLandedState : State
    {
        public PlayerLandedState(State nextState)
            : base(nextState) { }

        public override void Execute()
        {
            int playerIndex = Board.CurrentPlayerIndex;
            var playerCurrentPosition = Board.players[playerIndex].CurrentPosition;
            Tile currentTile = Board.allTiles[playerCurrentPosition];
            EntryPoint.game.renderer.NotificationText = "Player " + (playerIndex + 1) + " landed on\n" + currentTile.Name + "\n";
            EntryPoint.game.renderer.NotificationText += Board.allTiles[playerCurrentPosition].ActOnPlayer(Board.players[Board.CurrentPlayerIndex]);
            EntryPoint.game.renderer.PlayerOneMoney = Board.players[0].Money + "$";
            EntryPoint.game.renderer.PlayerTwoMoney = Board.players[1].Money + "$";

            ActivateEndTurnButton();

            if (currentTile is Street)
            {
                var currentTileAsStreet = currentTile as Street;
                if(currentTileAsStreet.Owner != Board.players[Board.CurrentPlayerIndex] && currentTileAsStreet.Owner==null)
                { 
                    ActivateBuyButton(playerCurrentPosition);
                }
                else
                {
                    StateMachine.ChangeState();
                }

            }

            else if (currentTile is ChanceCard)
            {
                var currentTileAsChance = currentTile as ChanceCard;
                StateMachine.ChangeState();
            }

            else if (currentTile is SpecialTile)
            {
                var currentTileAsSpecial = currentTile as SpecialTile;
                if (currentTile.Name == "Go To Jail")
                {
                    EntryPoint.game.renderer.MovePlayer(Board.CurrentPlayerIndex, 30, 10);
                }
            }

            else if (currentTile is Tax)
            {
                StateMachine.ChangeState();
            }
        }

        private void ActivateEndTurnButton()
        {
            Button endTurnButton = EntryPoint.game.renderer.EndTurnButton;

            bool mouseOverendTurn = endTurnButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverendTurn)
            {
                endTurnButton.ChangeToHoverImage();
            }
            else
            {
                endTurnButton.ChangeToInactiveImage();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverendTurn)
            {
                endTurnButton.ChangeToClickedImage();
                EntryPoint.game.renderer.NotificationText = "Are you sure you want to end your Turn?";
                
                StateMachine.ChangeState();
            }
        }


        private void ActivateBuyButton(int playerCurrentPosition)
        {
            Button buyButton = EntryPoint.game.renderer.BuyButton;
            int currentPlayer = Board.CurrentPlayerIndex;
            bool mouseOverBuy = buyButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverBuy)
            {
                buyButton.ChangeToHoverImage();
            }
            else
            {
                buyButton.ChangeToInactiveImage();
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverBuy)
            {
                buyButton.ChangeToClickedImage();
                EntryPoint.game.renderer.NotificationText = "Property Bought!";
                Board.AddStreetToPlayer(playerCurrentPosition, currentPlayer);
                
                EntryPoint.game.renderer.ShowTileOwner(currentPlayer, playerCurrentPosition);
                EntryPoint.game.renderer.PlayerOneMoney = Board.players[0].Money+"$";
                EntryPoint.game.renderer.PlayerTwoMoney = Board.players[1].Money + "$";
                
                StateMachine.ChangeState();
            }
        }
    }
}
