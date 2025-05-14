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
var numsList = new List<int[]>()
{
   new[] {2, 3, 7, 1},
   new[] {45, 17, 88, 0},
   new[] {23, 32, 44, -6},
};
          
// Составим запрос ()
var mobileCompanies = numsList
//.Where(companie => companie.value == "Mobile");

               .SelectMany(c => c)
                  .OrderBy(c => c);
 
           foreach (var company in mobileCompanies)
               Console.WriteLine(company);

//foreach (var city in prodMob)
  // Console.WriteLine(city);
       
        }
   }

}