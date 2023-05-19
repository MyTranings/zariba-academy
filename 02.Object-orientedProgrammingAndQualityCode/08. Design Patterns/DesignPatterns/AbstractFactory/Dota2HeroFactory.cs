using System;

namespace AbstractFactory
{
    public class Dota2HeroFactory : HeroFactory
    {
        public override DamageDealer CreateDamageDealer()
        {
            return new DamageDealer(1, 5, 2);
            //Peperoni
        }

        public override Mage CreateMage()
        {
            return new Mage(1, 2, 5);
            //Margharitta
        }

        public override Tank CreateTank()
        {
            return new Tank(5, 2, 1);
            //Hawai
        }
    }
}
