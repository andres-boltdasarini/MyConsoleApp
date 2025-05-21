using System;
using System.Collections.Generic;
using System.Linq;

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

            var groupedEmployees = departments.GroupJoin(
                employees,
                d => d.Id,
                e => e.DepartmentId,
                (department, emp) => new
                {
                    DepartmentName = department.Name,
                    Employees = emp.Select(e => e.Name)
                }).ToArray();

                departments.Add(new Department {Id = 5, Name = "Дизайн"});
                //students.Add( new Student {Name="Анна", Age=21 } );

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"Отдел: {group.DepartmentName}");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine($"\t{employee}");
                }
            }
        }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
 
    public class Employee
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

//Напишите свой пример, который позволит узнать, приводит ли метод ToArray() к мгновенному выполнению LINQ-запроса?