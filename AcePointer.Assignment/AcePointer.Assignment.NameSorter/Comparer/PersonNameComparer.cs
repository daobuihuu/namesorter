using System;
using System.Collections.Generic;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.Comparer
{
    public class PersonNameComparer : IComparer<PersonName>
    {
        private Func<PersonName, PersonName, int> _customComparer;

        public PersonNameComparer()
        {
        }

        public PersonNameComparer(Func<PersonName, PersonName, int> customComparer)
        {
            _customComparer = customComparer;
        }

        public int Compare(PersonName x, PersonName y)
        {
           return _customComparer != null ? _customComparer(x, y) : DefaultComparer(x, y);
        }

        private int DefaultComparer(PersonName x, PersonName y)
        {
            int result = x.LastName.CompareTo(y.LastName);
            return result != 0 ? result : x.GivenName.CompareTo(y.GivenName);
        }
    }
}
