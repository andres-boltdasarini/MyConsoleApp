using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
               new Car("Suzuki", "JP"),
               new Car("Toyota", "JP"),
               new Car("Opel", "DE"),
               new Car("Kamaz", "RUS"),
               new Car("Lada", "RUS"),
               new Car("Honda", "JP"),
            };
            // Группировка по стране - производителю
            var carsByCountry = cars.GroupBy(car => car.CountryCode)
                                   .Select(grouping => new
                                   {
                                       Name = grouping.Key,
                                       Count = grouping.Count(),
                                       Cars = grouping.Select(p => p)
                                   });



            var carsByCountry2 = from car in cars
                                 group car by car.CountryCode into grouping // выборка в локальную переменную для вложенного запроса
                                 select new
                                 {
                                     Name = grouping.Key,
                                     Count = grouping.Count(),
                                     Cars = from p in grouping select p //  выполним подзапрос, чтобы заполнить список машин внутри нашего нового типа
                                 };

            // Выведем результат
            foreach (var group in carsByCountry)
            {
                // Название группы и количество элементов
                Console.WriteLine($"{group.Name} : {group.Count} авто");

                foreach (Car car in group.Cars)
                    Console.WriteLine(car.Manufacturer);

                Console.WriteLine();
            }

        }
    }
    class Car
    {
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }

        public Car(string manufacturer, string countryCode)
        {
            Manufacturer = manufacturer;
            CountryCode = countryCode;
        }

    }

}