
        using System;
        using System.IO;


class Task2
    {
        public static void Main()
        {
            var fileInfo = new FileInfo("/Users/user/source/repos/MyConsoleApp/Program.cs");

            using (StreamWriter sw = fileInfo.AppendText())
            {
                sw.WriteLine($"// Время запуска: {DateTime.Now}");
            }

            using (StreamReader sr = fileInfo.OpenText())
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    Console.WriteLine(str);

            }
        }
    }// Время запуска: 31.03.2025 14:47:54
