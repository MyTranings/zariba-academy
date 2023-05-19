namespace OptimizedHeroes
{
    using System;
    using System.Collections.Generic;
    using OptimizedHeroes.Armors;
    using OptimizedHeroes.Enumerations;
    using OptimizedHeroes.Heroes;
    using OptimizedHeroes.Weapons;

    public class EntryPoint
    {
        public static void Main()
        {
            Hero fighterHero = new Hero("Zakoo", 200, 1, 200, HeroClassType.Fighter);
            fighterHero.GetWeapon(new Weapon(fighterHero.HeroClass, 35));
            fighterHero.GetArmor(new Armor(ArmorType.Shield));
            Console.WriteLine(fighterHero.HeroInfo());

            Hero tankHero = new Hero("Brad", 250, 1, 200, HeroClassType.Tank);
            tankHero.GetWeapon(new Weapon(tankHero.HeroClass, 20));
            tankHero.GetArmor(new Armor(ArmorType.Shield));
            Console.WriteLine(tankHero.HeroInfo());

            Hero sorcerer = new Hero("Neda", 180, 2, 460, HeroClassType.Sorcerer, PrimaryAttribute.Agility);
            sorcerer.GetWeapon(new Weapon(WeaponType.Staff, 35, ItemClass.Rare));
            sorcerer.GetArmor(new Armor(ArmorType.Cask, 5, ItemClass.Common));
            Console.WriteLine(sorcerer.HeroInfo());

            List<Hero> allHeroes = new List<Hero>();
            bool gameOver = false;
            Random rng = new Random();

            allHeroes.Add(fighterHero);
            allHeroes.Add(tankHero);
            allHeroes.Add(sorcerer);

            while (!gameOver)
            {
                Console.WriteLine("Press sapce to run the next round.");
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Round start");
                    int attackerIndex = rng.Next(allHeroes.Count);
                    int defendIndex = rng.Next(allHeroes.Count);

                    while (defendIndex == attackerIndex)
                    {
                        defendIndex = rng.Next(allHeroes.Count);
                    }

                    Hero attingHero = allHeroes[attackerIndex];
                    Hero defendHero = allHeroes[defendIndex];

                    Console.WriteLine(attingHero.Attack(defendHero));

                    if (defendHero.IsDead)
                    {
                        allHeroes.Remove(defendHero);
                    }

                    if (allHeroes.Count == 1)
                    {
                        gameOver = true;
                    }

                    Console.WriteLine("Round end.");
                }
            }

            Console.WriteLine("The winner is {0}", allHeroes[0].ToString());
        }
    }
}
