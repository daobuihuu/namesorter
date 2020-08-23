namespace AcePointer.Assignment.NameSorter.Models
{
    public class PersonName
    {
        public PersonName(string givenName = "", string lastName = "")
        {
            GivenName = givenName;
            LastName = lastName;
        }

        public string LastName { get; private set; }

        public string GivenName { get; private set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(LastName)
                ? GivenName : $"{GivenName} {LastName}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PersonName))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            PersonName person = (PersonName)obj;

            return LastName == person.LastName && GivenName == person.GivenName;
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() ^ GivenName.GetHashCode();
        }
    }
}