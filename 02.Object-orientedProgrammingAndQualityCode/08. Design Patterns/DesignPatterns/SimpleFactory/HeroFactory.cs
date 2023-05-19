namespace SimpleFactory
{
    using System;

    public static class HeroFactory
    {
        //Encapsulate how heroes are created
        public static Hero CreateHero(HeroTypes heroType)
        {
            switch (heroType)
            {
                case HeroTypes.Tank: return new Hero(200, 150, 50);
                case HeroTypes.DamageDealer: return new Hero(100, 250, 80);
                case HeroTypes.Mage: return new Hero(80, 100, 300);
                default: throw new ArgumentException("No such hero");
            }
        }

    }
}
