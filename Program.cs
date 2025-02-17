using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();
        
        foreach(Language lang in languages){
          Console.WriteLine(lang.Prettify());
        }
        List<string> eachLang = (from l in languages
                                  where l != null
                                  select $"{l.Year}--{l.Name}--{l.ChiefDeveloper}").ToList();
                                  

                foreach(string lang in eachLang){
                    Console.WriteLine(lang);
                }
       IEnumerable<Language> whenC = from l in languages
                                where l.Name == "C#"
                                select l;  

                     foreach(Language lang in whenC){
                        Console.WriteLine(lang.Prettify());
                     }              
          IEnumerable<Language> micro = from l in languages
                                where l.ChiefDeveloper.Contains("Microsoft")    
                                select l;
                          Console.WriteLine("---List of Microsoft Languages---");
                         foreach(Language lang in micro){
                          Console.WriteLine(lang.Name);
                         }       

                        Console.WriteLine("---Languages Descend from Lisp---");
          IEnumerable<Language> lisp = from l in languages
                                where l.Predecessors.Contains("Lisp")    
                                select l;                             
    
                            foreach(Language lang in lisp){
                              Console.WriteLine(lang.Name);
                            }

          List<string> script = (from l in languages
                                        where l.Name.ToLower().Contains("script")
                                        select l.Name).ToList();

                          Console.WriteLine("---Language with script---");
                         foreach(string lang in script){

                            Console.WriteLine(lang);
                         }                    

           List<string> amount = (from l in languages
                                  where l.Name != null
                                  select l.Name).ToList();

                        int i = 1;
                        Console.WriteLine("---All Languages---");
                         foreach(string lang in amount){
                          Console.WriteLine($"{i}: {lang}");
                          i++;
                         }     

    Console.WriteLine("---1995-2005---");
              int k =1;
           List<string> years = (from l in languages
                                  where l.Year >= 1995 && l.Year <= 2005
                                  select l.Name).ToList();            


                    foreach(string lang in years){
                      Console.WriteLine($"{k}--{lang}");
                      k++;
                    }     

            IEnumerable<Language> years1995 = from l in languages
                                  where l.Year >= 1995 && l.Year <= 2005
                                  select l;        

                   
                    foreach(Language lang in years1995){
                      Console.WriteLine($"{lang.Name} was invented in {lang.Year}");
                    
                    }                    
    }
  }
}
