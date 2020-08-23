using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.Interfaces
{
    public interface IImportable<T>
    {
        IEnumerable<T> Collection { get; }
        ISortable<T> ImportData(string source);
    }
}
