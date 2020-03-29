﻿// Author: Microsoft, Aleksander Kovač

using Microsoft.Extensions.Logging;
using System;

namespace com.github.akovac35.Logging.Testing
{
    public class TestLogger<T> : ILogger
    {
        private readonly ILogger _logger;

        public TestLogger(TestLoggerFactory factory)
        {
            _logger = factory.CreateLogger<T>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            _logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}