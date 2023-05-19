
namespace PetShopModel.Model
{
    using PetShopModel.Enumerations;
    using PetShopModel.Interfaces;
    using System.Collections.Generic;
    using System;

    public class Bunny:Mammal, IPet, IAnimal
    {
        public Bunny()
        {

        }

        public Bunny(string name, int age, int weight, string colour, Gender gender,int earLength, double furDensity)
            :base(name,age,weight,colour,gender)
        {
            this.EarLength = earLength;
            this.FurDensity = furDensity;
        }

        public int EarLength { get; private set; }
        public double FurDensity { get; private set; }

        public string Owner { get; private set; }

        public string InvokeHappiness()
        {
            return "Being Cute";
        }

        public string Jump()
        {
            return "Jump Around... This is different from Move.";
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("I am Bunny");
        }
    }
}
