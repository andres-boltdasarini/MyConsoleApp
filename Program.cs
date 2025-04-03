namespace TryCatchPractices 
{
  class Program 
  {
    static void Main(string[] args) {

      try 
      {
        throw new ArgumentOutOfRangeException("Сообщение об ошибке");
      }

      catch(ArgumentOutOfRangeException ex) {
        Console.WriteLine(ex.Message);
      }

      finally 
      {
        Console.Read();
      }
    }
  }
}