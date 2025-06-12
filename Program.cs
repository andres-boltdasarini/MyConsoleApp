public abstract class Account
{
    public double Balance { get; set; }
    public double Interest { get; set; }

    public abstract void CalculateInterest();
}

public class RegularAccount : Account
{
    public override void CalculateInterest()
    {
        Interest = Balance * 0.4;

        if (Balance < 1000)
            Interest -= Balance * 0.2;
        else if (Balance >= 1000)
            Interest -= Balance * 0.4;
    }
}

public class SalaryAccount : Account
{
    public override void CalculateInterest()
    {
        Interest = Balance * 0.5;
    }
}

public static class Calculator
{
    public static void CalculateInterest(Account account)
    {
        account.CalculateInterest();
    }
}


class Program
{
    static void Main(string[] args)
    {

        var regularAccount = new RegularAccount { Balance = 500 };
        var salaryAccount = new SalaryAccount { Balance = 5000 };

        Calculator.CalculateInterest(regularAccount);
        salaryAccount.CalculateInterest();

        Console.WriteLine($"Обычный счёт: {regularAccount.Interest}");
        Console.WriteLine($"Зарплатный счёт: {salaryAccount.Interest}");
    }
}