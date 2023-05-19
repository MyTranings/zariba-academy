namespace BunniesVersusZombies.Allies
{

    using BunniesVersusZombies.Bullets;
    using BunniesVersusZombies.Enemies;
    using BunniesVersusZombies.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bunny
    {
        // constants
        private const int MINIMUM_NAME_SIZE = 3;
        private const int MAXIMUM_NAME_SIZE = 10;
        private const int MAXIMUM_HEALTH = 1000;
        private const BunnyBreed DEFAULT_BREED = BunnyBreed.Mini;
        private const string DEFAULT_NAME = "John Doe";
        private const int DEFAULT_HEALTH = 100;
        private const int RANDOM_SEED = 300;
        private const int DEFAULT_DAMAGE = 20;
        private const int RELOAD_BULLETS_NUMBER = 5;

        // readonly field 
        private static readonly Random Rng = new Random(RANDOM_SEED);
        private static int counter = 0;

        // Fields
        private string id;
        private string name;
        private int health;

        // Constructors
        public Bunny()
            : this(DEFAULT_NAME)
        {
        }

        public Bunny(string name)
            : this(name, DEFAULT_HEALTH)
        {
        }

        public Bunny(string name, int health)
            : this(name, health, DEFAULT_BREED)
        {
        }

        public Bunny(string name, int health, BunnyBreed breed)
        {
            this.id = GenerateID();
            this.Name = name;
            this.Health = health;
            this.Breed = breed;
            this.CarrotBullets = new List<Carrot>();
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // validation
                if (value.Length < MINIMUM_NAME_SIZE || value.Length > MAXIMUM_NAME_SIZE)
                {
                    throw new ArgumentOutOfRangeException("Bunny name should be between 3 and 10 symbols.");
                }
                
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0 || value > MAXIMUM_HEALTH)
                {
                    throw new ArgumentOutOfRangeException("Bunny health should be between 0 and 1000");
                }

                this.health = value;
            }
        }

        public BunnyBreed Breed { get; private set; } // automatic property

        public List<Carrot> CarrotBullets { get; private set; }

        // methods
        
        public string Greet()
        {
            return string.Format("Hi! My name is {0}, I have {1} health. I have {2} bullets remaining. My breed is {3}",
                this.Name, this.Health, this.CarrotBullets.Count, this.Breed);
        }

        public override string ToString()
        {
            return "Name: " + this.Name + " Health: " + this.Health + " Bullets: " + this.CarrotBullets.Count;
        }

        public void AddBullet()
        {
            this.CarrotBullets.Add(new Carrot(DEFAULT_DAMAGE, "blue"));
        }

        public void Reload()
        {
            if (this.CarrotBullets.Count < RELOAD_BULLETS_NUMBER)
            {
                for (int i = this.CarrotBullets.Count - 1; i < RELOAD_BULLETS_NUMBER; i++)
                {
                    this.AddBullet();
                }
            }
        }

        public string TakeDamage(int damage)
        {
            if (this.Health - damage <= 0)
            {
                this.Health = 0;
                return string.Format("Bunny is dead :( ");
            }
            else
            {
                this.Health = this.Health - damage;
                return string.Empty;
            }
        }

        public string Shoot(Zombie zombie)
        {
            if (this.CarrotBullets.Count > 0)
            {
                zombie.TakeDamage(this.CarrotBullets.Last().Damage);
                this.CarrotBullets.RemoveAt(this.CarrotBullets.Count - 1);
                return string.Empty;
            }
            else
            {
                return "No bullets. Sorry :(";
            }
        }

        private string GenerateID()
        {
            Bunny.counter++;
            int number = Bunny.Rng.Next(1000, 100000);
            string finalId = Bunny.counter + "_" + number;
            return finalId;
        }
    }
}
