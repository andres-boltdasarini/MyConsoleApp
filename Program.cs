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
        base.Display();
        Console.WriteLine("Метод класса DerivedClass");
    }
}
class Program
{
    static void Main()
    {
        DerivedClass obj = new DerivedClass();
        obj.Display();

    }
}