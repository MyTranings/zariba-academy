using System;

namespace AbstractFactory
{
    public class LolHeroFactory : HeroFactory
    {
        public override DamageDealer CreateDamageDealer()
        {
            return new DamageDealer(100, 250, 80);
        }

        public override Mage CreateMage()
        {
            return new Mage(80, 150, 250);
        }

        public override Tank CreateTank()
        {
            return new Tank(250, 80, 80);
        }
        public Hero CreateSupport()
        {
            return new Hero(....);
        }
    }
}
