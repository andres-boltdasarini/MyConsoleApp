using System;

class Program
{
    static void Main(string[] args)
    {
        // Создаем массив для демонстрации
        int[] numbers = { 10, 20, 30, 40, 50 };

        // Создаем экземпляр нашего класса с индексатором
        IndexingClass indexer = new IndexingClass(numbers);

        // Демонстрируем работу индексатора
        Console.WriteLine("Элемент с индексом 2: " + indexer[2]); // Выведет 30

        // Изменяем значение через индексатор
        indexer[3] = 100;
        Console.WriteLine("Измененный элемент с индексом 3: " + indexer[3]); // Выведет 100

        // Демонстрируем обработку ошибок
        try
        {
            Console.WriteLine("Попытка доступа к несуществующему индексу: " + indexer[10]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}

class IndexingClass
{
    private int[] array;

    public IndexingClass(int[] array)
    {
        this.array = array;
    }

    public int this[int index]
    {
        get
        {
            return array[index];
        }

        set
        {
            array[index] = value;
        }
    }
}