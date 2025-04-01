using System;

public class MyCustomException : Exception
{
    private string _message;
    private string _helpLink;

    public MyCustomException(string message, string helpLink)
    {
        _message = message;
        _helpLink = helpLink;
    }

    public override string Message
    {
        get { return _message; }
    }

    public override string HelpLink
    {
        get { return _helpLink; }
        set { _helpLink = value; }
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        try
        {
            throw new MyCustomException(
                "Это пользовательское исключение!",
                "https://example.com/help"
            );
        }
        catch (MyCustomException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Ссылка на справку: {ex.HelpLink}");
        }
    }
}