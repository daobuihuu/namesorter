using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AcePointer.Assignment.NameSorter.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private readonly IEnumerable<ILogger> _loggers;

        public CustomLogger(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers ?? throw new ArgumentNullException(nameof(loggers));
        }

        public void LogDebug(string message)
        {
            foreach (var item in _loggers)
            {
                item.LogDebug(message);
            }
        }

        public void LogError(string message)
        {
            foreach (var item in _loggers)
            {
                item.LogError(message);
            }
        }

        public void LogInformation(string message)
        {
            foreach (var item in _loggers)
            {
                item.LogInformation(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (var item in _loggers)
            {
                item.LogWarning(message);
            }
        }
    }
}
