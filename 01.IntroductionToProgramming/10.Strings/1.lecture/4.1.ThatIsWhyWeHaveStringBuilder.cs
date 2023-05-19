using System;
using System.Text;

class BasicOperationsStringBuilder
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string str1 = "some";
        string str2 = "string";
        string str3 = "demosaaaaaaaaaaaaaaaaaaa";
        sb.Append(str1);
        sb.Append(str2);
        sb.Append(str3);
        sb.Append(str3);
        Console.WriteLine(sb);
        Console.WriteLine(sb.Length);
        Console.WriteLine(sb.Capacity);
        Console.WriteLine(sb.MaxCapacity);
        Console.WriteLine(sb[3]);
        sb[3] = 'a';
        Console.WriteLine(sb[3]);
        //this is bad! string result = str1 + str2 + str3;
    }
}

