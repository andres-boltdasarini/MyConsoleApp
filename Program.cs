using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static string[] smyckaSongs = new string[4] { "Intro", "Betrayed", "Mutated", "Wrecked" };
    static void Main()
    {
        string[] str = new string[1] { "" };

        while (true)
        {
            SimpleListenerExample(str);
        }
    }
    public static Stream? output;
    public static void SimpleListenerExample(string[] prefixes)
    {
        Random rnd = new Random();
        
        if (!HttpListener.IsSupported)
        {
            Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
            return;
        }
        // URI prefixes are required,
        // for example "http://contoso.com:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
            throw new ArgumentException("prefixes");

        // Create a listener.
        HttpListener listener = new HttpListener();
        // Add the prefixes.
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        string resp = smyckaSongs[ rnd.Next(4)];
        Console.WriteLine("Listening...");
        // Note: The GetContext method blocks while waiting for a request.
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        Console.WriteLine(request.HttpMethod);
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response.
        string responseString;
        if (request.HttpMethod == "GET")
            responseString = resp;
        else if (request.HttpMethod == "POST")
            responseString = "Fuck";
        else responseString = "No";

        byte[] buffer = Encoding.UTF8.GetBytes(responseString);

        // Get a response stream and write the response to it.

        response.ContentLength64 = buffer.Length;

        output = response.OutputStream;

        output?.Write(buffer, 0, buffer.Length);

        // You must close the output stream.
        output?.Close();
        listener.Stop();
    }
}
