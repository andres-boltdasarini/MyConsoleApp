   interface IElevatorState
   {
       void Up(Elevator elevator);
       void Down(Elevator elevator);
   }

   class LowerElevatorState : IElevatorState
{
   public void Up(Elevator elevator)
   {
       Console.WriteLine("Поднимаемся на первый этаж");
       elevator.ElevatorState = new GroundElevatorState();
   }
 
   public void Down(Elevator elevator)
   {
       Console.WriteLine("Опускаемся ещё ниже");
   }
}

class GroundElevatorState : IElevatorState
{
   public void Up(Elevator elevator)
   {
       Console.WriteLine("Поднимаемся на верхний этаж");
       elevator.ElevatorState = new UpperElevatorState();
   }
 
   public void Down(Elevator elevator)
   {
       Console.WriteLine("Опускаемся на подвальный этаж");
       elevator.ElevatorState = new LowerElevatorState();
   }
}

class UpperElevatorState : IElevatorState
{
   public void Up(Elevator elevator)
   {
       Console.WriteLine("Перемещаемся ещё выше");
   }
 
   public void Down(Elevator elevator)
   {
       Console.WriteLine("Опускаемся на первый этаж");
       elevator.ElevatorState = new GroundElevatorState();
   }
}

class Elevator {
  /// Хранилище состояния
  public IElevatorState ElevatorState {
    get;
    set;
  }
  public Elevator(IElevatorState elevatorState) {
    ElevatorState = elevatorState;
  }
  // Подъем
  public void Up() {
    ElevatorState.Up(this);
  }

  // Спуск
  public void Down() {
    ElevatorState.Down(this);
  }
}


   class Program
   {
       static void Main(string[] args)
       {
           // инициализируем лифт (находится на земле)
           Elevator elevator = new Elevator(new GroundElevatorState());
          
           elevator.Up(); // подъем наверх
           elevator.Down(); // спуск на землю
           elevator.Down(); // спуск в подвал
       }
   }
