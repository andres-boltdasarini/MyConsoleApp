using System;

// Базовый интерфейс
public interface ICar
{
    void Drive();
}

// Опциональные интерфейсы
public interface IOffRoadPack
{
    void DriveDown();
    void LockDifferential();
    void DescentAssist();
}

public interface IPremiumPack
{
    void CruiseControl();
}

public interface ISportPack
{
    void FourWheelDrive();
}

// Классы машин
public class Sedane : ICar, IPremiumPack
{
    public void Drive() => Console.WriteLine("Седан едет");
    public void CruiseControl() => Console.WriteLine("Круиз-контроль включён");
}

public class Suv : ICar, IOffRoadPack, ISportPack, IPremiumPack
{
    public void Drive() => Console.WriteLine("Внедорожник едет");
    public void CruiseControl() => Console.WriteLine("Круиз-контроль включён");
    public void FourWheelDrive() => Console.WriteLine("Полный привод активирован");
    public void DriveDown() => Console.WriteLine("Спуск с горы");
    public void LockDifferential() => Console.WriteLine("Дифференциал заблокирован");
    public void DescentAssist() => Console.WriteLine("Помощь при спуске");
}

public class Driver
{
    public void Drive(ICar car) => car.Drive();
}

class Program
{
    static void Main()
    {
        var driver = new Driver();

        Console.WriteLine("Седан:");
        driver.Drive(new Sedane());

        Console.WriteLine("\nВнедорожник:");
        driver.Drive(new Suv());
    }
}