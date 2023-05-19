namespace BunniesVersusZombies
{
    using BunniesVersusZombies.Allies;
    using BunniesVersusZombies.Enemies;
    using BunniesVersusZombies.Enums;
    using System;

    public class EntryPoint
    {
        private static void Main()
        {
            Bunny myBunny = new Bunny("Pesho", 150, BunnyBreed.Wuzzy);
            Zombie enemyZombie = new Zombie(50, 150);

            myBunny.Greet();
            myBunny.Reload();
            Console.WriteLine(myBunny.ToString());
            myBunny.Reload();
            Console.WriteLine(myBunny.ToString());
            Console.WriteLine(enemyZombie.ToString());
            myBunny.Shoot(enemyZombie);
            Console.WriteLine(enemyZombie.ToString());
            Console.WriteLine(myBunny.ToString());
            myBunny.Shoot(enemyZombie);
            myBunny.Shoot(enemyZombie);
            myBunny.Shoot(enemyZombie);
            Console.WriteLine(enemyZombie.ToString());
            Console.WriteLine(myBunny.ToString());
            enemyZombie.Attack(myBunny);
            Console.WriteLine(myBunny.ToString());
        }
    }
}
