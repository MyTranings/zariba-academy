
namespace PetShopModel.Model
{
    using PetShopModel.Enumerations;

    public abstract class Mammal:Animal
    {
        public Gender Gender { get; private set; }
        public Mammal()
            :base()
        {

        }

        public Mammal(string name, int age, int weight, string colour, Gender gender)
            :base(name,age,weight,colour)
        {
            this.Gender = gender;
        }

        public override void Move()
        {
            System.Console.WriteLine("I like to move it move it!");
        }
    }
}
