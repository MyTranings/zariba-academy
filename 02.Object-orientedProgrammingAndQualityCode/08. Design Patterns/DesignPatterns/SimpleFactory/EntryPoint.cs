namespace SimpleFactory
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            Hero drowRanger = HeroFactory.CreateHero(HeroTypes.DamageDealer);
            Hero axe = HeroFactory.CreateHero(HeroTypes.Tank);
            Hero warlock = HeroFactory.CreateHero(HeroTypes.Mage);
            Console.WriteLine(drowRanger.Agility);
        }
    }
}
