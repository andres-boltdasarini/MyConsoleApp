class Bus
{
    public int? Load;

    public void PrintStatus()
    {
        if (Load.HasValue && Load > 0)
        {
            Console.WriteLine($"В автобусе {Load} пассажиров.");
        }
        else
        {
            Console.WriteLine("Автобус пуст.");
        }
    }
}
class Program
{
    static void Main()
    {
        Bus bus1 = new Bus { Load = 10 };
        bus1.PrintStatus(); // Вывод: В автобусе 10 пассажиров.

        Bus bus2 = new Bus { Load = 0 };
        bus2.PrintStatus(); // Вывод: Автобус пуст.

        Bus bus3 = new Bus { Load = null };
        bus3.PrintStatus(); // Вывод: Автобус пуст.
    }
}