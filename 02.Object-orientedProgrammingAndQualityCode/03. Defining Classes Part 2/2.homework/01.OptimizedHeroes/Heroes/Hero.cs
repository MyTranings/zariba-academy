namespace OptimizedHeroes.Heroes
{
    using System;

    using OptimizedHeroes.Armors;
    using OptimizedHeroes.Enumerations;
    using OptimizedHeroes.Weapons;

    public class Hero
    {
        private const int MIN_NAME_WIDTH = 3;
        private const int MAX_NAME_WIDTH = 25;
        private const string DEFAULT_NAME = "Hero";
        private const int DEFAULT_LVL = 1;
        private const int MIN_LVL = 1;
        private const int MAX_LVL = 10;
        private const float DEFAULT_HEALTH = 200;
        private const float MIN_HEALTH = 0;
        private const float MAX_HEALTH = DEFAULT_HEALTH * MAX_LVL;
        private const int DEFAULT_MANA = 300;
        private const int MIN_MANA = 10;
        private const int MAX_MANA = DEFAULT_MANA * MAX_LVL;
        private const float DECREASE_PERCENTAGE = 30f;

        private static readonly Random Rng = new Random();
        private static int nameCounter = 0;
        private static int numberOfClasses = Enum.GetNames(typeof(HeroClassType)).Length;

        private string name;
        private float health;
        private int level;
        private int mana;
        private Weapon heroWeapon;
        private bool isBlocking = false;

        public Hero()
            : this(GenerateDefaultName(DEFAULT_NAME))
        {
        }

        public Hero(string name)
            : this(name, DEFAULT_HEALTH)
        {
        }

        public Hero(string name, float health)
            : this(name, health, DEFAULT_LVL)
        {
        }

        public Hero(string name, float health, int level)
            : this(name, health, level, DEFAULT_MANA)
        {
        }

        public Hero(string name, float health, int level, int mana)
            : this(name, health, level, mana, GenerateDefaultClass())
        {
        }

        public Hero(string name, float health, int level, int mana, HeroClassType heroClass)
            : this(name, health, level, mana, heroClass, SetPrivateAtribute(heroClass))
        {
        }

        public Hero(string name, float health, int level, int mana, HeroClassType heroClass, PrimaryAttribute privateAttribute)
        {
            this.Name = name;
            this.Health = health;
            this.Level = level;
            this.Mana = mana;
            this.HeroClass = heroClass;
            this.PrivateAttribute = privateAttribute;
            this.IsDead = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < MIN_NAME_WIDTH || value.Length > MAX_NAME_WIDTH)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Hero name must be between {0} and {1} symbols!", MIN_NAME_WIDTH, MAX_NAME_WIDTH));
                }

                this.name = value;
            }
        }

        public float Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < MIN_HEALTH || value > MAX_HEALTH)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Health must be a value between {0} and {1}!", MIN_HEALTH, MAX_HEALTH));
                }

                this.health = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }

            set
            {
                if (value < MIN_LVL || value > MAX_LVL)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Minimum hero level is {0} and maximum level is {1}!", MIN_LVL, MAX_LVL));
                }

                this.level = value;
            }
        }

        public int Mana
        {
            get
            {
                return this.mana;
            }

            set
            {
                if (value < MIN_MANA || value > MAX_MANA)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Mana must be a value between {0} and {1}!", MIN_MANA, MAX_MANA));
                }

                this.mana = value;
            }
        }

        public HeroClassType HeroClass { get; private set; }

        public PrimaryAttribute PrivateAttribute { get; private set; }

        public Weapon HeroWeapon
        {
            get
            {
                return this.heroWeapon;
            }

            set
            {
                bool validWeaponFighter = this.HeroClass == HeroClassType.Fighter && (value.HeroWeapon == WeaponType.Staff || value.HeroWeapon == WeaponType.Hammer);
                bool validWeaponSorcerer = this.HeroClass == HeroClassType.Sorcerer && (value.HeroWeapon == WeaponType.Sword || value.HeroWeapon == WeaponType.Hammer);
                bool validWeaponTank = this.HeroClass == HeroClassType.Tank && (value.HeroWeapon == WeaponType.Staff || value.HeroWeapon == WeaponType.Sword);
                if (validWeaponFighter || validWeaponSorcerer || validWeaponTank)
                {
                    throw new NotSupportedException(string.Format("Fighter can't use {0} as a weapon. A fighter can use only {1}", value.HeroWeapon, WeaponType.Sword));
                }

                this.heroWeapon = value;
            }
        }

        public Armor HeroArmor { get; private set; }

        public bool IsDead { get; private set; }

        public void GetWeapon(Weapon heroWeapon)
        {
            this.HeroWeapon = heroWeapon;
        }

        public void GetArmor(Armor heroArmor)
        {
            this.HeroArmor = heroArmor;
        }

        public string HeroInfo()
        {
            string weaponInfo = string.Empty;
            string armorInfo = string.Empty;

            if (this.HeroWeapon != null)
            {
                weaponInfo = this.HeroWeapon.ToString();
            }

            if (this.HeroArmor != null)
            {
                armorInfo = this.HeroArmor.ToString();
            }

            return string.Format("Name: {0}, Class: {1}, Heath: {2}, Level: {3}, Mana: {4}, Attribute: {5}. {6} {7} Is blocking {8}", this.Name, this.HeroClass, this.Health, this.Level, this.Mana, this.PrivateAttribute, weaponInfo, armorInfo, this.isBlocking);
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}, heath: {1}, damage: {2}, armor: {3}, used block: {4}", this.Name, this.Health, this.HeroWeapon.WeaponDamage, this.HeroArmor.DamageBlock, this.isBlocking);

            return result;
        }

        public string Attack(Hero heroToAttack)
        {
            string printRoundAction = string.Empty;

            if (heroToAttack.Health < 0)
            {
                heroToAttack.IsDead = true;
            }
            else
            {
                if (this.isBlocking)
                {
                    this.isBlocking = false;
                    this.HeroWeapon.DecreaseAttack();
                    printRoundAction = this.RoundAction(heroToAttack);
                    this.HeroWeapon.RestoreAttack();
                }
                else
                {
                    printRoundAction = this.RoundAction(heroToAttack);
                }
            }

            return printRoundAction;
        }

        public void TakeDamage(float damage)
        {
            float damageToTake = damage - this.HeroArmor.DamageBlock;
            this.Block();

            if (this.isBlocking)
            {
                this.HeroArmor.IncreaseArmor();
                damageToTake = damage - this.HeroArmor.DamageBlock;
                this.CalcHealth(damageToTake);
                this.HeroArmor.RestoreArmor();
            }
            else
            {
                this.CalcHealth(damageToTake);
            }
        }

        public void Block()
        {
            int blockChance = Rng.Next(0, 5);

            if (!this.isBlocking && blockChance == 4)
            {
                this.isBlocking = true;
            }
            else
            {
                this.isBlocking = false;
            }
        }

        private static string GenerateDefaultName(string name)
        {
            Hero.nameCounter++;
            string generatedName = name + Hero.nameCounter;
            return generatedName;
        }

        private static HeroClassType GenerateDefaultClass()
        {
            int number = Hero.Rng.Next(0, numberOfClasses);
            HeroClassType selectedClass;

            if (number == 0)
            {
                selectedClass = HeroClassType.Sorcerer;
            }
            else if (number == 1)
            {
                selectedClass = HeroClassType.Fighter;
            }
            else
            {
                selectedClass = HeroClassType.Tank;
            }

            return selectedClass;
        }

        private static PrimaryAttribute SetPrivateAtribute(HeroClassType heroClass)
        {
            PrimaryAttribute attribute;

            if (heroClass == HeroClassType.Sorcerer)
            {
                attribute = PrimaryAttribute.Intelligence;
            }
            else if (heroClass == HeroClassType.Fighter)
            {
                attribute = PrimaryAttribute.Agility;
            }
            else if (heroClass == HeroClassType.Tank)
            {
                attribute = PrimaryAttribute.Strength;
            }
            else
            {
                throw new NotSupportedException(string.Format("Invalid hero class! Available hero classes are: {0}, {1} and {2}", HeroClassType.Sorcerer, HeroClassType.Fighter, HeroClassType.Tank));
            }

            return attribute;
        }

        private void CalcHealth(float damage)
        {
            if (this.Health - damage <= 0)
            {
                this.Health = 0;
                this.IsDead = true;
            }
            else
            {
                this.Health = this.Health - damage;
            }
        }

        private string RoundAction(Hero heroToAttack)
        {
            string resultOfAction = this.ToString() + " attacks " + heroToAttack.ToString();
            heroToAttack.TakeDamage(this.heroWeapon.WeaponDamage);
            resultOfAction += "The outcome of this round: \n" + heroToAttack.ToString();
            return resultOfAction;
        }
    }
}
