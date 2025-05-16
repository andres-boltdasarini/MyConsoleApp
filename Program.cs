using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LinqTest
{
   class Program
   {
      
       static void Main(string[] args)
       {
var contacts = new List<Contact>()
{
   new Contact() { Name = "Андрей", Phone = 7999945005 },
   new Contact() { Name = "Сергей", Phone = 799990455 },
   new Contact() { Name = "Иван", Phone = 79999675 },
   new Contact() { Name = "Игорь", Phone = 8884994 },
   new Contact() { Name = "Анна", Phone = 665565656 },
   new Contact() { Name = "Василий", Phone = 3434 },
   new Contact() { Name = "Анна2", Phone = 26655656562 },
   new Contact() { Name = "Василий2", Phone = 234342 }
};
 
while (true)
{
    Console.WriteLine("Введите номер страницы (1-4) или 'q' для выхода:");
    var keyChar = Console.ReadKey().KeyChar;
    Console.Clear();

    if (keyChar == 'q') break;

    if (!Char.IsDigit(keyChar))
    {
        Console.WriteLine("Ошибка ввода, введите число от 1 до 4");
        continue;
    }

    IEnumerable<Contact> page = null;
    int pageSize = 2;
    
    switch (keyChar)
    {
        case '1':
            page = contacts.Take(pageSize);
            break;
        case '2':
            page = contacts.Skip(pageSize).Take(pageSize);
            break;
        case '3':
            page = contacts.Skip(pageSize * 2).Take(pageSize);
            break;
        case '4':
            page = contacts.Skip(pageSize * 3).Take(pageSize);
            break;
        default:
            Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует. Доступны страницы 1-4.");
            continue;
    }

    foreach (var contact in page)
        Console.WriteLine($"{contact.Name} {contact.Phone:### ### ####}");
}

 

        }
   }
       class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
       // public List<string> Languages { get; set; }
    }


}