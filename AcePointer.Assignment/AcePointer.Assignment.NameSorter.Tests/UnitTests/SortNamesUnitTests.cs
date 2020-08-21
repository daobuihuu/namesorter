using AcePointer.Assignment.NameSorter.Comparer;
using AcePointer.Assignment.NameSorter.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.Tests.UnitTests
{
    [TestFixture]
    public class SortNamesUnitTests
    {
        [Test]
        public void Should_Has_Correct_Sort_Order_With_Full_Given_Name_And_Last_Name()
        {
            List<PersonName> names = GivenUnsortedListFromAssignment();
            List<PersonName> sortedNames = GivenUnsortedListFromAssignment();

            names.Sort(new PersonNameComparer());

            names.Should().BeEquivalentTo(sortedNames);
        }

        [Test]
        public void Should_Has_Correct_Sort_Order_For_Only_Single_Given_Name()
        {
            List<PersonName> names = GivenUnsortedListWithOnlyGivenName();
            List<PersonName> sortedNames = GivenSortedListWithOnlyGivenName();

            names.Sort(new PersonNameComparer());

            names.Should().BeEquivalentTo(sortedNames);
        }

        [Test]
        public void Should_Has_Correct_Sort_Order_With_Same_Last_Name()
        {
            List<PersonName> names = GivenUnsortedListWithSameLastName();
            List<PersonName> sortedNames = GivenSortedListWithSameLastName();

            names.Sort(new PersonNameComparer());

            names.Should().BeEquivalentTo(sortedNames);
        }

        [Test]
        public void Should_Has_Correct_Sort_Order_With_Same_Given_Name()
        {
            List<PersonName> names = GivenUnsortedListWithSameGivenName();
            List<PersonName> sortedNames = GivenSortedListWithSameGivenName();

            names.Sort(new PersonNameComparer());

            names.Should().BeEquivalentTo(sortedNames);
        }

        private static List<PersonName> GivenUnsortedListFromAssignment()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet", "Parsons"));
            names.Add(new PersonName("Vaughn", "Lewis"));
            names.Add(new PersonName("Adonis Julius", "Archer"));
            names.Add(new PersonName("Shelby Nathan", "Yoder"));
            names.Add(new PersonName("Marin", "Alvarez"));
            names.Add(new PersonName("London", "Lindsey"));
            names.Add(new PersonName("Beau Tristan", "Bentley"));
            names.Add(new PersonName("Leo", "Gardner"));
            names.Add(new PersonName("Hunter Uriah Mathew", "Clarke"));
            names.Add(new PersonName("Mikayla", "Lopez"));
            names.Add(new PersonName("Frankie Conner", "Ritter"));

            return names;
        }

        private static List<PersonName> GivenSortedListFromAssignment()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Marin", "Alvarez"));
            names.Add(new PersonName("Adonis Julius", "Archer"));
            names.Add(new PersonName("Beau Tristan", "Bentley"));
            names.Add(new PersonName("Hunter Uriah Mathew", "Clarke"));
            names.Add(new PersonName("Leo", "Gardner"));
            names.Add(new PersonName("Vaughn", "Lewis"));
            names.Add(new PersonName("London", "Lindsey"));
            names.Add(new PersonName("Mikayla", "Lopez"));
            names.Add(new PersonName("Janet", "Parsons"));
            names.Add(new PersonName("Frankie Conner", "Ritter"));
            names.Add(new PersonName("Shelby Nathan", "Yoder"));

            return names;
        }

        private static List<PersonName> GivenUnsortedListWithOnlyGivenName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet"));
            names.Add(new PersonName("Vaughn"));
            names.Add(new PersonName("Marin"));
            names.Add(new PersonName("London"));

            return names;
        }

        private static List<PersonName> GivenSortedListWithOnlyGivenName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet"));
            names.Add(new PersonName("London"));
            names.Add(new PersonName("Marin"));
            names.Add(new PersonName("Vaughn"));

            return names;
        }

        private static List<PersonName> GivenUnsortedListWithSameLastName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet", "Abbot"));
            names.Add(new PersonName("Vaughn", "Abbot"));
            names.Add(new PersonName("Marin", "Abbot"));
            names.Add(new PersonName("London", "Abbot"));

            return names;
        }

        private static List<PersonName> GivenSortedListWithSameLastName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet", "Abbot"));
            names.Add(new PersonName("London", "Abbot"));
            names.Add(new PersonName("Marin", "Abbot"));
            names.Add(new PersonName("Vaughn", "Abbot"));

            return names;
        }

        private static List<PersonName> GivenUnsortedListWithSameGivenName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet", "Parsons"));
            names.Add(new PersonName("Janet", "Lewis"));
            names.Add(new PersonName("Janet", "Archer"));
            names.Add(new PersonName("Janet", "Yoder"));

            return names;
        }

        private static List<PersonName> GivenSortedListWithSameGivenName()
        {
            List<PersonName> names = new List<PersonName>();

            names.Add(new PersonName("Janet", "Archer"));
            names.Add(new PersonName("Janet", "Lewis"));
            names.Add(new PersonName("Janet", "Parsons"));
            names.Add(new PersonName("Janet", "Yoder"));

            return names;
        }
    }
}
