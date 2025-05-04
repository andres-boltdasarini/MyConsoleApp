using System;
using System.IO;
class FileWriter;

class Program
{
    static void Main(string[] args)
    {

        var book = new List<List<string>>();
        //string filePath = @"/Users/user/source/repos/MyConsoleApp/cdev_Text.txt";
        string text = File.ReadAllText("C:\\Users\\user\\source\\repos\\MyConsoleApp\\cdev_Text.txt");

        // Сохраняем символы-разделители в массив
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //Если между разделителями нет данных, метод может вернуть пустые строки.
        //Чтобы их убрать, используйте StringSplitOptions.RemoveEmptyEntries

            Console.WriteLine(words.Length);
        
    }
}