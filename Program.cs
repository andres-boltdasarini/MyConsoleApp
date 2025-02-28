using System;

class MainClass
{
    // Метод для выбора цвета
    static string ShowColor()
    {
        Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
        var color = Console.ReadLine();

        switch (color)
        {
            case "red":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Your color is red!");
                break;

            case "green":
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Your color is green!");
                break;

            case "cyan":
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Your color is cyan!");
                break;

            default:
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your color is yellow!");
                color = "yellow"; // Присваиваем значение по умолчанию
                break;
        }

        // Возвращаем выбранный цвет
        return color;
    }

    public static void Main(string[] args)
    {
        var (name, age) = ("Евгения", 27);

        Console.WriteLine("Мое имя: {0}", name);
        Console.WriteLine("Мой возраст: {0}", age);

        Console.Write("Введите имя: ");
        name = Console.ReadLine();
        Console.Write("Введите возраст цифрами: ");
        age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ваше имя: {0}", name);
        Console.WriteLine("Ваш возраст: {0}", age);

        // Массив для хранения трех цветов
        string[] favColors = new string[3];

        // Цикл для ввода трех цветов
        for (int i = 0; i < favColors.Length; i++)
        {
            favColors[i] = ShowColor(); // Записываем результат метода в массив
        }

        // Выводим все цвета из массива
        Console.WriteLine("Ваши любимые цвета:");
        foreach (var color in favColors)
        {
            Console.WriteLine(color);
        }
    }
}