using System.Collections.Generic;
using System.IO.Enumeration;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public interface IDataImporter<T>
    {
        List<T> ReadData(string path);

        T ParseData(string value);
    }
}
