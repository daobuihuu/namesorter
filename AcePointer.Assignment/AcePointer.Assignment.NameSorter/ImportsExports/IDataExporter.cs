using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter.ImportsExports
{
    public interface IDataExporter<T>
    {
        void Write(ExportModel<T> exportModel);
    }
}