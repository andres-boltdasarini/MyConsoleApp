class BaseClass
{
    public virtual void Display()
    {
        Console.WriteLine("Метод класса BaseClass");
    }
}

class DerivedClass : BaseClass
{
    public override void Display()
    {
        Console.WriteLine("Метод класса DerivedClass");
    }
}
class Program
{
    static void Main()
    {
        DerivedClass bus1 = new DerivedClass { };
        bus1.Display();

    }
}