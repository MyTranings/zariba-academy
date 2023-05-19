using System;

namespace Heroes
{
    public enum PrimaryAttribute
    {
        intelligence,
        agility,
        strength
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

    class Hero
    {
        //name, health, level, mana, strength, agility, intelligence, primaryAttribute(as an enumeration, one of the previous 3), isBlocking, isDead, class (Sorcerer, Fighter, Tank), Weapon(class) and Armor(class).

        // Constants
        private const int MIN_NAME_WIDTH = 3;
        private const int MAX_NAME_WIDTH = 25;
        private const string DEFAULT_NAME = "Hero";
        private const int DEFAULT_LVL = 1;
        private const int MIN_LVL = 1;
        private const int MAX_LVL = 10;
        private const int DEFAULT_HEALTH = 200;
        private const int MIN_HEALTH = 0;
        private const int MAX_HEALTH = DEFAULT_HEALTH * MAX_LVL;
        private const int DEFAULT_MANA = 300;
        private const int MIN_MANA = 10;
        private const int MAX_MANA = DEFAULT_MANA * MAX_LVL;

        // Items
        private const string DEFAULT_ITEM_CLASS = "Common";

        // Weapon
        private const int MIN_WEAPON_DAMAGE = 5;
        private const int MAX_WEAPON_DAMAGE = 50;
        private const int DEFAULT_DAMAGE = 20;

        // Armor
        private const int MIN_ARMOR_BLOCK = 2;
        private const int MAX_ARMOR_BLOCK = 35;
        private const int DEFAULT_DAMAGE_BLOCK = 5;
        private const ArmorType DEFAULT_ARMOR_TYPE = ArmorType.Cask;

        // Readonly
        private readonly static Random rng = new Random();
        
        // Fields
        private string name;
        private int health;
        private int level;
        private int mana;

        private static int nameCounter = 0;

        private static int numberOfClasses = Enum.GetNames(typeof(HeroClassType)).Length;

        // Constructors
        public Hero()
            : this(GenerateDefaultName(DEFAULT_NAME))
        {
        }

        public Hero(string name)
            : this(name, DEFAULT_HEALTH)
        {
        }

        public Hero(string name, int health)
            : this(name, health, DEFAULT_LVL)
        {
        }

        public Hero(string name, int health, int level)
            : this(name, health, level, DEFAULT_MANA)
        {
        }

        public Hero(string name, int health, int level, int mana)
            : this(name, health, level, mana, GenerateDefaultClass())
        {
        }

        public Hero(string name, int health, int level, int mana, HeroClassType heroClass)
            : this(name, health, level, mana, heroClass, SetPrivateAtribute(heroClass))
        {
        }

        public Hero(string name, int health, int level, int mana, HeroClassType heroClass, PrimaryAttribute privateAttribute)
        {

            this.Name = name;
            this.Health = health;
            this.Level = level;
            this.Mana = mana;
            this.HeroClass = heroClass;
            this.PrivateAttribute = privateAttribute;
            //this.HeroWeapon = new Weapon(this.HeroClass);
            //this.HeroArmor = new Armor(this.HeroClass);
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
                if (value.Length < MIN_NAME_WIDTH || value.Length > MAX_NAME_WIDTH)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Hero name must be between {0} and {1} symbols!", MIN_NAME_WIDTH, MAX_NAME_WIDTH));
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
                if (value < MIN_HEALTH || value > MAX_HEALTH)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Health must be a value between {0} adn {1}!", MIN_HEALTH, MAX_HEALTH));
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

        public Weapon HeroWeapon { get; private set; }

        public Armor HeroArmor { get; private set; }

        // Methods
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
                attribute = PrimaryAttribute.intelligence;
            }
            else if (heroClass == HeroClassType.Fighter)
            {
                attribute = PrimaryAttribute.agility;
            }
            else if (heroClass == HeroClassType.Tank)
            {
                attribute = PrimaryAttribute.strength;
            }
            else
            {
                throw new NotSupportedException("Invalid hero class! Available hero classes are: Sorcerer, Fighter and Tank");
            }

            return attribute;
        }

        public void GetWeapon(string weaponType = DEFAULT_ITEM_CLASS, int damage = DEFAULT_DAMAGE)
        {
            this.HeroWeapon = new Weapon(this.HeroClass, damage, weaponType);
        }

        public void GetArmor(int damageBlocked = DEFAULT_DAMAGE_BLOCK, string armorItemType = DEFAULT_ITEM_CLASS, ArmorType armorType = DEFAULT_ARMOR_TYPE)
        {
                this.HeroArmor = new Armor(armorType, damageBlocked, armorItemType);
        }

        // Classes
        internal class Weapon : ItemClass
        {
            //Define a class Weapon which holds the following information: type(enumeration  Sword, Hammer, Staff, etc. ),  class (common, rare, mythical), damage.
            
            private int weaponDamage;
            
            public Weapon(HeroClassType heroClass, int damage, string curItemClass)
                : base(curItemClass)
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
                    throw new NotSupportedException("There is no such weapan available for this hero class. Available weapons are: Sword used by Fighter, Staff used by Sorcerer, Hammer used by Tank");
                }

                this.WeaponDamage = damage;
            }

            public WeaponType HeroWeapon { get; private set; }

            public int WeaponDamage
            {
                get
                {
                    return this.weaponDamage;
                }
                set
                {
                    if (value < MIN_WEAPON_DAMAGE || value > MAX_WEAPON_DAMAGE)
                    {
                        throw new ArgumentOutOfRangeException("Weapon damage must be betwenn 5 and 50!");
                    }

                    this.weaponDamage = value;
                }
            }
        }
        
        internal class Armor : ItemClass
        {
            //damageBlock, type (cask, shield etc), class (same as above).

            private int damageBlocked;
            
            public Armor(ArmorType armorType, int damageBlocked, string curArmorType)
                : base(curArmorType)
            {
                this.HeroArmor = armorType;
                this.DamageBlocked = damageBlocked;
            }

            public int DamageBlocked
            {
                get
                {
                    return this.damageBlocked;
                }
                set
                {
                    if (value < MIN_ARMOR_BLOCK || value > MAX_ARMOR_BLOCK)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("Block armor must be between {0} and {1}", MIN_ARMOR_BLOCK, MAX_ARMOR_BLOCK));
                    }

                    this.damageBlocked = value;
                }
            }

            public ArmorType HeroArmor { get; private set; }

        }

        internal class ItemClass
        {
            // common, rare, mythical

            public ItemClass(string curItemClass)
            {
                this.CurItemClass = curItemClass;
            }

            public string CurItemClass { get; private set; }
        }

    }

    class EntryPoint
    {
        static void Main()
        {
            Hero firstHero = new Hero();
            Console.WriteLine(firstHero.Name);
            Console.WriteLine(firstHero.Health);
            Console.WriteLine(firstHero.Level);
            Console.WriteLine(firstHero.Mana);
            Console.WriteLine(firstHero.HeroClass);
            Console.WriteLine(firstHero.PrivateAttribute);

            firstHero.GetWeapon("Mythical", 30);

            Console.WriteLine(firstHero.HeroWeapon.HeroWeapon);
            Console.WriteLine(firstHero.HeroWeapon.WeaponDamage);
            Console.WriteLine(firstHero.HeroWeapon.CurItemClass);

            Hero secondHero = new Hero();
            Console.WriteLine(secondHero.Name);
            Console.WriteLine(secondHero.Health);
            Console.WriteLine(secondHero.Level);
            Console.WriteLine(secondHero.Mana);
            Console.WriteLine(secondHero.HeroClass);
            Console.WriteLine(secondHero.PrivateAttribute);

            secondHero.GetWeapon("common");

            Console.WriteLine(secondHero.HeroWeapon.HeroWeapon);
            Console.WriteLine(secondHero.HeroWeapon.WeaponDamage);
            Console.WriteLine(secondHero.HeroWeapon.CurItemClass);

            Hero sorcerer = new Hero("Neda", 180, 2, 460, HeroClassType.Sorcerer, PrimaryAttribute.agility);
            Console.WriteLine(sorcerer.Name);
            Console.WriteLine(sorcerer.Health);
            Console.WriteLine(sorcerer.Level);
            Console.WriteLine(sorcerer.Mana);
            Console.WriteLine(sorcerer.HeroClass);
            Console.WriteLine(sorcerer.PrivateAttribute);

            sorcerer.GetWeapon("rare", 25);

            Console.WriteLine(sorcerer.HeroWeapon.HeroWeapon);
            Console.WriteLine(sorcerer.HeroWeapon.WeaponDamage);
            Console.WriteLine(sorcerer.HeroWeapon.CurItemClass);

            sorcerer.GetArmor();

            Console.WriteLine(sorcerer.HeroArmor.HeroArmor);
            Console.WriteLine(sorcerer.HeroArmor.DamageBlocked);
            Console.WriteLine(sorcerer.HeroArmor.CurItemClass);
        }
    }
}
