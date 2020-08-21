namespace AcePointer.Assignment.NameSorter.Models
{
    public class PersonName
    {
        public PersonName(string givenName = "", string lastName = "")
        {
            GivenName = givenName;
            LastName = lastName;
        }

        public string LastName { get; set; }

        public string GivenName { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(LastName)
                ? GivenName : $"{GivenName} {LastName}";
        }
    }
}