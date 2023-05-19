namespace ExtensionMethods.Extensions
{
    using System;
    public static class StringExtensions
    {
        public static int CountWords(this string input)
        {
            return input.Split(' ').Length;
        }
    }
}
