namespace Substring
{
    using Substring.Extension;
    using System;
    using System.Text;

    class EntryPoint
    {
        static void Main()
        {
            StringBuilder myString = new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipiscing elit.In elementum nunc orci, ut iaculis augue accumsan quis. ");

            Console.WriteLine(myString.Substring(0, 10));
        }
    }
}
