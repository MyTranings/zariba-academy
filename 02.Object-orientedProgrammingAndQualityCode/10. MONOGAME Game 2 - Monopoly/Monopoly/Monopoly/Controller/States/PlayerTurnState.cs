namespace Monopoly.Controller.States
{
    using View.Renderers;
    using Microsoft.Xna.Framework.Input;
    using View.UI;
    using Model;

    public class PlayerTurnState : State
    {
        public PlayerTurnState(State nextState)
            :base(nextState) { }

        public override void Execute()
        {
            Button rollButton = EntryPoint.game.renderer.RollButton;
            EntryPoint.game.renderer.NotificationText = "Player " + (Board.CurrentPlayerIndex + 1) +"'s turn. \nPlease roll!";

            bool mouseOverRoll = rollButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            if (mouseOverRoll)
            {
                rollButton.ChangeToHoverImage();
            }
            else
            {
                rollButton.ChangeToInactiveImage();
            }
            if (Mouse.GetState().LeftButton==ButtonState.Pressed && mouseOverRoll)
            {
                rollButton.ChangeToClickedImage();
                EntryPoint.game.renderer.ShouldPlayerMove = true;
                StateMachine.ChangeState();
            }
        }
    }
}
