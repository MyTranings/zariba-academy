namespace ExtensionMethods.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class ListExtensions
    {
        //Adding a value to each member of a list<integers>
        public static void IncreaseWithNumber(this List<int> myList, int number)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                myList[i] += number;
            }
        }
    }
}
