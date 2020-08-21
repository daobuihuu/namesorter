using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AcePointer.Assignment.NameSorter
{
    public class PersonNameImporter : DataImporter<PersonName>
    {
        public override PersonName ParseData(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string[] splittedName = value.Split(" ");

                if (splittedName.Length > 1)
                {
                    // Parses last name (last part of a space), remaining would be given names
                    return new PersonName(value.Substring(0, value.Length - value.LastIndexOf(" ")), splittedName.Last());
                }
                else return null;
            }
            else return null;
        }
    }
}
