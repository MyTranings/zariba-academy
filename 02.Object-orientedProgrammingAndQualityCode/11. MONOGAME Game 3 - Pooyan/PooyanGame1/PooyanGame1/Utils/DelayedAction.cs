namespace PooyanGameTest.Utils
{
    using System;

    public class DelayedAction
    {
        public DelayedAction(Action action, float delay)
        {
            this.TimeRemaining = delay;
            this.Action = action;
            this.Delay = delay;
        }

        public Action Action { get; private set; }

        public float Delay { get; private set; }

        public float TimeRemaining { get; private set; }

        public bool Update(float deltaTime)
        {
            this.TimeRemaining -= deltaTime;

            if (this.TimeRemaining <= 0)
            {
                this.Action();
                return false;
            }

            return true;
        }
    }
}
