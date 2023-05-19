namespace IEnumerableExtensions.Extentions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public string T Sum(this IEnumerable myList)
        {
            int result = 0;

            foreach (var item in myList)
            {
                result += item;
            }

            return result;
        }
    }
}
