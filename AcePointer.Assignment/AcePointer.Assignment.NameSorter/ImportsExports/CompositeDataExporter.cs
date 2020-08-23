using AcePointer.Assignment.NameSorter.Models;
using System;
using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    /// <summary>
    /// Composite exporter to export data to multiple targets
    /// </summary>
    public class CompositeDataExporter : IDataExporter<PersonName>
    {
        private readonly IEnumerable<IDataExporter<PersonName>> _exporters;

        public CompositeDataExporter(IEnumerable<IDataExporter<PersonName>> exporters)
        {
            _exporters = exporters ?? throw new ArgumentNullException(nameof(exporters));
        }

        public void Write(List<PersonName> list)
        {
            foreach (var exporter in _exporters)
            {
                exporter.Write(list);
            }
        }
    }
}
