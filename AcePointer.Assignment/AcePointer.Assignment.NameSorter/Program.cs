using System;
using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonName> names = new List<PersonName>();
            names.Add(new PersonName("Janet",  "Parsons"));
            names.Add(new PersonName("Vaughn", "Lewis"));
            names.Add(new PersonName("Adonis Julius", "Archer"));
            names.Add(new PersonName("Shelby Nathan", "Yoder"));

            names.Sort(new SortByName());

            foreach (var item in names)
            {
                Console.WriteLine($"{item.GivenName} {item.LastName}");
            }

            Console.Read();
        }
    }
}
