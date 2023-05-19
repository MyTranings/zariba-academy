// 2. Write a program that reads two arrays from the console and compares them element by element.

using System;

class ConsoleArrays
{
	public static void Main ()
	{
		Console.Write ("Enter a sequence of numbers separeted by space: ");
		string[] input1 = Console.ReadLine ().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        bool isThereEqual = false;

		Console.Write ("Enter a sequence of numbers separeted by space: ");
		string[] input2 = Console.ReadLine ().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input1.Length; i++)
        {
            for (int j = 0; j < input2.Length; j++)
            {
                if (input1[i] == input2[j])
                {
                    Console.WriteLine("Both arrays have this value: {0}", input1[i]);
                    isThereEqual = true;
                }
            }
        }

        if (!isThereEqual)
        {
            Console.WriteLine("There no equal elements");
        }
	}
}