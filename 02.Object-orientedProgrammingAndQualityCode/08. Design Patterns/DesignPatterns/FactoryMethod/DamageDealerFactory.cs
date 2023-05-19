using System;

namespace AbstractFactory
{
    public class DamageDealerFactory : HeroFactory
    {
        public override Hero CreateHero()
        {
            return new DamageDealer(150, 250, 80);
        }
    }
}
