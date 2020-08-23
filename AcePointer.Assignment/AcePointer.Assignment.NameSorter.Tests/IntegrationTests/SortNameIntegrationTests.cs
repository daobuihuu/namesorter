using AcePointer.Assignment.NameSorter.Common;
using AcePointer.Assignment.NameSorter.ImportsExports;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System.IO;

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
            _inputFullPath = Utility.GetAbsolutePath(@"Data\unsorted-names-list.txt");
            _outputFullPath = Utility.GetAbsolutePath(@"Data\sorted-names-list.txt");
            _expectedOutputFullPath = Utility.GetAbsolutePath(@"Data\expected-sorted-names-list.txt");

            ILoggerFactory loggerFactory = new NullLoggerFactory();

            _sorter = new NameSorter(new PersonNameTextFileImporter(_inputFullPath),
                new PersonNameTextFileExporter(_outputFullPath),
                loggerFactory.CreateLogger<NameSorter>());
        }

        [Test]
        public void Should_Export_File_With_Correct_Order()
        {
            _sorter.SortNames();

            string sortedNamesContent = File.ReadAllText(_outputFullPath);
            string expectedNamesContent = File.ReadAllText(_expectedOutputFullPath);

            sortedNamesContent.Should().Be(expectedNamesContent);
        }
    }
}
