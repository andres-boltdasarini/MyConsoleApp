interface IExporter
{
   void Export(string text);
}

class PdfExporter : IExporter
{
   public void Export(string text)
   {
       Console.WriteLine($"{text}  => Экспортировано в PDF");
   }
}

class Document
{
   public string Text { get; set; }
  
   public void ScrollUp()
   {
       Console.WriteLine($"Прокрутка вверх");   }
 
   public void ScrollDown()
   {
       Console.WriteLine($"Прокрутка вниз");   }
 
   public void ZoomIn()
   {
       Console.WriteLine("Увеличиваем масштаб");
   }
 
   /// <summary>
   ///  Экспорт в любые форматы
   /// </summary>
   public void Export(IExporter exporter)
   {
       exporter.Export(Text);
   }
}

   class Program
   {
       static void Main()
       {
           IExporter exporter = new PdfExporter();
           Document doc = new Document();
           doc.Text = "Hello World";
           doc.Export(exporter);
       }
   }