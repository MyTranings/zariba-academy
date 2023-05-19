namespace Substring.Extension
{
    using System;
    using System.Text;

    public static class StringBuilderExtension
    {
        public static string Substring(this StringBuilder myString, int index, int length)
        {
            string result = string.Empty;

            //result = myString.ToString(index, length);

            int newStringLength = index + length;

            for (int i = index; i < newStringLength; i++)
            {
                result += myString[i];
            }

            return result;
        }
    }
}
