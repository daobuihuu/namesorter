using AcePointer.Assignment.NameSorter.Common;
using AcePointer.Assignment.NameSorter.ImportsExports;
using AcePointer.Assignment.NameSorter.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var serviceProvider = ConfigureServices(config);

            string inputFilePath = Utility.GetFullFilePath(config.GetValue<string>("InputRelativePath"));
            string outputFilePath = Utility.GetFullFilePath(config.GetValue<string>("OutputRelativePath"));

            using (serviceProvider as IDisposable)
            {
                var nameSorter = serviceProvider.GetRequiredService<NameSorter>();

                nameSorter
                    .ImportData(inputFilePath)
                    .SortData()
                    .ExportData(outputFilePath);
            }

            Console.Read();
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        }

        static IServiceProvider ConfigureServices(IConfiguration config)
        {
            var serilogLogger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

            var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddSerilog(serilogLogger))
            .AddScoped<NameSorter>()
            .AddScoped<ILogger<NameSorter>, Logger<NameSorter>>()
            .AddScoped<IDataImporter<PersonName>, PersonNameTextFileImporter>()
            .AddScoped<IDataExporter<PersonName>, CompositeDataExporter>(x => new CompositeDataExporter(
                new List<IDataExporter<PersonName>>
                {
                    // Use composite exporter to output to both console and text file
                    new PersonNameConsoleExporter(),
                    new PersonNameTextFileExporter()
                }
             ))
            .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
