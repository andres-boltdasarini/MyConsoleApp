using System;
using System.Net;
using System.Text;

class Program
{
    private static string[] smyckaSongs = { "Intro", "Betrayed", "Mutated", "Wrecked" };
    private static readonly Random rnd = new Random();

    static void Main()
    {
        using (HttpListener listener = new HttpListener())
        {
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:8080/");

            // Обработка Ctrl+C для корректного завершения
            Console.CancelKeyPress += (s, e) =>
            {
                listener.Stop();
                Console.WriteLine("Listener stopped");
            };

            try
            {
                while (true)
                {
                    // Асинхронное получение контекста
                    HttpListenerContext context = listener.GetContext();
                    ProcessRequest(context);
                }
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine($"Listener exception: {ex.Message}");
            }
        }
    }

    private static void ProcessRequest(HttpListenerContext context)
    {
        using (HttpListenerResponse response = context.Response)
        {
            try
            {
                string responseString;
                if (context.Request.HttpMethod == "GET")
                {
                    responseString = smyckaSongs[rnd.Next(smyckaSongs.Length)];
                }
                else if (context.Request.HttpMethod == "POST")
                {
                    responseString = "Fuck";
                }
                else
                {
                    response.StatusCode = 405; // Method Not Allowed
                    responseString = "Method not allowed";
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                response.StatusCode = 500;
                byte[] errorBuffer = Encoding.UTF8.GetBytes("Internal Server Error");
                response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
            }
        }
    }
}