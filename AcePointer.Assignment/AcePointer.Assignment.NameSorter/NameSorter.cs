using System;
using System.Collections.Generic;
using System.Diagnostics;
using AcePointer.Assignment.NameSorter.Comparer;
using AcePointer.Assignment.NameSorter.ImportsExports;
using AcePointer.Assignment.NameSorter.Models;
using Microsoft.Extensions.Logging;

namespace AcePointer.Assignment.NameSorter
{
    public class NameSorter
    {
        private readonly IDataImporter<PersonName> _importer;
        private readonly IDataExporter<PersonName> _exporter;
        private readonly ILogger<NameSorter> _logger;

        public NameSorter(IDataImporter<PersonName> importer, IDataExporter<PersonName> exporter, ILogger<NameSorter> logger)
        {
            _importer = importer ?? throw new ArgumentNullException(nameof(importer));
            _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void SortNames()
        {
            var names = ReadNamesFromFile();

            Console.WriteLine($"Imported {names.Count} records");
            _logger.LogInformation($"Imported {names.Count} records");

            var sw = Stopwatch.StartNew();
            names.Sort(new PersonNameComparer());
            sw.Stop();

            Console.WriteLine($"Imported {names.Count} records");
            _logger.LogInformation($"Sorting time: {sw.ElapsedMilliseconds}ms.");

            WriteNames(names);
        }

        private List<PersonName> ReadNamesFromFile()
        {
            return _importer.ReadData();
        }

        private void WriteNames(List<PersonName> names)
        {
            _exporter.Write(names);
        }
    }
}