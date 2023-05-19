namespace _4.ActionsAndFuncs
{
    using System;
    using System.Collections.Generic;

    class ActionsAndFuncs
    {
        public static void TestMethod(string a, int b)
        {
            Console.WriteLine("I was called by a delegate with params: {0},{1}", a, b);
        }
        public static void AnotherTestMethod(string a, int b)
        {
            Console.WriteLine("I was the second function called by the delegate: text = {0}", a);
        }
        public static void ExecuteDelegate(Action<string, int> d)
        {
            d("b", 0);
        }
        public static int TheAnswerToEverything(string text, long bigNumber, List<dynamic> weirdList)
        {
            Console.WriteLine("I was called by a Func delegate with parameters: {0},{1},{2}",text,bigNumber,weirdList.ToString());
            return 42;
        }
        public static int TheAnswerToNothing(string text, long bigNumber, List<dynamic> weirdList)
        {
            Console.WriteLine("I am the second method in a func");
            return -5;
        }
        static void Main()
        {
            Action<string,int> d1 = TestMethod; 
            d1 += AnotherTestMethod;
            d1 += AnotherTestMethod;
            d1 += TestMethod;
            d1 -= TestMethod;
            d1 += delegate (string name, int age)
            {
                Console.WriteLine("My name is {0} and I am {1} years old ", name, age);

            };
            d1("bunny1", 5);
            Console.WriteLine();

            Func<string, long, List<dynamic>, int> myFunc = TheAnswerToEverything;
            myFunc += TheAnswerToNothing;
            int result = myFunc("kkk",56,new List<dynamic>());
            Console.WriteLine(result);
        }
    }
}

