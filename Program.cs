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
            number = 1,
            description = "Sample Order",
            products = products
        };

        Console.WriteLine($"Order Total Cost: {order.Cost}");
        order.DisplayAdress();
    }
}

static class OrderCalculator
{
    public static int CostCalculate(Product[] products)
    {
        int total = 0;
        for (int i = 0; i<products.Length; i++)
        {
            total += products[i].Cost;
        }
        return total;
    }
}

abstract class Delivery
{
    public Adress address = new();
    public Phone phones = new Phone();
}

class HomeDelivery : Delivery
{
    public string CourierName { get; private set; }

    public void SetCourierName(string courierName) { CourierName = courierName; }
    public HomeDelivery(string courierName) { CourierName = courierName; }
}

class PickPointDelivery : Delivery
{
    public int PickPointNumber { get; private set; }
    public void SetPointNumber(int pickPointNumber) { PickPointNumber = pickPointNumber; }
    //construct vs init
}

class ShopDelivery : Delivery
{
    public string? ShopName { get; private set; }
    //generic propr
    public void SetShopName(string shopName) { ShopName = shopName; }
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    //обобщение 2 типов?
    public TDelivery Delivery { get; set; }
    public TStruct Struct { get; set; }
    public int number;
    public string description;
    public Product[] products;

    public void DisplayAdress()
    {
        if (Delivery.address != null)
            Console.WriteLine(Delivery.address.AdressName);
        else
            Console.WriteLine("Address not set.");
    }
    public int CalculateCost(){
        return OrderCalculator.CostCalculate(products);
    } 
    //как использовать статик метод?
}

abstract class Product
{
    protected string name;
    public int Cost { get; private set; }

    public virtual void SetData(string name, int cost, object data)
    {
        this.name = name;
        Cost = cost;
    }
}

class Computer: Product {
    string processorName;
    public override void SetData(string name, int cost, object data)
    {
        base.SetData(name, cost, data);
        //подробнее про base
        if (data != null && data is string) processorName = (string)data;
        //корректно присвоить значение data
    }
}

class Motherboard {
    private Computer computer;

    public Motherboard(){
        computer = new Computer();
    }
}
class Memory
{
    private Computer computer;
    public Memory (Computer computer) => this.computer = computer;
    //лямбда для обнострочной записи
}
class Adress
{
    public string AdressName { get; private set; }
}

class Phone
{
    public int PhoneNumber { get; private set; }
}