namespace BunniesVersusZombies.Bullets
{
    public class Carrot
    {
        public Carrot(int damage, string colour)
        {
            this.Damage = damage;
            this.Colour = colour;
        }

        public int Damage { get; private set; }

        public string Colour { get; private set; }
    }
}
