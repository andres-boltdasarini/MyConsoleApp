using System;

public class MyCustomException : Exception
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

public class Program
{
    public static void Main()
    {
        Exception[] exceptions = new Exception[] { 
            new MyCustomException("my"),
            new ArgumentNullException("not null"),
            new FileNotFoundException("file not found", "file.txt"),
            new FormatException("err data"),
            new OverflowException("arph over")
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
            catch (FormatException ex)
            {
                Console.WriteLine($"text4: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"text5: {ex.Message}");
            }

        }

    }
}