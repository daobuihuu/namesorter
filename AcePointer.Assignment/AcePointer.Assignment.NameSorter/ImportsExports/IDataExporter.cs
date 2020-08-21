using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public interface IDataExporter<T>
    {
        void Write(List<T> list);
    }
}