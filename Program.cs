class Obj
{
    public int Value;

    public static Obj operator +(Obj a, Obj b)
    {
        return new Obj
        {
            Value = a.Value + b.Value
        };
    }
    public static Obj operator -(Obj a, Obj b)
    {
        return new Obj
        {
            Value = a.Value - b.Value
        };
    }
}
class Program
{
    static void Main()
    {
        // Создаем два объекта класса Obj
        Obj obj1 = new Obj { Value = 10 };
        Obj obj2 = new Obj { Value = 5 };

        // Используем перегруженный оператор +
        Obj sum = obj1 + obj2;
        Console.WriteLine($"obj1 + obj2 = {sum.Value}"); // Выведет: 15

        // Используем перегруженный оператор -
        Obj difference = obj1 - obj2;
        Console.WriteLine($"obj1 - obj2 = {difference.Value}"); // Выведет: 5

        // Можно также делать цепочки операций
        Obj obj3 = new Obj { Value = 3 };
        Obj result = obj1 + obj2 - obj3;
        Console.WriteLine($"obj1 + obj2 - obj3 = {result.Value}"); // Выведет: 12
    }
}