using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public class NamesFromTextFileImporter : IDataImporter<PersonName>
    {
        public List<PersonName> ReadData(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path).Select(ParseData).ToList();
            }

            throw new FileNotFoundException();
        }

        public PersonName ParseData(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return new PersonName();
            }

            fullName = fullName.Trim();
            var lastSpace = fullName.LastIndexOf(" ", StringComparison.Ordinal);

            if (lastSpace < 0)
            {
                return new PersonName(fullName);
            }

            return new PersonName
                (fullName.Substring(0, lastSpace), fullName.Substring(lastSpace + 1));
        }
    }
}
