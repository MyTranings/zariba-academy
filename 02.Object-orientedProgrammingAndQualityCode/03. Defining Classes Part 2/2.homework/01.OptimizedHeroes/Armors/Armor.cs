namespace OptimizedHeroes.Armors
{
    using System;
    using Enumerations;

    public class Armor
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
}
