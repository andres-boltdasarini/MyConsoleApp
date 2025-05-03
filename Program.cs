using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;



class Program
{
    static void Main(string[] args)
    {
        Estimate(20);
    }

    static void CreateMatrix(int n)
    {
        var matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = i + j;
            }
        }
    }

    static void Estimate(int n)
    {
        var Tm = new List<int>();
        var timer = new Stopwatch();

        for (int i = 0; i < n; i++)
        {
            timer.Restart();
            CreateMatrix(10000);
            timer.Stop();

            long elapsedMs = timer.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            Tm.Add((int)elapsedMs); // Добавляем в список, а не обращаемся по индексу
            Tm.Sort(); // Сортируем (можно вынести за цикл, если не нужно на каждой итерации)

            long mid = ((long)Tm[0] + Tm[Tm.Count - 1]) / 2; // Защита от переполнения
            Console.WriteLine($"Медиана: {mid}");
        }
    }
}