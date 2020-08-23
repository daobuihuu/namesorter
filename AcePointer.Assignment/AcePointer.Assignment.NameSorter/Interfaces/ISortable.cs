namespace AcePointer.Assignment.NameSorter.Interfaces
{
    public interface ISortable<T> : IExportable<T>
    {
        IExportable<T> SortData();
    }
}
