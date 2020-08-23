using System;
using System.Collections.Generic;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.Comparer
{
    /// <summary>
    /// Defines comparer for personal name
    /// </summary>
    public class PersonNameComparer : IComparer<PersonName>
    {
        private readonly Func<PersonName, PersonName, int> _customComparer;

        public PersonNameComparer(Func<PersonName, PersonName, int> customComparer = null)
        {
            _customComparer = customComparer;
        }

        public int Compare(PersonName x, PersonName y)
        {
            // Compare object using default comparer (Last Name then Given Name) or custom comparer if passed in
            return _customComparer != null ? _customComparer(x, y) : DefaultComparer(x, y);
        }

        private int DefaultComparer(PersonName x, PersonName y)
        {
            // Compare last name first then given name
            int result = x.LastName.CompareTo(y.LastName);
            return result != 0 ? result : x.GivenName.CompareTo(y.GivenName);
        }
    }
}
