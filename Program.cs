using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LinqTest
{
   class Program
   {
      
       static void Main(string[] args)
       {
           // Добавим Россию с её городами
           var russianCities = new List<City>();
           russianCities.Add(new City("Москва", 11900000));
           russianCities.Add(new City("Санкт-Петербург", 4991000));
           russianCities.Add(new City("Волгоград", 1099000));
           russianCities.Add(new City("Казань", 1169000));
           russianCities.Add(new City("Севастополь", 449138));

  //          var bigCities = from russianCity in russianCities
  //  where russianCity.Population > 1000000
  //  orderby russianCity.Population descending
  //  select russianCity;
  //А теперь попробуйте выбрать все города, название у которых не длиннее 10 букв, и отсортируйте их по длине названия.

  var bigCities = russianCities.Where(c => c.Name.Length < 11)
  .OrderByDescending(c => c.Name.Length);
 
foreach (var bigCity in bigCities)
   Console.WriteLine(bigCity.Name + " - " + bigCity.Population);
       }
 
       // Создадим модель класс для города
       public class City
       {
           public City(string name, long population)
           {
               Name = name;
               Population = population;
           }
          
           public string Name { get; set; }
           public long Population { get; set; }
       }
   }
}