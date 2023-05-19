namespace Singleton
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            SaveLoadLogger logger = SaveLoadLogger.Instance;

            logger.Save("level 1");
            logger.Save("level 5");
            logger.Save("level 15");
            Console.WriteLine(logger.Load());
            Console.WriteLine(logger.Load(1));
        }
    }
}
