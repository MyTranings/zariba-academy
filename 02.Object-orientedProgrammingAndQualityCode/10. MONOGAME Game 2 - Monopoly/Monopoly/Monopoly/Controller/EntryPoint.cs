namespace Monopoly
{
    public static class EntryPoint
    {
        public static MonopolyGame game;
        static void Main()
        {
            using (game = new MonopolyGame())
                game.Run();
        }
    }
}
