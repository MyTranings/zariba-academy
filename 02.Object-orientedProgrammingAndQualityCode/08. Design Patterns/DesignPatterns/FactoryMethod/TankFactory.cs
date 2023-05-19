using System;

namespace AbstractFactory
{
    public class TankFactory : HeroFactory
    {
        public override Hero CreateHero()
        {
            return new Tank(250, 100, 80);
        }
    }
}