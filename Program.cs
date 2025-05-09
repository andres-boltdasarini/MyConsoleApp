
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;



class Program
{

    static void Main(string[] args)
    {
        string text = File.ReadAllText("C:\\Users\\user\\source\\repos\\MyConsoleApp\\input.txt");

        var timer = new Stopwatch();

        List<char> list = new List<char>();
        LinkedList<char> linklist = new LinkedList<char>();

        timer.Restart();
        foreach (var ch in text)
        {
            list.Add(ch);
        }
        timer.Stop();

        Console.WriteLine($"List.Add: {timer.ElapsedMilliseconds} ms");

        timer.Restart();
        foreach (var ch in text)
        {
            linklist.AddLast(ch);
        }
        timer.Stop();

        Console.WriteLine($"LinkedList.AddLast: {timer.ElapsedMilliseconds} ms");


        timer.Restart();
        foreach (var ch in text)
        {
            list.Insert(0, ch); // Вставка в начало
        }
        timer.Stop();

        Console.WriteLine($"List.Insert(0): {timer.ElapsedMilliseconds} ms");


        timer.Restart();
        foreach (var ch in text)
        {
            linklist.AddFirst(ch);
        }
        timer.Stop();

        Console.WriteLine($"LinkedList.AddFirst: {timer.ElapsedMilliseconds} ms");
    }
}



