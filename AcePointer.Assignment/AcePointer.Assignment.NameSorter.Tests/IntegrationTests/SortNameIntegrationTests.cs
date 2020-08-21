using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePointer.Assignment.NameSorter.Tests.IntegrationTests
{
    [TestFixture]
    public class SortNameIntegrationTests
    {
        NameSorter _sorter;
        string _inputFullPath;
        string _outputFullPath;
        string _expectedOutputFullPath;

        [SetUp]
        public void SetUp_Integration_Test_With_Exported_File()
        {
            _sorter = new NameSorter();
            _inputFullPath = _sorter.GetAbsolutePath("unsorted-names-list.txt");
            _outputFullPath = _sorter.GetAbsolutePath("sorted-names-list.txt");
            _expectedOutputFullPath = _sorter.GetAbsolutePath("expected-sorted-names-list.txt");
        }

        [Test]
        public void Should_Export_File_With_Correct_Order()
        {
            _sorter.SortNames(_inputFullPath, _outputFullPath);

            string sortedNamesContent = File.ReadAllText(_outputFullPath);
            string expectedNamesContent = File.ReadAllText(_expectedOutputFullPath);

            sortedNamesContent.Should().Be(expectedNamesContent);
        }
    }
}
