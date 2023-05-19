namespace OptimizedHeroes.Weapons
{
    using System;
    using Enumerations;

    public class Weapon
    {
        private const ItemClass DEFAULT_ITEM_CLASS = ItemClass.Common;
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
                    string.Format("There is no such weapan available for this hero class. Available weapons are: {0} used by {1}, {2} used by {3}, {4} used by {5}", WeaponType.Sword, HeroClassType.Fighter, WeaponType.Staff, HeroClassType.Sorcerer, WeaponType.Hammer, HeroClassType.Tank));
            }

            this.WeaponDamage = damage;
            this.WeaponClass = weaponClass;
            this.damageChangeBy = this.CalcDamagePercentage();
        }

        public Weapon(WeaponType heroWeapon)
            : this(heroWeapon, MIN_WEAPON_DAMAGE, DEFAULT_ITEM_CLASS)
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
            this.damageChangeBy = this.CalcDamagePercentage();
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
                        string.Format("There is no such weapon available. Available weapons are: {0} used by {1}, {2} used by {3}, {4} used by {5}", WeaponType.Sword, HeroClassType.Fighter, WeaponType.Staff, HeroClassType.Sorcerer, WeaponType.Hammer, HeroClassType.Tank));
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
                    throw new ArgumentOutOfRangeException(string.Format("There is no such weapon class. The available classes are: {0}, {1} and {2}", ItemClass.Common, ItemClass.Rare, ItemClass.Mythical));
                }

                this.weaponClass = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Weapon: {0}, Damage: {1}, Class: {2}.", this.HeroWeapon, this.WeaponDamage, this.WeaponClass);
        }

        public void DecreaseAttack()
        {
            this.weaponDamage -= this.damageChangeBy;
        }

        public void RestoreAttack()
        {
            this.weaponDamage += this.damageChangeBy;
        }

        private float CalcDamagePercentage()
        {
            float decrement = this.WeaponDamage * (DECREASE_ATTACK_PERCENTAGE / 100);
            return decrement;
        }
    }
}
