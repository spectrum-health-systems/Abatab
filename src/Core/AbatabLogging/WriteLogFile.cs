// Abatab.AbatabLogging.WriteLogFile.cs b230109.1159
// Copyright (c) A Pretty Cool Program

/* ========================================================================================================
 * Logging is done a little differently in AbatabLogging classes, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using System.IO;
using System.Threading;

namespace AbatabLogging
{
    /// <summary>Logic for writing log files.</summary>
    public static class WriteLogFile
    {
        /// <summary>Writes a log file.</summary>
        /// <param name="logPath">The log file path.</param>
        /// <param name="logContent">The log file content.</param>
        /// <param name="loggingDelay">The delay between writing log files.</param>
        public static void LocalFile(string logPath, string logContent, int loggingDelay)
        {
            // No log statement here (see comments at top of file)

            Thread.Sleep(loggingDelay);

            File.WriteAllText(logPath, logContent);
        }
    }
}