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
            _inputFullPath = Utility.GetFullFilePath(@"Data\unsorted-names-list.txt");
            _outputFullPath = Utility.GetFullFilePath(@"Data\sorted-names-list.txt");
            _expectedOutputFullPath = Utility.GetFullFilePath(@"Data\expected-sorted-names-list.txt");

            ILoggerFactory loggerFactory = new NullLoggerFactory();

            _sorter = new NameSorter(new PersonNameTextFileImporter(),
                new PersonNameTextFileExporter(),
                loggerFactory.CreateLogger<NameSorter>());
        }

        [Test]
        public void Should_Import_From_File_Successfully_With_1000_Records()
        {
            _sorter.ImportData(_inputFullPath);

            _sorter.Collection.Should().HaveCount(1000);
        }

        [Test]
        public void Should_Sort_And_Export_To_File_With_Correct_Order()
        {
            _sorter.ImportData(_inputFullPath)
                .SortData()
                .ExportData(_outputFullPath);

            string sortedNamesContent = File.ReadAllText(_outputFullPath);
            string expectedNamesContent = File.ReadAllText(_expectedOutputFullPath);

            sortedNamesContent.Should().Be(expectedNamesContent);
        }
    }
}
