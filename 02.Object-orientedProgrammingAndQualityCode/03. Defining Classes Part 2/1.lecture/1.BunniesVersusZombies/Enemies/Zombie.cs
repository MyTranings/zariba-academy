namespace BunniesVersusZombies.Enemies
{
    using BunniesVersusZombies.Allies;

    public class Zombie
    {
        public Zombie(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public void TakeDamage(int damage)
        {
            this.Health = this.Health - damage;
        }

        public void Attack(Bunny bunny)
        {
            bunny.TakeDamage(this.Damage);
        }

        public override string ToString()
        {
            return "Zombie Health: " + this.Health;
        }
    }
}
