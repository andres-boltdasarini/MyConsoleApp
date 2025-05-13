using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Practice
{
   class Program
   {
       static void Main(string[] args)
       {
           var people = new List<object>()
           {
               1,
               "Сергей ",
               "Андрей ",
               300,
           };
 
          //  var names = from a in objects
          //      where a is string // проверка на совместимость с типом
          //      orderby a // сортировка по имени
          //      select a; // выборка
 
          //  foreach (var name in names)   Console.WriteLine(name);

        var selectedPeople = people.Where( o => o is string).OrderBy(o => o);

           foreach (string s in selectedPeople) Console.WriteLine(s);
       }
   }
}