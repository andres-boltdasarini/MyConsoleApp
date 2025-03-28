

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
        order.CalculateCost();
        HomeDelivery homeDelivery = new HomeDelivery("kile");
        homeDelivery.SetCourierName("kile");
        Console.WriteLine(homeDelivery.CourierName.Id);
        Console.WriteLine(order.number);
        // Использование индексатора для доступа к продуктам
        Console.WriteLine("Первый продукт в заказе: " + order[0].Cost); // Доступ через индексатор
        Console.WriteLine("Второй продукт в заказе: " + order[1].Cost); // Доступ через индексатор
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
    public class Naming<Tid>
    {
        //обобщенные свойства;
        public Tid? Id { get; private set; }
        public void SetId(Tid id) => Id = id;
    }

    public Adress address = new();
    public Phone phones = new Phone { PhoneNumber = 456 };
}

class HomeDelivery : Delivery
{
    //public string CourierName { get; private set; }

    public void SetCourierName(string courierName) { CourierName.SetId(courierName); }
    public Naming<String> CourierName = new Naming<String>();
    //конструктор класса с параметрами;
    public HomeDelivery(string courierName) { CourierName.SetId(courierName); }

}

class PickPointDelivery : Delivery
{
    //public int PickPointNumber { get; private set; }
    public void SetPointNumber(int pickPointNumber) { PickPointNumber.SetId(pickPointNumber); }
    public Naming<int> PickPointNumber = new Naming<int>();
    public PickPointDelivery(int pickPointNumber) { PickPointNumber.SetId(pickPointNumber); }


    //construct vs init
}

class ShopDelivery : Delivery
{
    //public string? ShopName { get; private set; }
    //generic propr
    public void SetShopName(string shopName) { ShopName.SetId(shopName); }
    public Naming<String> ShopName = new Naming<String>();
    public ShopDelivery(string shopName) { ShopName.SetId(shopName); }

}
static class ExtentonOrder
{
    public static int SetNumber(this int num)
    {
        num = 2;
        return num;
    }
    public static Product SetProd(this Product prod)
    {
        int obj = 1;
        prod.SetData("test", 345, obj);
        return prod;
    }
}
class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    //обобщение 2 типов
    public TDelivery Delivery { get; set; }
    public TStruct Struct { get; set; }
    public int number;
    public string description;
    public Product[] products;
    private int cost;
    public int Cost => cost;
    //индексатор
    public Product this[int index]
    {
        get
        {
            if (index < 0 || index >= products.Length)
                throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива продуктов");
            return products[index];
        }
        set
        {
            if (index < 0 || index >= products.Length)
                throw new IndexOutOfRangeException($"Индекс {index} выходит за границы массива продуктов");
            products[index] = value;
        }
    }

    public void DisplayAdress()
    {
        if (Delivery.address != null)
            Console.WriteLine(Delivery.address.AdressName);
        else
            Console.WriteLine("Address not set.");
    }
    public int CalculateCost()
    {
        cost = OrderCalculator.CostCalculate(products);
        number.SetNumber();
        products[0].SetProd();
        return cost;
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

class Computer : Product
{
    public string? processorName { get; private set; }
    //переопределений методов;
    public override void SetData(string name, int cost, object data)
    {
        base.SetData(name, cost, data);
        //подробнее про base
        if (data != null && data is string) processorName = (string)data;
        else processorName = "empty";
        //корректно присвоить значение data
    }
}

class Motherboard
{
    private Computer computer;
   
    public Motherboard()  //композиция
    {
        computer = new Computer();
    }
}
class Memory
{
    private Computer computer;
    public Memory(Computer computer) => this.computer = computer;  //агрегация
    //лямбда для однострочной записи
}
class Adress
{
    public string AdressName { get; private set; }
}

class Phone
{
    public int PhoneNumber; //{ get; private set; }
}