using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.EventsDemo1
{
    class EventsTest
    {
        static void Main(string[] args)
        {
            ListWithChangedEvents testList = new ListWithChangedEvents();
            testList.Add(1);
            testList.Changed += AttachedMethod;
            testList.Add(2);
            for (int i = 0; i < testList.Count; i++)
            {
                Console.WriteLine(testList[i]);
            }

        }
        public static void AttachedMethod(object sender, EventArgs e)
        {
            Console.WriteLine("I was called by a delegate on a changed event");
            Console.WriteLine("Object sender: {0}",sender);
            Console.WriteLine("Event Args: {0}",e);
        }
    }
}
