namespace DelegatePractices
{
    class Program
    {
//delegate void ShowMessageDelegate();
//delegate int SumDelegate(int a, int b, int c);
//delegate bool CheckLengthDelegate(string _row);
        static void Main(string[] args)
        {
Action showMessageDelegate = ShowMessage;
showMessageDelegate.Invoke();

Func < int,int,int,int > sumDelegate = Sum;
int result = sumDelegate.Invoke(1, 30, 120);
Console.WriteLine(result);

Predicate < string > checkLengthDelegate = CheckLength;
bool status = checkLengthDelegate.Invoke("skill_factory");
Console.WriteLine(status);


        }

static void ShowMessage() 
{
  Console.WriteLine("Hello World!");
}

static int Sum(int a, int b, int c) 
{
  return a + b + c;
}

static bool CheckLength(string _row) 
{
  if (_row.Length > 3) return true;
  return false;
}
    }
}