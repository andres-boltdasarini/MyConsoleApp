using System;

class Program
{
    static void Main(string[] args)
    {
        // Создаем объект HomeDelivery
        HomeDelivery homeDelivery = new HomeDelivery
        {
            Address = "123 Main St",
            Telephone = "555-1234"
        };

        // Создаем объект Order
        Order<HomeDelivery, string> order = new Order<HomeDelivery, string>
        {
            Delivery = homeDelivery,
            Number = 1,
            Description = "Order for home delivery"
        };

        // Отображаем адрес доставки
        order.DisplayAddress();
    }
}

abstract class Delivery
{
    public string Address { get; set; }
    public string Telephone { get; set; }
}

class HomeDelivery : Delivery
{
    // Дополнительная логика для домашней доставки (если нужна)
}

class PickPointDelivery : Delivery
{
    // Дополнительная логика для доставки через пункты выдачи (если нужна)
}

class ShopDelivery : Delivery
{
    // Дополнительная логика для доставки в магазин (если нужна)
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    class Product
    {
        // Логика продукта (если нужна)
    }

    public TDelivery Delivery { get; set; }

    public int Number { get; set; }

    public string Description { get; set; }

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }
}

  // ... Другие поля

//построить систему классов
//идти «внутрь» заказа и создавать связанные с ним сущности
//Заказ может содержать класс Product для описания товара
//создать какие-то общие используемые классы, которые облегчат работу, например, для адреса или мобильного телефона компании и прочего
//