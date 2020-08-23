using System;
using System.Collections.Generic;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public class PersonNameConsoleExporter : IDataExporter<PersonName>
    {
        public void Write(ExportModel<PersonName> exportModel)
        {
            foreach (var name in exportModel.Collection)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}