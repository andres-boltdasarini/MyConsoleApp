/// <summary>
/// Общий интерфейс отопительных котлов
/// </summary>
interface IHeater
{
    //  Нагрев
    void Heat();
}
/// <summary>
///  Реализация газового отопления
/// </summary>
class GasHeater : IHeater
{
    public void Heat()
    {
        Console.WriteLine("Нагрев газом");
    }
}
/// <summary>
/// Реализация электрического отопления
/// </summary>
class ElectricHeater : IHeater
{
    public void Heat()
    {
        Console.WriteLine("Нагрев электричеством");
    }
}
class Boiler
{
    //  Мощность
    protected int Power;

    // Модель
    protected string Model;
    public Boiler(int power, string model, IHeater heater)
    {
        Power = power;
        Model = model;
        Heater = heater;
    }

    /// <summary>
    /// Интерфейс подключения отопителя
    /// </summary>
    public IHeater Heater { private get; set; }

    /// <summary>
    /// Запуск отопителя
    /// </summary>
    public void Start()
    {
        Heater.Heat();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Подключаем котел на газу
        var boiler = new Boiler(30, "Bosch", new GasHeater());
        // Запускаем
        boiler.Start();

        // газ закончился. Переключаемся на электричество
        boiler.Heater = new ElectricHeater();
        // Запускаем
        boiler.Start();
    }
}