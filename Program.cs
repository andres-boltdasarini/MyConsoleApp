using System;
 
namespace FacadeRealExample.Components
{
   class Program
   {
       static void Main(string[] args)
       {
           // при запуске IDE инициализирует объекты для работы с компонентами
           Editor textEditor = new Editor();
           Compiller compiller = new Compiller();
           Runtime runtime = new Runtime();
       
           // Наша модель IDE запущена и готова к использованию
           IdeFacade ide = new IdeFacade(textEditor, compiller, runtime);
          
           // Начинаем писать код и нажимаем кнопку Start
           ide.Start("Console.WriteLine(\"Hello World!\");"); // запускается выполнение нашей программы
           ide.Stop();
       }
   }

   class Editor
   {
       // Функция написания кода
       public void Write(string sourceCode)
       {
           Console.WriteLine($"Пишем код:  {sourceCode}");
       }
      
       // Функция сохранения кода
       public void Save()
       {
           Console.WriteLine("Сохраняем код");
       }
   }

   class Compiller
   {
       public void Compile()
       {
           Console.WriteLine("Компиляция приложения");
       }
   }

   class Runtime
   {
       public void Execute()
       {
           Console.WriteLine("Выполнение приложения");
       }
       public void Finish()
       {
           Console.WriteLine("Завершение работы приложения");
       }
   }

      class IdeFacade
   {
       readonly Editor _editor;
       readonly Compiller _compiler;
       readonly Runtime _runtime;
       public IdeFacade(Editor editor, Compiller compiler, Runtime runtime)
       {
           _editor = editor;
           _compiler = compiler;
           _runtime = runtime;
       }
      
       // Вы ввели код, IDE выполняет с ним примерно следующие действия перед запуском:
       public void Start(string sourceCode)
       {
           // Пишет в текстовый файл
           _editor.Write(sourceCode);
          
           // Сохраняет текстовый файл
           _editor.Save();
          
           // Вызывает компилятор
           _compiler.Compile();
          
           // Запускает выполнение скомпилированного приложения в среде CLR
           _runtime.Execute();
       }
      
       // в конце IDE может остановить выполнение, вызвав команду в среде выполнения
       public void Stop()
       {
           _runtime.Finish();
       }
   }
   
}