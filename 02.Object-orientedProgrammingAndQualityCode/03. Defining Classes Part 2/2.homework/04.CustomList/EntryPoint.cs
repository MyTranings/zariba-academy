namespace CustomList
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main()
        {
            MyList<int> firstList = new MyList<int>();

            firstList.Add(5);
            firstList.Add(10);
            firstList.Add(15);
            firstList.Add(20);

            firstList.Add(25);
            firstList.Add(30);
            firstList.Add(35);
            firstList.Add(45);

            firstList.Add(50);
            firstList.Add(55);

            firstList.Add(5);

            Console.WriteLine(firstList[3]);

            firstList.Remove(3);
            Console.WriteLine(firstList.FindIndex(5));

            firstList.InsertElement(3, 12);

            Console.WriteLine(firstList.ToString());

            firstList.Clear();

            List<int> orList = new List<int>();
            
            orList.Add(5);
            orList.Add(10);
            orList.Add(15);
            orList.Add(20);

            orList.Add(25);
            orList.Add(30);
            orList.Add(35);
            orList.Add(45);

            orList.Add(50);
            orList.Add(55);

            orList.Remove(orList[5]);

            Console.WriteLine(orList.Capacity);
            Console.WriteLine(orList[4]);

            orList.Clear();

            Console.WriteLine();
        }

    }
}
