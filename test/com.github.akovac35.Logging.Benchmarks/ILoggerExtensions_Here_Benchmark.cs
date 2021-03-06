﻿// License:
// Apache License Version 2.0, January 2004

// Authors:
//   Aleksander Kovač

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using System;

namespace com.github.akovac35.Logging.Benchmarks
{
    [MinColumn, MaxColumn]
    public class ILoggerExtensions_Here_Benchmark
    {
        private ILogger _logger = LoggerFactoryProvider.LoggerFactory.CreateLogger<ILoggerExtensions_Here_Benchmark>();

        [Benchmark(Baseline = true)]
        public DateTime EnteringExitingWithoutHere()
        {
            _logger.Entering(DateTime.Now);

            _logger.Exiting(DateTime.Now);
            return DateTime.Now;
        }

        [Benchmark]
        public DateTime EnteringExitingWithHere()
        {
            _logger.Here(l => l.Entering(DateTime.Now));

            _logger.Here(l => l.Exiting(DateTime.Now));
            return DateTime.Now;
        }
    }
}
