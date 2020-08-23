namespace AcePointer.Assignment.NameSorter.Logger
{
    public interface ICustomLogger
    {
        void LogInformation(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
