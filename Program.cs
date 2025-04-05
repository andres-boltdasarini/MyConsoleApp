using System;

public class Program
{
    public static void Main()
    {
        Exception[] exceptions = new Exception[] {
            new MyCustomException("Пользовательская ошибка"),
            new ArgumentNullException("Ошибка аргумента"),
            new FileNotFoundException("Ошибка файла", "file.txt"),
            new PathTooLongException("Ошибка пути"),
            new OverflowException("Ошибка переполнения")
        };

        foreach (var exception in exceptions)
        {
            try
            {
                throw exception;
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine($"text: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"text2: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"text3: {ex.Message}, text3: {ex.FileName}");
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"text4: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"text5: {ex.Message}");
            }

        }
        NumberReader numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += ShowNumber;

        while (true)
        {
            try
            {
                numberReader.Read();
            }
            catch (MyCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введите число!");
            }
        }

        static void ShowNumber(int number, List<string> surnames)
        {
            Console.WriteLine("\nРезультат сортировки:");
            switch (number)
            {
                case 1:
                    surnames.Sort();
                    break;
                case 2:
                    surnames.Sort();
                    surnames.Reverse();
                    break;
            }
            foreach (var surname in surnames)
            {
                Console.WriteLine(surname);
            }
        }
    }
}

public class MyCustomException : FormatException
{
    private string _message;

    public MyCustomException(string message)
    {
        _message = message;
    }
    public override string Message
    {
        get { return _message; }
    }
}
class NumberReader
{
    public delegate void NumberEnteredDelegate(int number, List<string> surnames);
    public event NumberEnteredDelegate NumberEnteredEvent;
    private List<string> surnames = new List<string> { "Иванов", "Петров", "Сидоров", "Абрамов", "Козлов" };

    public void Read()
    {
        Console.WriteLine("\nВведите 1 для сортировки А-Я или 2 для Я-А");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number != 1 && number != 2)
        throw new MyCustomException("Ошибка: введите только 1 или 2");
        NumberEntered(number);
    }

    protected virtual void NumberEntered(int number)
    {
        NumberEnteredEvent?.Invoke(number, surnames);
    }
}