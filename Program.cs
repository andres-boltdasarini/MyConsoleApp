   interface IObserver
   {
       void Update(Object o);
   }

      class StockData
   {
       public int USD { get; set; }
       public int Euro { get; set; }
   }

      interface IObservable
   {
       // добавить наблюдателя
       void RegisterObserver(IObserver o);
      
       // удалить наблюдателя
       void RemoveObserver(IObserver o);
      
       // уведомление наблюдателей
       void NotifyObservers();
   }

      class Bank : IObserver
   {
       IObservable stock;
       public Bank(IObservable obs)
       {
           stock = obs;
           stock.RegisterObserver(this);
       }
      
       public void Update(object o)
       {
           StockData sData = (StockData)o;
   
           if (sData.Euro > 85)
               Console.WriteLine($"Банк продает евро по курсу {sData.Euro}");
           else
               Console.WriteLine($"Банк покупает евро по курсу {sData.Euro}");
       }
   }

      class Broker : IObserver
   {
       IObservable stock;
 
       public Broker(IObservable obs)
       {
           stock = obs;
           stock.RegisterObserver(this);
       }
 
       public void Update(object o)
       {
           StockData sData = (StockData) o;
 
           if (sData.USD > 85)
               Console.WriteLine($"Брокер продает доллары  по курсу {sData.USD}");           else
               Console.WriteLine($"Брокер покупает доллары  по курсу {sData.USD}");       }
 
       public void StopTrade()
       {
           stock.RemoveObserver(this);
           stock = null;
       }
   }

   class Stock : IObservable
   {
       /// <summary>
       /// Информация о торгах
       /// </summary>
       StockData _sData;
       List<IObserver> observers;
       public Stock()
       {
           observers = new List<IObserver>();
           _sData = new StockData();
       }
       public void RegisterObserver(IObserver o)
       {
           observers.Add(o);
       }
       public void RemoveObserver(IObserver o)
       {
           observers.Remove(o);
       }
       public void NotifyObservers()
       {
           foreach(IObserver o in observers)
           {
               o.Update(_sData);
           }
       }
       public void Market()
       {
           Random rnd = new Random();
           _sData.USD = rnd.Next(70, 90);
           _sData.Euro = rnd.Next(80, 100);
           NotifyObservers();
       }
   }

      class Program
   {
       static void Main(string[] args)
       {
           Stock stock = new Stock();
          
           var bank = new Bank(stock);
           var broker = new Broker(stock);
          
           // имитация торгов
           stock.Market();
           // брокер прекращает наблюдать за торгами
           broker.StopTrade();
           // имитация торгов
           stock.Market();
       }
   }