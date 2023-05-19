using System;

class AllVariations
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        Console.Write("Enter variantion number: ");
        int k = int.Parse(Console.ReadLine());

        GetVariantions(arr, 0, n);
    }

    private static void GetVariantions(int[] arr, int index, int elements)
    {
        if (index == arr.Length)
        {
            PrintVairants(arr);
        }
        else
        {
            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                GetVariantions(arr, index + 1, elements);
            }
        }
    }

    private static void PrintVairants(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
