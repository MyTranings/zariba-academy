namespace Monopoly.Controller.States
{
    using View.Renderers;
    using Model;

    public class InitialState : State
    {
        public InitialState(State nextState)
            :base(nextState) { }

        public override void Execute()
        {
            Board.InitializeBoard();
        }
    }
}
