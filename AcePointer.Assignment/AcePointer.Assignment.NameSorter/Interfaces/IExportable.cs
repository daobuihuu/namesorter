using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.Interfaces
{
    public interface IExportable<T>
    {
        IEnumerable<T> Collection { get; }
        ISortable<T> ExportData(string filePath);
    }
}
