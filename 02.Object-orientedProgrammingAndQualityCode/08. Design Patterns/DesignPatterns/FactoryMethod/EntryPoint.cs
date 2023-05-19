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
            MageFactory mageFactory = new MageFactory();
            Hero mage = mageFactory.CreateHero();
        }
    }
}
