namespace GenericsIndexersAndOperators
{
    using System;
    using System.Collections.Generic;
    class GenericsTest
    {
        //boxing -> when you convert from value types to reference
        static void Main()
        {
            List<string> randomList = new List<string>();
            randomList.Add("a");
            bool equal = Calculator.AreEqual('a', 'a');
            System.Console.WriteLine(equal);
            int[] myIntArray = { 2, 3, 6, 1, -1, 2, 1, 0 };
            string[] myStrArray = { "Academy", "Zar", "Zariba", "Bunny", "Tea", "T","Pesho"};
            Console.WriteLine(string.Join(", ",Calculator.Sort(myStrArray)));
            Console.WriteLine(randomList.Capacity);

            MyList<double> doubleList = new MyList<double>();
            MyList<double> doubleListNumberTwo = new MyList<double>();

            doubleList.Add(1);
            doubleList.Add(5);
            doubleList.Add(7);

            doubleListNumberTwo.Add(2);
            doubleListNumberTwo.Add(3);
            doubleListNumberTwo.Add(4);

            Console.WriteLine(doubleList.ToString());
            Console.WriteLine(doubleListNumberTwo.ToString());

            MyList<double> result = doubleList + doubleListNumberTwo;
            Console.WriteLine(result.ToString());

            MyList<string> stringList = new MyList<string>();
            MyList<string> stringListNumberTwo = new MyList<string>();

            stringList.Add("asd");
            stringList.Add("bas");

           
            stringListNumberTwo.Add("a");
            stringListNumberTwo.Add("b");

            Console.WriteLine(stringList.ToString());
            Console.WriteLine(stringListNumberTwo.ToString());

            MyList<string> resultString = stringList + stringListNumberTwo;
            Console.WriteLine(resultString.ToString());
        }
    }

    public class Calculator 
    {
        public static bool AreEqual<T>(T value1, T value2) where T:IComparable<T>
        {
            return value1.CompareTo(value2)==0;
        }

        public static T[] Sort<T>(T[] arrayToSort) where T:IComparable<T>
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = i+1; j < arrayToSort.Length; j++)
                {
                    if (arrayToSort[i].CompareTo(arrayToSort[j])>0)
                    {
                        T temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[j];
                        arrayToSort[j] = temp;
                    }
                }
            }
            return arrayToSort;
        }
    }
}
