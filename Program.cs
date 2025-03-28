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
        public Tid? Id { get; private set; }
        public void SetId(Tid id) => Id = id;
    }

    public Adress address = new();
    public Phone phones = new Phone { PhoneNumber = 456 };
}

class HomeDelivery : Delivery
{
    public void SetCourierName(string courierName) { CourierName.SetId(courierName); }
    public Naming<String> CourierName = new Naming<String>();
    public HomeDelivery(string courierName) { CourierName.SetId(courierName); }

}

class PickPointDelivery : Delivery
{
    public void SetPointNumber(int pickPointNumber) { PickPointNumber.SetId(pickPointNumber); }
    public Naming<int> PickPointNumber = new Naming<int>();
    public PickPointDelivery(int pickPointNumber) { PickPointNumber.SetId(pickPointNumber); }
}

class ShopDelivery : Delivery
{
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
        prod.SetData("netbook", 345, obj);
        return prod;
    }
}
class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery? Delivery { get; set; }
    public TStruct? Struct { get; set; }
    public int number;
    public string? description;
    public Product[]? products;
    private int cost;
    public int Cost => cost;
    public Product this[int index]
    {
        get
        {
            if (index >= 0 && index < products.Length)
            {
                return products[index];
            }
            else
            {
                return null;
            }

        }
        set
        {
            if (index >= 0 && index < products.Length)
            {
                products[index] = value;
            }
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
}

abstract class Product
{
    protected string? name;
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
    public override void SetData(string name, int cost, object data)
    {
        base.SetData(name, cost, data);
        if (data != null && data is string) processorName = (string)data;
        else processorName = "empty";
    }
}

class Motherboard
{
    private Computer computer;

    public Motherboard()
    {
        computer = new Computer();
    }
}
class Memory
{
    private Computer computer;
    public Memory(Computer computer) => this.computer = computer;
}
class Adress
{
    public string? AdressName { get; private set; }
}

class Phone
{
    public int PhoneNumber;
}
class Box
{
    public int Weight { get; }

    public Box(int weight)
    {
        Weight = weight;
    }

    public static Box operator +(Box a, Box b)
    {
        return new Box(a.Weight + b.Weight);
    }
}