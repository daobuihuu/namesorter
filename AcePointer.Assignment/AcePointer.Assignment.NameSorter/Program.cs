using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AcePointer.Assignment.NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            List<PersonName> names = LoadNames(config.GetValue<string>("FileName"));

            Console.WriteLine($"Imported {names.Count} records");

            DateTime start = DateTime.Now;
            //var sorted = names.OrderBy(x => x.LastName).ThenBy(x => x.GivenName);
            names.Sort(new PersonNameComparer());

            TimeSpan span = DateTime.Now.Subtract(start);

            Console.WriteLine($"Total sorting time: {span.Hours} hours {span.Minutes} minutes {span.Seconds} seconds {span.Milliseconds} milliseconds");

            PrintNames(names);

            Console.Read();
        }

        private static List<PersonName> LoadNames(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);

            PersonNameImporter importer = new PersonNameImporter();
            return importer.LoadData(filePath);
        }

        private static void PrintNames(List<PersonName> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToString());
            }
        }


        //List<PersonName> names = new List<PersonName>();
        //names.Add(new PersonName("Janet",  "Parsons"));
        //names.Add(new PersonName("Vaughn", "Lewis"));
        //names.Add(new PersonName("Adonis Julius", "Archer"));
        //names.Add(new PersonName("Shelby Nathan", "Yoder"));

        //names.Sort(new SortByName());
    }
}
