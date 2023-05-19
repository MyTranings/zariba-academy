
namespace _3.Delegates
{
    using System;

    public delegate void SomeDelegate(string text, int number);

    public static class DelegatesDemo
    {
        public static void TestMethod(string a, int b)
        {
            Console.WriteLine("I was called by a delegate with params: {0},{1}",a,b);
        }
        public static void AnotherTestMethod(string a, int b)
        {
            Console.WriteLine("I was the second function called by the delegate: text = {0}",a);
        }
        static void Main()
        {
            //Slightly longer
            //var d = new SomeDelegate(TestMethod);
            //Shorter
            SomeDelegate d1 = TestMethod; //shorter
            d1 += AnotherTestMethod;
            d1 += AnotherTestMethod;
            d1 += TestMethod;
            d1 -= TestMethod;
            d1 += delegate (string name, int age)
            {
                Console.WriteLine("My name is {0} and I am {1} years old ",name,age);
                
            };
            d1("bunny1", 5);
            d1 -= d1;
            d1 += TestMethod;
            d1("bunny1", 5);
            Console.WriteLine();
            
        }
        public static void ExecuteDelegate(SomeDelegate d)
        {
            d("b", 0);
        }
    }
}
