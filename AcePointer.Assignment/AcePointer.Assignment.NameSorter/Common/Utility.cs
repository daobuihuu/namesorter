using System.IO;

namespace AcePointer.Assignment.NameSorter.Common
{
    public class Utility
    {
        public static string GetAbsolutePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }
    }
}
