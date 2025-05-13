using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LinqTest
{
   class Program
   {
       static void Main(string[] args)
       {
string[] text = { "Раз два три",
   "четыре пять шесть",
   "семь восемь девять" };

var words = from str in text // пробегаемся по элементам массива
   from word in str.Split(' ') // дробим каждый элемент по пробелам, сохраняя в новую последовательность
   select word; // собираем все куски в результирующую выборку
 
// выводим результат
foreach (var word in words)
   Console.WriteLine(word);
       }
   }
}