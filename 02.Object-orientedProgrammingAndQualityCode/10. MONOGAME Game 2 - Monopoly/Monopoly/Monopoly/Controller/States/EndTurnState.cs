namespace Monopoly.Controller.States
{
    using View.Renderers;
    using View.UI;
    using Microsoft.Xna.Framework.Input;
    using Model;

    public class EndTurnState : State
    {
        public EndTurnState(State nextState)
            : base(nextState){ }

        public override void Execute()
        {
            EntryPoint.game.renderer.PlayerOneMoney = Board.players[0].Money + "$";
            EntryPoint.game.renderer.PlayerTwoMoney = Board.players[1].Money + "$";
            ActivateEndTurnButton();
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
                Board.CurrentPlayerIndex = (Board.CurrentPlayerIndex + 1) % 2;
                StateMachine.ChangeState();
            }
        }
    }
}
