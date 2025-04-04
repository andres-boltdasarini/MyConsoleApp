public delegate void Notify();  // делегат
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // событие

    public void StartProcess()
    {
        Console.WriteLine("Процесс начат!");
        OnProcessCompleted();
    }

    protected virtual void OnProcessCompleted() //protected virtual method
    {
        ProcessCompleted?.Invoke();
    }
}
class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // регистрируем событие
        bl.StartProcess();
    }

    // перехватчик событий
    public static void bl_ProcessCompleted()
    {
        Console.WriteLine("Процесс завершён!");
    }
}