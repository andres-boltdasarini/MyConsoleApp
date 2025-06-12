using System;

// ===== НАРУШЕНИЕ LSP =====
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int Area => Width * Height;
}

public class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; } // Нарушение LSP!
    }

    public override int Height
    {
        set { base.Width = base.Height = value; } // Нарушение LSP!
    }
}

// ===== СОБЛЮДЕНИЕ LSP =====
public interface IShape
{
    int GetArea();
}

public class GoodRectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetArea() => Width * Height;
}

public class GoodSquare : IShape
{
    public int Side { get; set; }
    public int GetArea() => Side * Side;
}

class Program
{
    static void Main()
    {
        // === Демонстрация нарушения LSP ===
        Console.WriteLine("Нарушение LSP:");
        Rectangle rect = new Square();
        rect.Width = 5;
        rect.Height = 4;
        Console.WriteLine($"Ожидается площадь = 20, но получается: {rect.Area}"); // 16 (!)

        // === Демонстрация соблюдения LSP ===
        Console.WriteLine("\nСоблюдение LSP:");
        IShape goodRect = new GoodRectangle { Width = 5, Height = 4 };
        IShape goodSquare = new GoodSquare { Side = 5 };
        Console.WriteLine($"Площадь прямоугольника: {goodRect.GetArea()}"); // 20
        Console.WriteLine($"Площадь квадрата: {goodSquare.GetArea()}");     // 25
    }
}