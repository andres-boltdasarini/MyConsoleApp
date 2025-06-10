abstract class NotificationHandler {
  public NotificationHandler Successor { get; set; }
  public abstract void Handle(Receiver receiver);
}

class EmailNotificationHandler: NotificationHandler {
  public override void Handle(Receiver receiver) {
    if (receiver.EmailNotification == true)
      Console.WriteLine("Выполнено уведомление по e-mail");
    else if (Successor != null)
      Successor.Handle(receiver);
  }
}

class SmsNotificationHandler: NotificationHandler {
  public override void Handle(Receiver receiver) {
    if (receiver.SmsNotification == true)
      Console.WriteLine("Выполнено уведомление по SMS");
    else if (Successor != null)
      Successor.Handle(receiver);
  }
}

class VoiceNotificationHandler: NotificationHandler {
  public override void Handle(Receiver receiver) {
    if (receiver.VoiceNotification == true)
      Console.WriteLine("Выполнено уведомление по телефону");
    else if (Successor != null)
      Successor.Handle(receiver);
  }
}

   class Receiver
   {
       // банковские переводы
       public bool EmailNotification { get; set; }
       // денежные переводы - WesternUnion, Unistream
       public bool SmsNotification { get; set; }
       // перевод через PayPal
       public bool VoiceNotification { get; set; }
       public Receiver(bool emailNotification, bool smsNotification, bool voiceNotification)
       {
           EmailNotification = emailNotification;
           SmsNotification = smsNotification;
           VoiceNotification = voiceNotification;
       }
   }

      class Program
   {
       static void Main(string[] args)
       {
           Receiver receiver = new Receiver(false, true, true);
           
           NotificationHandler emailNotificationHandler = new EmailNotificationHandler();
           NotificationHandler voiceNotificationHandler = new VoiceNotificationHandler();
           NotificationHandler smsNotificationHandler = new SmsNotificationHandler();
          
           emailNotificationHandler.Successor = smsNotificationHandler;
           smsNotificationHandler.Successor = voiceNotificationHandler;
   
           emailNotificationHandler.Handle(receiver);
       }
   }