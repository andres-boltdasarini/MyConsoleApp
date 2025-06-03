using System;
 
namespace FactoryMethodRealExample
{

    class Program
   {
       static void Main(string[] args)
       {
           string messageText = "Ваш номер заказа - 83456";
 
           // Отправляем заказ по SMS
           MessageSender sender = new SmsMessageSender("+79856455320");
           Message smsMessage = sender.Send(messageText);
       
           // Отправляем заказ по e-mail
           sender = new EmailMessageSender("orders@myshop.com");
           Message message = sender.Send(messageText);
       }
   }

    abstract class Message
   {}

   class SmsMessage : Message
   {
       public SmsMessage()
       {
           Console.WriteLine("SMS отправдено");
       }
   }

      class EmailMessage : Message
   {
       public EmailMessage()
       {
           Console.WriteLine("e-mail отправлен");
       }
   }

      abstract class MessageSender
   {
       public string From { get; set; }
       public MessageSender (string @from)
       {
           From = @from;
       }
      
       // Фабричный метод
       abstract public Message Send(string text);
   }

      class EmailMessageSender : MessageSender
   {
       public EmailMessageSender(string @from) : base(@from)
       { }
       public override Message Send(string text)
       {
           return new EmailMessage();
       }
   }

      class SmsMessageSender : MessageSender
   {
       public SmsMessageSender(string @from) : base(@from)
       { }
       public override Message Send(string text)
       {
           return new SmsMessage();
       }
   }


}