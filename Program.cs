namespace CompositeExample.Components
{

   abstract class Component
   {
       public readonly string Name;
 
       protected Component(string name)
       {
           this.Name = name;
       }
      
       #region Методы для добавления / удаления подкомпонентов
      
       public abstract void Display();
       public abstract void Add(Component c);
       public abstract void Remove(Component c);
      
       #endregion
   }

      class File : Component
   {
       public File(string name)
           : base(name)
       {}
       public override void Display()
       {
           Console.WriteLine(Name);
       }
       // Метод для добавления подкомпонентов не поддерживается
       public override void Add(Component component)
       {
           throw new NotImplementedException();
       }
       // Метод для удаления подкомпонентов не поддерживается
       public override void Remove(Component component)
       {
           throw new NotImplementedException();
       }
   }

      class Folder : Component
   {
       List<Component> subFolders = new List<Component>();
       public Folder(string name)
           : base(name)
       {}
       // Метод для добавления новых подкомпонентов
       public override void Add(Component component)
       {
           subFolders.Add(component);
           Console.WriteLine($"В {this.Name} добавлено: {component.Name} ");
       }
       // Метод для удаления
       public override void Remove(Component component)
       {
           subFolders.Remove(component);
           Console.WriteLine($"Из {this.Name} удалено: {component.Name} ");
       }
       // Метод для отображения нижестоящих компонентов
       public override void Display()
       {
           Console.WriteLine();
           Console.WriteLine($"{Name} содержит:");
           foreach (Component component in subFolders)
               component.Display();
       }
   }

   class Client
   {
       public  static void Main()
       {
           // Создание корневой папки
           Component rootFolder = new Folder("Root");
          
           // Создание файла - компонента низшего уровня
           Component myFile = new File("MyFile.txt");
          
           // Создание папки с документами
           Folder documentsFolder = new Folder("MyDocuments");
          
           // Добавляем файл в корневую папки
           rootFolder.Add(myFile);
          
           // Добавляем подпапку для документов в корневую папку
           rootFolder.Add(documentsFolder);
          
           // показываем контент корневой папки
           rootFolder.Display();
       }
   }


}