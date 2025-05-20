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
            // Список моделей
var departments = new List<Department>()
{
   new Department() {Id = 1, Name = "Программирование"},
   new Department() {Id = 2, Name = "Продажи"},
   new Department() {Id = 3, Name = "Бухгалтерия"}
};
 
// Список автопроизводителей
var employees = new List<Employee>()
{
   new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
   new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
   new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
   new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
};

var result = from employee in employees // выберем машины
               join d in departments on employee.DepartmentId equals d.Id // соединим по общему ключу (имя производителя) с производителями
               select new //   спроецируем выборку в новую анонимную сущность
               {
                   Contact = employee.Name,
                   Department = d.Name,
               };

var result2 = employees.Join(departments, // передаем в качестве параметра вторую коллекцию
   employee => employee.DepartmentId, // указываем общее свойство для первой коллекции
   d => d.Id, // указываем общее свойство для второй коллекции
   (employee, d) =>
       new // проекция в новый тип
       {
                   Contact = employee.Name,
                   Department = d.Name,
       });
 
// выведем результаты
foreach (var item in result2)
   Console.WriteLine($"{item.Contact} - {item.Department}");

        }
    }
// Модель автомобиля
public class Department
{
   public int Id { get; set; }
   public string Name { get; set; }
}
 
// Завод - изготовитель
public class Employee
{
   public int DepartmentId { get; set; }
   public string Name { get; set; }
   public int Id { get; set; }
}

}