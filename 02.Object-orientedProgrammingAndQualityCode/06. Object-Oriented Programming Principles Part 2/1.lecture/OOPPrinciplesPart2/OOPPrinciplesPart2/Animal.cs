
namespace OOPPrinciplesPart2
{
    using OOPPrinciplesPart2.Interfaces;

    public abstract class Animal:IAnimal
    {
        public string Name { get; private set; }
        public Animal(string name)
        {
            this.Name = name;
        }

        public virtual string Speak()
        {
            return string.Format("I am {0}.", this.Name);
        }
    }
}
