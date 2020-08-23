using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public interface IDataImporter<T>
    {
        List<T> ReadData(string source);
    }
}
