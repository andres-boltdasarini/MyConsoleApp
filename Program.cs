using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product[] products = new Product[]
        {
            new Computer(),
            new Computer()
        };
        products[0].SetData("Laptop", 1000, "Intel i5");
        products[1].SetData("Desktop", 1500, "Intel i7");

        // Create a delivery
        HomeDelivery delivery = new HomeDelivery("John Doe");
        delivery.SetCourierName("Express Courier");

        // Create an order
        Order<HomeDelivery, string> order = new Order<HomeDelivery, string>
        {
            Delivery = delivery,
            Struct = "Order Struct",
            Number = 1,
            Description = "Sample Order",
            Products = products
        };

        Console.WriteLine($"Order Total Cost: {order.CalculateCost()}");
        order.DisplayAddress();
    }
}

static class OrderCalculator
{
    public static int CostCalculate(Product[] products)
    {
        int total = 0;
        for (int i = 0; i < products.Length; i++)
        {
            total += products[i].Cost;
        }
        return total;
    }
}

abstract class Delivery
{
    public Address Address = new Address();
    public Phone Phones = new Phone();
}

class HomeDelivery : Delivery
{
    public string CourierName { get; private set; }

    public void SetCourierName(string courierName) { CourierName = courierName; }
    public HomeDelivery(string name) { CourierName = name; }
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery { get; set; }
    public TStruct Struct { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public Product[] Products { get; set; }

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address?.AddressName ?? "Address not set.");
    }

    public int CalculateCost()
    {
        return OrderCalculator.CostCalculate(Products);
    }
}

abstract class Product
{
    protected string Name;
    public int Cost { get; private set; }

    public virtual void SetData(string name, int cost, object data)
    {
        Name = name;
        Cost = cost;
    }
}

class Computer : Product
{
    string ProcessorName;

    public override void SetData(string name, int cost, object data)
    {
        base.SetData(name, cost, data);

        if (data is string processorData)
        {
            ProcessorName = processorData;
        }
    }
}

class Address
{
    public string AddressName { get; set; } = "Default Address";
}

class Phone
{
    public int PhoneNumber { get; set; }
}