namespace Singleton
{
    using System.Collections.Generic;
    using System.Linq;

    public class SaveLoadLogger
    {
        private static readonly SaveLoadLogger logger = new SaveLoadLogger();
        private List<string> states;

        private SaveLoadLogger()
        {
            this.states = new List<string>();
        }

        public static SaveLoadLogger Instance
        {
            get
            {
                return logger;
            }
        }

        public void Save(string currentState)
        {
            this.states.Add(currentState);
        }

        public string Load()
        {
            return this.states.Last();
        }
        public string Load(int index)
        {
            return this.states[index];
        }

    }
}
