using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LinqTest
{
   class Program
   {
      
       static void Main(string[] args)
       {
// Подготовим данные
// Список студентов
var  students = new List<Student>
{
   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
};
 
// Список курсов
var coarses = new List<Coarse>
{
   new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
   new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
};
          
// добавим студентов в курсы
var studentsWithCoarses = from stud in students
where stud.Age< 29 && stud.Languages.Contains("английский")
   from coarse in coarses
   where coarse.Name.Contains("C#")
   select new { Name = stud.Name, CoarseName = coarse.Name };
 
// выведем результат
foreach (var stud in studentsWithCoarses)
   Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");

        }
   }
       class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
    }
        class Coarse
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }

}