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
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(message);
    }
    public void Error(string message)
    {
        Console.WriteLine(message);
    }
}
public interface IWorker
{
    void Work();
}
public class Worker1: IWorker
{
    ILogger Logger { get; }
    public Worker1(ILogger logger)
    {
        Logger = logger;
    }

    public void Work()
    {
        Logger.Event("Worker1 начал свою работу");
        Thread.Sleep(3000);
        Logger.Event("Worker1 закончил свою работу");
    }
}
public class Worker2 : IWorker
{
    ILogger Logger { get; }
    public Worker2(ILogger logger)
    {
        Logger = logger;
    }

    public void Work()
    {
        Logger.Event("Worker2 начал свою работу");
        Thread.Sleep(3000);
        Logger.Event("Worker2 закончил свою работу");
    }
}
public class Worker3 : IWorker
{
    ILogger Logger { get; }
    public Worker3(ILogger logger)
    {
        Logger = logger;
    }

    public void Work()
    {
        Logger.Event("Worker3 начал свою работу");
        Thread.Sleep(3000);
        Logger.Event("Worker3 закончил свою работу");
    }
}

class Program
{
    static ILogger Logger { get; set; }
    static void Main()
    {
        Logger = new Logger();
        var worker1 = new Worker1(Logger);
        var worker2 = new Worker2(Logger);
        var worker3 = new Worker3(Logger);
        worker1.Work();
        worker2.Work();
        worker3.Work();
        Console.ReadKey();
    }
}