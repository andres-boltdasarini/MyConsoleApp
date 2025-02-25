using System;

class MainClass
{
    public static void Main(string[] args)
    {
        int[,] arr = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };

        // Проходим по каждой строке массива
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            // Сортировка элементов в текущей строке
            for (int j = 0; j < arr.GetLength(1) - 1; j++)
            {
                for (int k = j + 1; k < arr.GetLength(1); k++)
                {
                    if (arr[i, j] > arr[i, k])
                    {
                        // Меняем местами элементы, если они находятся в неправильном порядке
                        int temp = arr[i, j];
                        arr[i, j] = arr[i, k];
                        arr[i, k] = temp;
                    }
                }
            }
        }

        // Вывод отсортированного массива
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}