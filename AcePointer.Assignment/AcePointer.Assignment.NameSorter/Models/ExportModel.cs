using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.Models
{
    public class ExportModel<T>
    {
        public List<T> Collection { get; }
        public string FilePath { get; }

        public ExportModel(List<T> collection, string filePath)
        {
            Collection = collection;
            FilePath = filePath;
        }
    }
}