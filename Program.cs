interface ILocation
{
    /// Метод для клонирования
    ILocation Clone();

    // Метод для получения информации об объекте
    void GetInfo();
}
class Point : ILocation
{
    double Latitude;
    double Longitude;

    public Point(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
    // Метод для клонирования
    public ILocation Clone()
    {
        return new Point(Latitude, Longitude);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Новая точка на карте с координатами {Longitude}, {Latitude}");
    }
}

class Place : ILocation
{
    string Address;

    public Place(string address)
    {
        Address = address;
    }
    // Метод для клонирования
    public ILocation Clone()
    {
        return new Place(Address);
    }

    public void GetInfo()
    {
        Console.WriteLine($"Новый объект по адресу {Address}. ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // создаем точку
        ILocation location = new Point(30.245, 40.954);
        // клонируем точку (получаем новую точку с теми же координатами)
        ILocation clonedLocation = location.Clone();

        location.GetInfo();
        clonedLocation.GetInfo();

        Console.WriteLine();

        // создаем место
        location = new Place("Улица Пушкина, дом Колотушкина");
        // клонируем место (получаем новое место по тому же адресу)
        // пример использования - нам надо обозначить новый магазин в том же самом торговом центре
        clonedLocation = location.Clone();

        location.GetInfo();
        clonedLocation.GetInfo();
    }
}