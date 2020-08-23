using System;
using System.IO;
using System.Linq;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public class PersonNameTextFileExporter : IDataExporter<PersonName>
    {
        public void Write(ExportModel<PersonName> exportModel)
        {
            if (exportModel == null) throw new ArgumentNullException(nameof(exportModel));
            if (string.IsNullOrEmpty(exportModel.FilePath)) throw new ArgumentException("File path missing");

            File.WriteAllLines(exportModel.FilePath, exportModel.Collection.Select(x => x.ToString()));
        }
    }
}