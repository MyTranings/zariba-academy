namespace PetShopModel.Model
{
    public class ClownFish:Fish
    {
        public int NumberOfStripes { get; private set; }

        public ClownFish()
        {

        } 

        public ClownFish(int age, int weight, string colour, int finLength, int numberOfStripes)
            :base("Nemo", age, weight, colour,colour,finLength)
        {
            this.NumberOfStripes = numberOfStripes;
        }

        public override void Move()
        {
            base.Move();
            System.Console.WriteLine("I am a clown fish.");
        }
    }
}
