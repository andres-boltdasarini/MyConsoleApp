using System;

class MainClass
{
    static int[] GetArrayFromConsole()
    {
        var arr = new int[5];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Введите элемент массива номер {0}", i + 1);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int temp;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        foreach (var item in arr)
        {
            Console.Write(item);
        }

        return arr;
    }

    public static void Main(string[] args)
    {
        GetArrayFromConsole();
    }
}