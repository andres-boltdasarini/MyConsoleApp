public interface IHdmiInterface
{
    void Display(string text);
}

class Monitor : IHdmiInterface
{
    public void Display(string text)
    {
        Console.WriteLine("Вывод на монитор");
    }
}

class Tv : IHdmiInterface
{
    public void Display(string text)
    {
        Console.WriteLine("Вывод на телевизор");
    }
}

class VideoAdapter
{
    public string Text { get; set; }
    public IHdmiInterface HdmiInterface { get; set; }

    public VideoAdapter(IHdmiInterface hdmiInterface)
    {
        HdmiInterface = hdmiInterface;
    }

    /// <summary>
    /// Метод вывода
    /// </summary>
    public void Display()
    {
        HdmiInterface.Display(Text);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //  выводим на монитор
        var connectedMonitor = new VideoAdapter(new Monitor());
        connectedMonitor.Display();

        //  выводим на телевизор
        var connectedTv = new VideoAdapter(new Tv());
        connectedTv.Display();
    }
}