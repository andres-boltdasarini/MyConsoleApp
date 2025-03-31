using System;
using System.IO;

class BinaryExperiment
{
    //const string SettingsFileName = "Settings.cfg";
    //var fileInfo = new FileInfo("/Users/user/source/repos/MyConsoleApp/Program.cs");
    const string SettingsFileName = @"/Users/user/source/repos/MyConsoleApp/BinaryFile.bin"; // Укажем путь

    static void Main()
    {
        // Пишем
        //WriteValues();
        // Считываем
        ReadValues();
    }

    static void WriteValues()
    {
        // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
        using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFileName, FileMode.Create)))
        {
            // Записываем данные в разном формате
            writer.Write(20.666F);
            writer.Write("Тестовая строка");
            writer.Write(55);
            writer.Write(false);
        }
    }

    static void ReadValues()
    {
        //float FloatValue;
        string StringValue;
        //int IntValue;
        //bool BooleanValue;

        if (File.Exists(SettingsFileName))
        {
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
            {
                // Применяем специализированные методы Read для считывания соответствующего типа данных
                //FloatValue = reader.ReadSingle();
                StringValue = reader.ReadString();
                //IntValue = reader.ReadInt32();
                //BooleanValue = reader.ReadBoolean();
            }

            Console.WriteLine("Из файла считано:");

            //Console.WriteLine("Дробь: " + FloatValue);
            Console.WriteLine("Строка: " + StringValue);
            //Console.WriteLine("Целое: " + IntValue);
            //Console.WriteLine("Булево значение: " + BooleanValue);
        }
    }
}