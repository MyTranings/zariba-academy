using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class UltimateHeroCreator
    {
        private HeroFactory factory;

        public UltimateHeroCreator(HeroFactory heroFactory)
        {
            this.factory = heroFactory;
        }

        public Mage CreateSpecificMage()
        {
            return factory.CreateMage();
        }
        public Tank CreateSpecificTank()
        {
            return factory.CreateTank();
        }
        public DamageDealer CreateSpecificDamageDealer()
        {
            return factory.CreateDamageDealer();
        }
    }
}
