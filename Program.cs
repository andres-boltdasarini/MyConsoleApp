using System;

public interface ILogger
{
    void Event(string message);
    void Error(string message);
}

public class Logger : ILogger
{
    public void Event(string message)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(message);
    }
    public void Error(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(message);
    }
}

interface ICalculator
{
    public double Add(double a, double b);
}

class Calculator : ICalculator
{
    public double Add(double a, double b) => a + b;

}

class Program
{
    static ILogger Logger { get; set; }
    static void Main()
    {
        Logger = new Logger();


        ICalculator calculator = new Calculator();
        double a = GetValidNumber("первое", Logger);
        double b = GetValidNumber("второе", Logger);
        double sum = calculator.Add(a, b);
        Logger.Event($"сумма {sum}");
    }

    static double GetValidNumber(string prompt, ILogger logger)
    {
        while (true)
        {
            try
            {
                Logger.Event($"Введите {prompt} число"); 
                return GetNumberFromUser();
            }
            catch (FormatException)
            {
                Logger.Error("Число не корректно");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }

    }

    static double GetNumberFromUser()
    {
        string? input = Console.ReadLine();
        if (double.TryParse(input, out double number))
        {
            return number;
        }
        else throw new FormatException();
    }
}