using System.Collections;

namespace ArrayListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new ArrayList()
           {
               1,
               "Андрей ",
               "Сергей ",
               300,
           };
            var x = Testo(arrayList);
            Console.WriteLine(x[0]);
            Console.WriteLine(x[1]);
        }

        static ArrayList Testo(ArrayList input)
        {
            int suminpint = 0;
            string textinp = "";
            var result = new ArrayList();

            foreach (var item in input)
            {
                if (item is int)
                {
                    suminpint += (int)item;
                }
                else if (item is string)
                {
                    textinp += item.ToString();
                }
            }
            result.Add(suminpint);
            result.Add(textinp);
            return result;


        }

    }
}