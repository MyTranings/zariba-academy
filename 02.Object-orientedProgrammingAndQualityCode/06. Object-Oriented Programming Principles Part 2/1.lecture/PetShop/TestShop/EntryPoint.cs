namespace TestShop
{
    using System;
    using System.Collections.Generic;
    using PetShopModel;
    using PetShopModel.Model;
    using PetShopModel.Interfaces;

    public class EntryPoint
    {
        public static void Main()
        {
            List<int> listInts = new List<int>{ 0, 1, 2, 3 };
            List<string> listString = new List<string> { "a", "b" };
            List<IAnimal> animalsInTheShop = new List<IAnimal>();
        }
        public static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
