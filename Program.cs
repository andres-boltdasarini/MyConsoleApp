using System;
using System.Collections.Generic;


    class Product
    {
        private string _type;

        // составные части
        private Dictionary<string, string> _parts = new Dictionary<string, string>();
        /// <summary>
        ///  Метод - конструктор
        /// </summary>
        public Product(string type)
        {
            _type = type;
        }
        // Индексатор
        public string this[string key]
        {
            set
            {
                _parts[key] = value;
            }
        }
        /// <summary>
        /// Метод для получения информации о продукте
        /// </summary>
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine($"Вид транспортного средства: {_type}");
            Console.WriteLine($" Рама : {_parts["frame"]}"); Console.WriteLine($" Двигатель : {_parts["engine"]}");
            Console.WriteLine($" Колеся: {_parts["wheels"]}");
            Console.WriteLine($" Двери : {_parts["doors"]}");
        }
    }


abstract class Conveyor
{
    protected Product _product;

    public Product Product
    {
        get { return _product; }
    }
    // Методы для постройки составных частей

    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}

class CarConveyor : Conveyor
{
    public CarConveyor()
    {
        _product = new Product("Auto");
    }
    public override void BuildFrame()
    {
        _product["frame"] = "Рама автомобиля";
    }
    public override void BuildEngine()
    {
        _product["engine"] = "150 л.с.";
    }
    public override void BuildWheels()
    {
        _product["wheels"] = "4";
    }
    public override void BuildDoors()
    {
        _product["doors"] = "4";
    }
}

class MotoConveyor : Conveyor
{
    public MotoConveyor()
    {
        _product = new Product("Moto");
    }
    public override void BuildFrame()
    {
        _product["frame"] = "Рама мотоцикла";
    }
    public override void BuildEngine()
    {
        _product["engine"] = "300 л.с.";
    }
    public override void BuildWheels()
    {
        _product["wheels"] = "2";
    }
    public override void BuildDoors()
    {
        _product["doors"] = "0";
    }
}

class CarPlant
{
    /// <summary>
    /// Запуск процесса постройки
    /// </summary>
    public void Construct(Conveyor conveyor)
    {
        conveyor.BuildFrame();
        conveyor.BuildEngine();
        conveyor.BuildWheels();
        conveyor.BuildDoors();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // создаем движок шаблонизатора
        //TemplateEngine templateEngine = new TemplateEngine();
        CarPlant сarPlant = new CarPlant();

        // создаем шаблонизатор для приветственной рассылки
        //TemplateBuilder builder = new WelcomeTemplateBuilder();
        Conveyor builder = new MotoConveyor();
        // генерируем  приветственное письо с текстом
        //Template greetingsTemplate = templateEngine.GenerateTemplate(builder);
        сarPlant.Construct(builder);
        builder.Product.Show();

        builder = new CarConveyor();
        // генерируем  приветственное письо с текстом
        //Template greetingsTemplate = templateEngine.GenerateTemplate(builder);
        сarPlant.Construct(builder);
        builder.Product.Show();
    }
}