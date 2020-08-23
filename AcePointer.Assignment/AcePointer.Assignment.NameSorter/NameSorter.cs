using System;
using System.Collections.Generic;
using System.Diagnostics;
using AcePointer.Assignment.NameSorter.Comparer;
using AcePointer.Assignment.NameSorter.ImportsExports;
using AcePointer.Assignment.NameSorter.Interfaces;
using AcePointer.Assignment.NameSorter.Models;
using Microsoft.Extensions.Logging;

namespace AcePointer.Assignment.NameSorter
{
    public class NameSorter : IImportable<PersonName>, ISortable<PersonName>
    {
        private readonly IDataImporter<PersonName> _importer;
        private readonly IDataExporter<PersonName> _exporter;
        private readonly ILogger<NameSorter> _logger;

        private List<PersonName> _names = new List<PersonName>();

        public IEnumerable<PersonName> Collection => _names;

        public NameSorter(IDataImporter<PersonName> importer, IDataExporter<PersonName> exporter, ILogger<NameSorter> logger)
        {
            _importer = importer ?? throw new ArgumentNullException(nameof(importer));
            _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ISortable<PersonName> ImportData(string filePath)
        {
            _names = _importer.ReadData(filePath);

            _logger.LogInformation($"Imported {_names.Count} records from '{filePath}'");

            return this;
        }

        IExportable<PersonName> ISortable<PersonName>.SortData()
        {
            var sw = Stopwatch.StartNew();
            _names.Sort(new PersonNameComparer());
            sw.Stop();

            _logger.LogInformation($"Sorting time: {sw.ElapsedMilliseconds}ms.");

            return this;
        }

        ISortable<PersonName> IExportable<PersonName>.ExportData(string filePath)
        {
            var exportModel = new ExportModel<PersonName>(_names, filePath);
            _exporter.Write(exportModel);

            return this;
        }
    }
}