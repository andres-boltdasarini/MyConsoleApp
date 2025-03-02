using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class MainClass
{
    static int[] GetArrayFromConsole(int num = 5)
    {
        var result = new int[num];
        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine("Введите элемент массива номер {0}", i + 1);
            result[i] = int.Parse(Console.ReadLine());
        }
        return result;
    }

    static void SortArray(in int[] array, out int[] sorteddesc, out int[] sortedasc)
    {
        sorteddesc = SortArrayDesc(array);
        sortedasc = SortArrayAsc(array);
    }

    static int[] SortArrayDesc(int[] result)
    {
        int temp = 0;
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = i + 1; j < result.Length; j++)
            {
                if (result[i] < result[j])
                {
                    temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    static int[] SortArrayAsc(int[] result)
    {
        int temp = 0;
        for (int i = 0; i < result.Length; i++)
        {
            for (int j = i + 1; j < result.Length; j++)
            {
                if (result[i] > result[j])
                {
                    temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    static void ShowArray(int[] array, bool isSort = false)
    {
        var temp = array;
        if (isSort)
        {
            SortArray(array);
        }

        foreach (var item in temp)
        {
            Console.WriteLine(item);
        }
    }

    public static void Main(string[] args)
    {
        var array = GetArrayFromConsole(10);
        ShowArray(array, true);
    }
}