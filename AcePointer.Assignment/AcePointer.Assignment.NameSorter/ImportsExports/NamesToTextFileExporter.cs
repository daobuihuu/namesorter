using System.Collections.Generic;
using System.IO;
using System.Linq;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public class NamesToTextFileExporter : IDataExporter<PersonName>
    {
        private readonly string _fileName;

        public NamesToTextFileExporter(string fileName)
        {
            _fileName = fileName;
        }

        public void Write(List<PersonName> list)
        {
            File.WriteAllLines(_fileName, list.Select(x => x.ToString()));
        }
    }
}