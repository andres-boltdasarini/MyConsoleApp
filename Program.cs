using System;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate an electric car and gas car
        ElectricCar electricCar = new ElectricCar();
        GasCar gasCar = new GasCar();

        // Create car parts
        Battery battery = new Battery();
        Differential differential = new Differential();
        Wheel wheel = new Wheel();

        // Change parts for electric car
        electricCar.ChangePart(battery);
        electricCar.ChangePart(differential);
        electricCar.ChangePart(wheel);

        // Change parts for gas car
        gasCar.ChangePart(battery);  // Assuming GasCar can also use a Battery
        gasCar.ChangePart(differential);
        gasCar.ChangePart(wheel);

        Console.WriteLine("Parts changed successfully.");
    }
}
abstract class Engine { }

class ElectricEngine : Engine { }

class GasEngine : Engine { }

abstract class CarPart { }

class Battery : CarPart { }

class Differential : CarPart { }

class Wheel : CarPart { }

abstract class Car<TEngine> where TEngine : Engine
{
	public TEngine Engine;

	public abstract void ChangePart<TPart>(TPart newPart) where TPart : CarPart;
}

class ElectricCar : Car<ElectricEngine>
{
	public override void ChangePart<TPart>(TPart newPart)
	{

	}
}

class GasCar : Car<GasEngine>
{
	public override void ChangePart<TPart>(TPart newPart)
	{

	}
}
