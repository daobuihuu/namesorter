using System;
using System.Collections.Generic;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public class NamesToConsoleExporter : IDataExporter<PersonName>
    {
        public void Write(List<PersonName> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}