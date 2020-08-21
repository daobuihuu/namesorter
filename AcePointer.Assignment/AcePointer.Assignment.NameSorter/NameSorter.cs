using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AcePointer.Assignment.NameSorter.Comparer;
using AcePointer.Assignment.NameSorter.ImportsExports;
using AcePointer.Assignment.NameSorter.Models;

namespace AcePointer.Assignment.NameSorter
{
    public class NameSorter
    {
        public void Run()
        {
            var inputFullPath = GetAbsolutePath("unsorted-names-list.txt");
            var outputFullPath = GetAbsolutePath("sorted-names-list.txt");

            SortNames(inputFullPath, outputFullPath);
        }

        public void SortNames(string inputFullPath, string outputFullPath)
        {
            var names = ReadNamesFromFile(inputFullPath, new NamesFromTextFileImporter());

            Console.WriteLine($"Imported {names.Count} records");

            var sw = Stopwatch.StartNew();

            names.Sort(new PersonNameComparer());

            sw.Stop();
            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms.");

            WriteNames(names, new NamesToTextFileExporter(outputFullPath));

            WriteNames(names, new NamesToConsoleExporter());
        }

        public string GetAbsolutePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
        }

        private List<PersonName> ReadNamesFromFile(string filePath, IDataImporter<PersonName> dataImporter)
        {
            return dataImporter.ReadData(filePath);
        }

        private void WriteNames(List<PersonName> names, IDataExporter<PersonName> dataExporter)
        {
            dataExporter.Write(names);
        }
    }
}