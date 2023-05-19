using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class EntryPoint
    {
        public static void Main()
        {
            var gameHeroFactory = new Dota2HeroFactory();
            var ultimateHeroCreator = new UltimateHeroCreator(gameHeroFactory);

            Mage dota2Mage = ultimateHeroCreator.CreateSpecificMage();
        }
    }
}
