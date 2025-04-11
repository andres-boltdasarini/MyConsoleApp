using System;

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
    static void Main()
    {
        ICalculator calculator = new Calculator();
        double a = GetValidNumber("первое");
        double b = GetValidNumber("второе");
        double sum = calculator.Add(a,b);
        Console.WriteLine($"сумма {sum}");
    }

    static double GetValidNumber(string prompt)
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"Введите {prompt} число");
                return GetNumberFromUser();
            }
            catch (FormatException)
            {
                Console.WriteLine("Число не корректно");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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