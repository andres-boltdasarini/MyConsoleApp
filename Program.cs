[Serializable]
public class Contact
{
    public string Name { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, long phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    // Метод для сериализации объекта в бинарный формат
    public void Serialize(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(PhoneNumber);
        writer.Write(Email);
    }

    // Метод для десериализации объекта из бинарного формата
    public static Contact Deserialize(BinaryReader reader)
    {
        string name = reader.ReadString();
        long phoneNumber = reader.ReadInt64();
        string email = reader.ReadString();

        return new Contact(name, phoneNumber, email);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Contact contact = new Contact("John Doe", 1234567890, "john.doe@example.com");

        // Сериализация объекта в бинарный файл
        using (FileStream fs = new FileStream("contact.bin", FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            contact.Serialize(writer);
        }

        // Десериализация объекта из бинарного файла
        Contact deserializedContact;
        using (FileStream fs = new FileStream("contact.bin", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            deserializedContact = Contact.Deserialize(reader);
        }

        // Вывод десериализованных данных
        Console.WriteLine($"Name: {deserializedContact.Name}, Phone: {deserializedContact.PhoneNumber}, Email: {deserializedContact.Email}");
    }
}