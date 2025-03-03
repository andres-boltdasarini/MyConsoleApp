using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static bool CheckNumBool(string number, out int corrnumber)
    {
        if (int.TryParse(number, out int intnum))
        {
            if (intnum > 0)
            {
                corrnumber = intnum;
                return false;
            }
        }
        corrnumber = 0;
        return true;
    }

    static int CheckNum(string promp)
    {
        int intage;
        string text;
        do
        {
            Console.WriteLine($"Введите {promp}");
            text = Console.ReadLine();
                if (!CheckNumBool(text, out intage))
            {
                return intage;
            }
            Console.WriteLine("Некорректный ввод. (не число или число меньше 1).");
        } while (true);
    }

    static string CheckString(string promp)
    {
        string input;
        do
        {
            Console.WriteLine($"Введите {promp}");
            input = Console.ReadLine();
            if (!int.TryParse(input, out _))
            {
                return input;
            }
            Console.WriteLine("Некорректный ввод. (не строка).");
        } while (true);
    }

    static (string Name, string Last, int Age, string[] Petname, string[] Colors) GetUserData()
    {
        string firstName = CheckString("имя");
        string lastName = CheckString("фамилию");
  
        int intage = CheckNum("возраст");


        string petinput = CheckString("Есть ли у вас питомец? (да/нет)");
        bool pet = petinput == "да";
        int petmany;
        string[] petname = {};
        if (pet)
        {
            petmany = CheckNum("количество питомцев");
            petname = Petname(petmany);
        }
        int colormany = CheckNum("количество любимых цветов");
        string[] colors = {};
        colors = Favcolors(colormany);

        return (firstName, lastName, intage, petname, colors);
    }

    static string[] Petname(int petmany)
    {
        var petname = new string[petmany];
        for(int i = 0; i < petname.Length; i++)
        {
            petname[i] = CheckString($"{i+1} кличку питомца");
        }
        return petname;
    }

    static string[] Favcolors(int colormany)
    {
        string[] favcolors = new string[colormany];
        for (int i = 0; i < favcolors.Length; i++)
        {
            favcolors[i] = CheckString($"{i+1} любимый цвет");
        }
        return favcolors;
    }

    static void ShowUserData((string Name, string Last, int Age, string[] Petname, string[] Colors) userData)
    {
        Console.WriteLine("\nДанные пользователя:");
        Console.WriteLine($"Имя: {userData.Name}");
        Console.WriteLine($"Фамилия: {userData.Last}");
        Console.WriteLine($"Возраст: {userData.Age}");

        if (userData.Petname.Length > 0)
        {
            Console.WriteLine("Клички питомцев:");
            foreach (var name in userData.Petname)
            {
                Console.WriteLine($"- {name}");
            }
        }
        else
        {
            Console.WriteLine("Питомцев нет.");
        }

        Console.WriteLine("Любимые цвета:");
        foreach (var color in userData.Colors)
        {
            Console.WriteLine($"- {color}");
        }
    }

    static void Main(string[] args)
    {
        var userData = GetUserData();
        ShowUserData(userData);
    }
}

