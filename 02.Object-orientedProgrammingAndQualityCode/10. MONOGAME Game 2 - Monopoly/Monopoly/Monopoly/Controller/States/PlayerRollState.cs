namespace Monopoly.Controller.States
{
    using System;
    using View.Renderers;
    using Model;

    public class PlayerRollState : State
    {
        public PlayerRollState(State nextState)
            :base(nextState) { }

        public override void Execute()
        {
            Random rng = new Random();

            int currentPlayerPosition = Board.players[Board.CurrentPlayerIndex].CurrentPosition;

            int firstDiceNumber = rng.Next(1, 7);
            int secondDiceNumber = rng.Next(1, 7);
            int totalPositionToMove = firstDiceNumber+secondDiceNumber;

            PlayerMoveState.PlayerOldPosition = currentPlayerPosition;
            EntryPoint.game.renderer.FirstDice.ChangeDiceImage(firstDiceNumber);
            EntryPoint.game.renderer.SecondDice.ChangeDiceImage(secondDiceNumber);
            EntryPoint.game.renderer.NotificationText = "Player " + (Board.CurrentPlayerIndex+1) + " rolled " + totalPositionToMove;
            Board.players[Board.CurrentPlayerIndex].SetPosition(currentPlayerPosition + totalPositionToMove);

            StateMachine.ChangeState();      
        }
    }
}
