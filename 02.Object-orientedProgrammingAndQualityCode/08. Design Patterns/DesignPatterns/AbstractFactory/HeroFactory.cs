using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class HeroFactory
    {
        public abstract Mage CreateMage();
        public abstract DamageDealer CreateDamageDealer();
        public abstract Tank CreateTank();

    }
}
