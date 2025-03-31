using System;
using System.Runtime;

namespace DirectoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCatalogs(); //   Вызов метода получения директорий
            Getall();
            Desktop();
        }

        static void GetCatalogs()
        {
            string dirName = @"C:\\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога
                int sum = files.Length + dirs.Length;
                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
                Console.WriteLine($"количество обьектов: {sum}");
                

            }
        }
        static public void Getall()
        {

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/" /* Или С:\\ для Windows */ );
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }

                DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                if (!newDirectory.Exists)
                    newDirectory.Create();

                Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                newDirectory.Delete(true);
                Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
        static public void Desktop()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/luft/Desktop/testFolder");
                string trashPath = "/Users/luft/.Trash/testFolder";

                dirInfo.MoveTo(trashPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}