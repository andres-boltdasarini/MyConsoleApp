using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static bool CheckNum(string number, out int corrnumber)
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

    static (string Name, string Last, int Age) GetUserData()
    {
        Console.WriteLine("name");
        string firstName = Console.ReadLine();
        Console.WriteLine("sename");
        string lastName = Console.ReadLine();
        string age;
        int intage;
        do
        {
            Console.WriteLine("age");
            age = Console.ReadLine();
        } while (CheckNum(age, out intage));

        Console.WriteLine("pet");
        var petinput = Console.ReadLine();
        bool pet = petinput == "да";
        int petmany = 0;
        string[] petname = {};
        if (pet)
        {
            Console.WriteLine("petmany");
            petmany = Convert.ToInt32(Console.ReadLine());
            petname = Petname(petmany);
        }
        Console.WriteLine("colormany");
        int colormany = Convert.ToInt32(Console.ReadLine());
        Favcolors(colormany);

        return (firstName, lastName, intage);
    }

    static string[] Petname(int petmany)
    {
        var petname = new string[petmany];
        for(int i = 0; i < petname.Length; i++)
        {
            Console.WriteLine("name");
            petname[i] = Console.ReadLine();
        }
        return petname;
    }

    static string[] Favcolors(int colors)
    {
        string[] favcolors = new string[colors];
        Console.WriteLine($"Введите {colors} любимых цвета пользователя");

        for (int i = 0; i < favcolors.Length; i++)
        {
            favcolors[i] = Console.ReadLine();
        }
        return favcolors;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetUserData());
    }
}

