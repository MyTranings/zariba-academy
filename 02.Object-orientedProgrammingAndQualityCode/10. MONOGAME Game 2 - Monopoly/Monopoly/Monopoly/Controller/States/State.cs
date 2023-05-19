namespace Monopoly.Controller.States
{
    using View.Renderers;

    public abstract class State
    {
        public State(State nextState)
        {
            this.NextState = nextState;
        }

        public State NextState { get; set; }
        

        public abstract void Execute();
        public void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawBoard();
        }

        

    }
}
