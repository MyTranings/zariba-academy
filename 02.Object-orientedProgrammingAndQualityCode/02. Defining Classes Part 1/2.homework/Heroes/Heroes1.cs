using System;
using System.Collections.Generic;

namespace Heroes
{
    public enum PrimaryAttribute
    {
        Intelligence,
        Agility,
        Strength
    }

    public enum HeroClassType
    {
        Sorcerer,
        Fighter,
        Tank
    }

    public enum WeaponType
    {
        Sword,
        Hammer,
        Staff
    }

    public enum ArmorType
    {
        Cask,
        Shield
    }

    public enum ItemClass
    {
        Common,
        Rare,
        Mythical
    }

    class Weapon
    {
        //Define a class Weapon which holds the following information: type(enumeration  Sword, Hammer, Staff, etc. ),  class (common, rare, mythical), damage.
        private const ItemClass DEFAULT_ITEM_CLASS = ItemClass.Common;
        private const string ITEM_CLASS_2 = "Rare";
        private const string ITEM_CLASS_3 = "Mythical";
        private const float DECREASE_ATTACK_PERCENTAGE = 30f;
        
        private const float MIN_WEAPON_DAMAGE = 3f;
        private const float MAX_WEAPON_DAMAGE = 50f;
        private const float DEFAULT_DAMAGE = 5f;

        private WeaponType heroWeapon;
        private float weaponDamage;
        private ItemClass weaponClass;
        private float damageChangeBy;

        public Weapon(HeroClassType heroClass)
            : this(heroClass, DEFAULT_DAMAGE, DEFAULT_ITEM_CLASS)
        {
        }

        public Weapon(HeroClassType heroClass, float damage)
            : this(heroClass, damage, DEFAULT_ITEM_CLASS)
        {
        }

        public Weapon(HeroClassType heroClass, float damage, ItemClass weaponClass)
        {
            if (heroClass == HeroClassType.Fighter)
            {
                this.HeroWeapon = WeaponType.Sword;
            }
            else if (heroClass == HeroClassType.Sorcerer)
            {
                this.HeroWeapon = WeaponType.Staff;
            }
            else if (heroClass == HeroClassType.Tank)
            {
                this.HeroWeapon = WeaponType.Hammer;
            }
            else
            {
                throw new NotSupportedException(
                    string.Format("There is no such weapan available for this hero class. Available weapons are: {0} used by {1}, {2} used by {3}, {4} used by {5}",
                        WeaponType.Sword, HeroClassType.Fighter, WeaponType.Staff, HeroClassType.Sorcerer, WeaponType.Hammer, HeroClassType.Tank));
            }

            this.WeaponDamage = damage;
            this.WeaponClass = weaponClass;
            this.damageChangeBy = CalcDamagePercentage();
        }

        public Weapon(WeaponType heroWeapon)
            :this(heroWeapon, MIN_WEAPON_DAMAGE, DEFAULT_ITEM_CLASS)
        {
        }

        public Weapon(WeaponType heroWeapon, float damage)
            : this(heroWeapon, damage, DEFAULT_ITEM_CLASS)
        {
        }

        public Weapon(WeaponType heroWeapon, float damage, ItemClass weaponClass)
        {
            this.HeroWeapon = heroWeapon;
            this.WeaponDamage = damage;
            this.WeaponClass = weaponClass;
            this.damageChangeBy = CalcDamagePercentage();
        }

        public WeaponType HeroWeapon
        {
            get
            {
                return this.heroWeapon;
            }
            set
            {
                if (value != WeaponType.Sword && value != WeaponType.Hammer && value != WeaponType.Staff)
                {
                    throw new NotSupportedException(
                        string.Format("There is no such weapon available. Available weapons are: {0} used by {1}, {2} used by {3}, {4} used by {5}",
                            WeaponType.Sword, HeroClassType.Fighter, WeaponType.Staff, HeroClassType.Sorcerer, WeaponType.Hammer, HeroClassType.Tank));
                }

                this.heroWeapon = value;
            }
        }

        public float WeaponDamage
        {
            get
            {
                return this.weaponDamage;
            }
            set
            {
                if (value < MIN_WEAPON_DAMAGE || value > MAX_WEAPON_DAMAGE)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Weapon damage must be betwenn {0} and {1}!", MIN_WEAPON_DAMAGE, MIN_WEAPON_DAMAGE));
                }

                this.weaponDamage = value;
            }
        }

        public ItemClass WeaponClass
        {
            get
            {
                return this.weaponClass;
            }
            set
            {
                if (value != ItemClass.Common && value != ItemClass.Rare && value != ItemClass.Mythical)
                {
                    throw new ArgumentOutOfRangeException(string.Format("There is no such weapon class. The available classes are: {0}, {1} and {2}", DEFAULT_ITEM_CLASS, ITEM_CLASS_2, ITEM_CLASS_3));
                }

                this.weaponClass = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Weapon: {0}, Damage: {1}, Class: {2}.", this.HeroWeapon, this.WeaponDamage, this.WeaponClass);
        }

        private float CalcDamagePercentage()
        {
            float decrement = this.WeaponDamage * (DECREASE_ATTACK_PERCENTAGE / 100);
            return decrement;
        }

        public void DecreaseAttack()
        {
            this.weaponDamage -= damageChangeBy;
        }

        public void RestoreAttack()
        {
            this.weaponDamage += damageChangeBy;
        }
    }

    class Armor
    {
        // damageBlock, type (cask, shield etc), class (same as above).
        private const ItemClass DEFAULT_ITEM_CLASS = ItemClass.Common;
        private const int ARMOR_CHANGED_STEP = 2;

        private const float MIN_DAMAGE_BLOCK = 2;
        private const float MAX_DAMAGE_BLOCK = 40;

        private float damageBlock;
        private ItemClass armorClass;

        public Armor(ArmorType heroArmor)
            : this(heroArmor, MIN_DAMAGE_BLOCK, DEFAULT_ITEM_CLASS)
        {
        }

        public Armor(ArmorType heroArmor, float damageBlock)
            : this(heroArmor, damageBlock, DEFAULT_ITEM_CLASS)
        {
        }

        public Armor(ArmorType heroArmor, float damageBlock, ItemClass armorClass)
        {
            this.HeroArmor = heroArmor;
            this.DamageBlock = damageBlock;
            this.ArmorClass = armorClass;
        }

        public ArmorType HeroArmor { get; private set; }

        public float DamageBlock
        {
            get
            {
                return this.damageBlock;
            }
            set
            {
                if (value < MIN_DAMAGE_BLOCK || value > MAX_DAMAGE_BLOCK)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Block damage should be a value between {0} and {1}", MIN_DAMAGE_BLOCK, MAX_DAMAGE_BLOCK));
                }

                this.damageBlock = value;
            }
        }

        public ItemClass ArmorClass
        {
            get
            {
                return this.armorClass;
            }
            set
            {
                if (value != ItemClass.Common && value != ItemClass.Rare && value != ItemClass.Mythical)
                {
                    throw new ArgumentOutOfRangeException(string.Format("There is no such armor class. The available classes are: {0}, {1} and {2}", ItemClass.Common, ItemClass.Rare, ItemClass.Mythical));
                }

                this.armorClass = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Armor: {0}, Damage block: {1}, Class: {2}.", this.HeroArmor, this.DamageBlock, this.ArmorClass);
        }

        public void IncreaseArmor()
        {
            this.DamageBlock = this.DamageBlock * ARMOR_CHANGED_STEP;
        }

        public void RestoreArmor()
        {
            this.DamageBlock = this.DamageBlock / ARMOR_CHANGED_STEP;
        }
    }

    class Hero
    {
        //name, health, level, mana, strength, agility, intelligence, primaryAttribute(as an enumeration, one of the previous 3), isBlocking, isDead, class (Sorcerer, Fighter, Tank), Weapon(class) and Armor(class).
        
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
        
        private readonly static Random rng = new Random();
        
        private string name;
        private float health;
        private int level;
        private int mana;
        private Weapon heroWeapon;
        private bool isBlocking = false;

        private static int nameCounter = 0;

        private static int numberOfClasses = Enum.GetNames(typeof(HeroClassType)).Length;

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

        private static string GenerateDefaultName(string name)
        {
            Hero.nameCounter++;
            string generatedName = name + Hero.nameCounter;
            return generatedName;
        }

        private static HeroClassType GenerateDefaultClass()
        {
            int number = Hero.rng.Next(0, numberOfClasses);
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
            string weaponInfo = "";
            string armorInfo = "";

            if (this.HeroWeapon != null)
            {
                weaponInfo = this.HeroWeapon.ToString();
            }

            if (this.HeroArmor != null)
            {
                armorInfo = this.HeroArmor.ToString();
            }

            return string.Format("Name: {0}, Class: {1}, Heath: {2}, Level: {3}, Mana: {4}, Attribute: {5}. {6} {7} Is blocking {8}",
                this.Name, this.HeroClass, this.Health, this.Level, this.Mana, this.PrivateAttribute, weaponInfo, armorInfo, this.isBlocking);
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}, heath: {1}, damage: {2}, armor: {3}, used block: {4}", this.Name, this.Health, this.HeroWeapon.WeaponDamage, this.HeroArmor.DamageBlock, this.isBlocking);

            return result;
        }

        public void Attack(Hero heroToAttack)
        {
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
                    this.RoundAction(heroToAttack);
                    this.HeroWeapon.RestoreAttack();
                }
                else
                {
                    this.RoundAction(heroToAttack);
                }
            }
        }

        private void RoundAction(Hero heroToAttack)
        {
            this.PrintAction(this.ToString() + " attacks " + heroToAttack.ToString());
            heroToAttack.TakeDamage(this.heroWeapon.WeaponDamage);
            this.PrintAction("The outcome of this round: \n" + heroToAttack.ToString());
        }

        private void PrintAction(string printState)
        {
            Console.WriteLine(printState);
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

        public void Block()
        {
            int blockChance = rng.Next(0, 5);

            if (!this.isBlocking && blockChance == 4)
            {
                this.isBlocking = true;
            }
            else
            {
                this.isBlocking = false;
            }
        }
    }

    class EntryPoint
    {
        static void Main()
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
            sorcerer.GetArmor(new Armor(ArmorType.Cask, 5));
            Console.WriteLine(sorcerer.HeroInfo());

            List<Hero> allHeroes = new List<Hero>();
            bool gameOver = false;
            Random rng = new Random();

            allHeroes.Add(fighterHero);
            allHeroes.Add(tankHero);
            allHeroes.Add(sorcerer);

            while (!gameOver)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);

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

                    attingHero.Attack(defendHero);

                    if (defendHero.IsDead) 
                    {
                        allHeroes.Remove(defendHero);
                    }
                    if (allHeroes.Count == 1)
                    {
                        gameOver = true;
                    }
                }
                Console.WriteLine("Round end.");
            }

            Console.WriteLine("The winner is {0}", allHeroes[0].ToString());
        }
    }
}
