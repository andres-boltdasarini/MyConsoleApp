namespace AbstractFactoryRealExample
{
   class Program
   {
       static void Main(string[] args)
       {
           // Создание дракона через фабрику
           var dragon = new Monster(new DragonFactory());
           dragon.Move();
           dragon.Hit();
 
           Console.WriteLine();
           // Создание орка через фабрику
           var orc = new Monster(new OrcFactory());
           orc.Move();
           orc.Hit();
 
           Console.WriteLine();
           Console.WriteLine("Всем конец...");
       }
   }

   interface IMovement
   {
       void Start();
   }

      class RunMovement : IMovement
   {
       public void Start()
       {
           Console.WriteLine("Бежим");
       }
   }

      class FlyMovement : IMovement
   {
       public void Start()
       {
           Console.WriteLine("Летим");
       }
   }

      interface IWeapon
   {
       void Attack();
   }

      class Axe : IWeapon
   {
       public void Attack()
       {
           Console.WriteLine("Бьем топором");
       }
   }

      class FireBreath : IWeapon
   {
       public void Attack()
       {
           Console.WriteLine("Дышим огнем");
       }
   }

      interface IMonsterFactory
   {
        IMovement CreateMovement();
        IWeapon CreateWeapon();
   }

      class DragonFactory : IMonsterFactory
   {
       public IMovement CreateMovement()
       {
           return new FlyMovement();
       }
       public IWeapon CreateWeapon()
       {
           return new FireBreath();
       }
   }

      class OrcFactory : IMonsterFactory
   {
       public IMovement CreateMovement()
       {
           return new RunMovement();
       }
       public IWeapon CreateWeapon()
       {
           return new Axe();
       }
   }

   class Monster
   {
       private IWeapon _weapon;
       private IMovement _movement;
      
       /// <summary>
       ///  Метод - конструктор, где создаются объекты при помощи фабрики
       /// </summary>
       public Monster(IMonsterFactory factory)
       {
           _weapon = factory.CreateWeapon();
           _movement = factory.CreateMovement();
       }
       public void Move()
       {
           _movement.Start();
       }
       public void Hit()
       {
           _weapon.Attack();
       }
   }
}

