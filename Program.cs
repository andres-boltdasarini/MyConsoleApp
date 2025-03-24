class A
{
    public virtual void Display()
    {
        Console.WriteLine("Метод класса A");
    }
}

class B : A
{
    public new void Display()
    {
        Console.WriteLine("Метод класса B");
    }
}

class C : A
{
    public override void Display()
    {
        Console.WriteLine("Метод класса C");
    }
}

class D : B
{
    public new void Display()
    {
        Console.WriteLine("Метод класса D");
    }
}

class E : C
{
    public new void Display()
    {
        Console.WriteLine("Метод класса E");
    }
}
class Program
{
    static void Main()
    {
        D d = new D();
        E e = new E();

        d.Display();
        ((A)e).Display();
        ((B)d).Display();
        ((A)d).Display();

    }
}