﻿using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LinqTest
{
   class Program
   {
      
       static void Main(string[] args)
       {
// Подготовим данные
string [] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха"};
          
var wordsInfo =  words.Select(w =>
   new
   {  // Выборка в анонимный тип
       Name = w,
       Length = w.Length // Длину слова сохраняем сразу в свойство нового анонимного типа
   })
   .OrderBy( word => word.Length); //  сортируем коллекцию по длине
 
 
// выводим
foreach (var word in wordsInfo)
   Console.WriteLine($"{word.Name} - {word.Length} букв");

//foreach (var city in prodMob)
  // Console.WriteLine(city);
       
        }
   }

}