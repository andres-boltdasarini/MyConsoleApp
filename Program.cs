using System.Collections;

namespace ArrayListExample
{
    class Program
    {
        static List<Contact> Book = new List<Contact>
        {
            new Contact("kile", 124, "@78"),
            new Contact("mike", 233, "@45")
        };

        static Contact cn = new Contact("james", 233, "@45");
        static Contact co = new Contact("mike", 233, "@45");
        static void Main(string[] args)
        {
            AddUnique(cn,Book);
        }

        static void AddUnique(Contact contact, List<Contact> phoneBook)
        {
            bool isDuplicate = false;

            foreach (Contact contactinbook in phoneBook)
            {
                if (contact.Name == contactinbook.Name &&
                    contact.PhoneNumber == contactinbook.PhoneNumber &&
                    contact.Email == contactinbook.Email)
                {
                    isDuplicate = true;
                    break; // выходим из цикла, если нашли дубликат
                }
            }

            if (!isDuplicate)
            {
                phoneBook.Add(contact);

                //  сортируем список по имени
                phoneBook.Sort((x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));
                // Выводим список только если добавили новый контакт
                foreach (Contact c in phoneBook)
                {
                    Console.WriteLine(c.Name + " " + c.PhoneNumber + " " + c.Email);
                }
            }
        }

    }
    public class Contact // модель класса
    {
        public Contact(string name, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}