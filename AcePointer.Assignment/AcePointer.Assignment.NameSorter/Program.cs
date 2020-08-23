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

            string outputFilePath = Utility.GetAbsolutePath(@"Data\sorted-names-list.txt");

            // Output result to console and text file
            IEnumerable<IDataExporter<PersonName>> outputs = new List<IDataExporter<PersonName>>
            {
                new PersonNameConsoleExporter(),
                new PersonNameTextFileExporter(outputFilePath)
            };

            using (serviceProvider as IDisposable)
            {
                var service = serviceProvider.GetRequiredService<NameSorter>();

                service.SortNames();
            }

            Console.Read();
        }

        private static IConfiguration GetConfiguration()
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            return config;
        }

        static IServiceProvider ConfigureServices(IConfiguration config)
        {
            string inputFilePath = Utility.GetAbsolutePath(config.GetValue<string>("InputRelativePath"));
            string outputFilePath = Utility.GetAbsolutePath(config.GetValue<string>("OutputRelativePath"));

            var serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs\\log.txt")
            .CreateLogger();

            var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddSerilog(serilogLogger))
            .AddScoped<NameSorter>()
            .AddScoped<ILogger<NameSorter>, Logger<NameSorter>>()
            //.AddScoped<IDataExporter<PersonName>, NamesToConsoleExporter>()
            //.AddScoped<IDataExporter<PersonName>, NamesToTextFileExporter>(x => new NamesToTextFileExporter(outputFilePath))
            .AddScoped<IDataImporter<PersonName>, PersonNameTextFileImporter>(x  => new PersonNameTextFileImporter(inputFilePath))
            .AddScoped<IDataExporter<PersonName>, CompositeDataExporter>(x => new CompositeDataExporter(
                new List<IDataExporter<PersonName>>
                {
                    // Use composite exporter to output to both console and text file
                    new PersonNameConsoleExporter(),
                    new PersonNameTextFileExporter(outputFilePath)
                }
             ))
            //.AddComposite<IDataExporter<PersonName>, CombinedDataExporter>()
            .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
