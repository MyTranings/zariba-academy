namespace PetShopModel.Model
{
    public abstract class Fish:Animal
    {
        public Fish()
        {

        }
        public Fish(string name, int age, int weight, string colour, string scalesColor, int finLength)
            :base(name,age,weight,colour)
        {
            this.ScalesColor = scalesColor;
            this.FinLength = finLength;
        }

        public string ScalesColor { get; private set; }
        public int FinLength { get; private set; }

        public override void Move()
        {
            System.Console.WriteLine("Swimming");
        }

    }
}
