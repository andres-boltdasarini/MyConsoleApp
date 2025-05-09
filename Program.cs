using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;



class Program
{

    static void Main(string[] args)
    {
        string text = File.ReadAllText("C:\\Users\\user\\source\\repos\\MyConsoleApp\\input.txt").ToLower();

        string noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        string[] words = noPunctuationText.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        var wordsQt = new Dictionary<string,int>();
        foreach (string word in words)
        {
            if (wordsQt.ContainsKey(word)) wordsQt[word] += 1;
            else wordsQt[word] = 1;
        }

        KeyValuePair<string, int>[] wordArray = wordsQt.ToArray();
        Array.Sort(wordArray, CompareByValueDescending);

        static int CompareByValueDescending(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return b.Value.CompareTo(a.Value); 
        }

        const int maxusewords = 10;

        for (int i = 0; i< maxusewords; i++)
        {
            Console.WriteLine($"{wordArray[i].Key}: {wordArray[i].Value}");
        }

    }
}



