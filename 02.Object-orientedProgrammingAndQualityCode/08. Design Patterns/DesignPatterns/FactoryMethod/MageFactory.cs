using System;

namespace AbstractFactory
{
    public class MageFactory : HeroFactory
    {
        public override Hero CreateHero()
        {
            return new Mage(80,150,250);
        }
    }
}
