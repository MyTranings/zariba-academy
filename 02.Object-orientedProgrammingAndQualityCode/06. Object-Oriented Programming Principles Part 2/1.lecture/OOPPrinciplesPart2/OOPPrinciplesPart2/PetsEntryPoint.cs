namespace OOPPrinciplesPart2
{
    using System;
    using Interfaces;
    using System.Collections.Generic;

    public class PetsEntryPoint
    {
        public static void AnimalSpeak(IAnimal animal)
        {
            Console.WriteLine(animal.Speak());
        }
        public static void Main()
        {
            List<IAnimal> animalsList = new List<IAnimal>();
            IAnimal firstCat = new Cat("Pesho");
            Cat secondCat = new Cat("Gosho");
            Dog firstDog = new Dog("Spas");
            Dog secondDog = new Dog("Scooby-Doo");

            animalsList.Add(firstCat);
            animalsList.Add(firstDog);
            animalsList.Add(secondCat);
            animalsList.Add(secondDog);

            PrintAnimalStuff(animalsList);

            IAnimal animal;







            string animalName = "Cat";
            switch (animalName)
            {
                case "Cat": animal = new Cat("Pesho");break;
                case "Dog": animal = new Dog("Gosho");break;
                default:
                    break;
            }

        }

        private static void PrintAnimalStuff(List<IAnimal> animalsList)
        {
            foreach (var animal in animalsList)
            {
                
                //BAD CODE.
                if (animal is Cat)
                {
                    Cat newCat = animal as Cat;
                    Console.WriteLine(newCat.Mrrr());
                }
                Console.WriteLine(animal.Speak());
            }
        }
    }
}
