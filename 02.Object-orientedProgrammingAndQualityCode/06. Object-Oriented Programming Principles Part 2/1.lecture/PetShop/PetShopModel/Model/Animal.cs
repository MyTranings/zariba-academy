
namespace PetShopModel.Model
{
    using System;
    using PetShopModel.Interfaces;

    public abstract class Animal: IAnimal
    {
        public Animal()
        {
            this.IsAlive = true;
        }

        public Animal(string name, int age, int weight, string colour)
            :this()
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.Colour = colour;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Weight { get; private set; }
        public string Colour { get; private set; }
        public bool IsAlive { get; private set; }

        

        public string Eat(Food food)
        {
            return "I ate some food " + food.Taste;
        }

        public void Reproduce()
        {
        }

        public void Die()
        {
            this.IsAlive = false;
        }

        public abstract void Move();
       
    }
}
