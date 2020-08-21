using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePointer.Assignment.NameSorter
{
    public class SortByName : IComparer<PersonName>
    {
        public int Compare(PersonName x, PersonName y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
}
