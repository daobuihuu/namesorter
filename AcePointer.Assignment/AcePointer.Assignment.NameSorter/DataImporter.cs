using System.Collections.Generic;
using System.IO;

namespace AcePointer.Assignment.NameSorter
{
    public abstract class DataImporter<T>
    {
        public virtual List<T> LoadData(string path)
        {
            if (File.Exists(path))
            {
                List<T> list = new List<T>();

                foreach (var line in File.ReadLines(path))
                {
                    T parsedData = ParseData(line);

                    if (parsedData != null)
                        list.Add(parsedData);
                }

                return list;
            }
            else throw new FileNotFoundException();
        }

        public abstract T ParseData(string value);
    }
}
