namespace Monopoly.Controller.States
{
    using View.Renderers;
    using Model;

    public class PlayerMoveState : State
    {
        public static int PlayerOldPosition { get; set; }

        public PlayerMoveState(State nextState)
            :base(nextState) { }

        public override void Execute()
        {
            EntryPoint.game.renderer.MovePlayer(Board.CurrentPlayerIndex,PlayerOldPosition,Board.players[Board.CurrentPlayerIndex].CurrentPosition);
            if (!EntryPoint.game.renderer.ShouldPlayerMove)
            {
                StateMachine.ChangeState();
            }
        }
    }
}
