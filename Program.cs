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
var companies = new Dictionary<string, string[]>( );
 
companies.Add("Apple", new []{ "Mobile",  "Desktop"  });
companies.Add("Samsung", new []{ "Mobile"} );
companies.Add("IBM", new []{ "Desktop" } ); 
          
// Составим запрос ()
var mobileCompanies = companies
//.Where(companie => companie.value == "Mobile");

               .Where(c => c.Value.Contains("Mobile"));
 
           foreach (var company in mobileCompanies)
               Console.WriteLine(company.Key);

//foreach (var city in prodMob)
  // Console.WriteLine(city);
       
        }
   }

}