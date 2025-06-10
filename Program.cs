   class BoardComputer
{
   public void PerformLanding(ILandingProfile profile)
   { 
      profile.Execute();
   }
           
}
   
   public interface ILandingProfile
   {
       void Execute();
   }

      public class GroundLandingProfile : ILandingProfile
   {
       public void Execute()
       {
           Console.WriteLine(">> Загружен профиль: ПОСАДКА НА ЗЕМЛЮ <<");
          
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("Опускаем руль высоты");
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("Выпускаем шасси");
           Console.WriteLine("Поднимаем руль высоты");
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("--ПОСАДКА--");
           Console.WriteLine("Выпускаем тормозной парашют");
       }
   }

      public class WaterLandingProfile : ILandingProfile
   {
       public void Execute()
       {
           Console.WriteLine(">> Загружен профиль: ПОСАДКА НА ВОДУ <<");
          
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("Опускаем руль высоты");
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("Поднимаем руль высоты");
           Console.WriteLine("Сбрасываем скорость");
           Console.WriteLine("--ПОСАДКА--");
       }
   }

      class Program
   {
       static void Main(string[] args)
       {
           var boardComputer = new BoardComputer();
          
           // посадка на землю
           boardComputer.PerformLanding(new GroundLandingProfile());
 
           Console.WriteLine();
          
           // посадка на воду
           boardComputer.PerformLanding(new WaterLandingProfile());
       }
   }