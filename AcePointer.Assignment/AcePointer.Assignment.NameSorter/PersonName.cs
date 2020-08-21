using System;

namespace AcePointer.Assignment.NameSorter
{
    public class PersonName : IComparable<PersonName>
    {
        public string LastName { get; set; }
        public string GivenName { get; set; }

        public PersonName(string givenName, string lastName)
        {
            if (string.IsNullOrEmpty(givenName))
            {
                throw new ArgumentException($"'{nameof(givenName)}' cannot be null or empty", nameof(givenName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty", nameof(lastName));
            }

            LastName = lastName;
            GivenName = givenName;
        }

        public int CompareTo(PersonName other)
        {
            return other.LastName.CompareTo(this.LastName);
        }
    }
}
