namespace OOPPrinciplesPart2.Extensions
{
    public static class AnimalExtensions
    {
        public static string AnimalSpeak(string name, string sound)
        {
            return string.Format("I am {0}. {1}", name, sound);
        }
    }
}
