// AbatabLogging 22.12.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221130.0736

/* ========================================================================================================
 * PLEASE READ
 * -----------
 * Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using AbatabSystem;
using System;
using System.IO;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for building log file paths.
    /// </summary>
    public static class BuildPath
    {
        /// <summary>
        /// Builds a log file path with caller information.
        /// </summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="logRoot">The session root directory.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>A completed log file path with caller information.</returns>
        public static string WithCaller(string eventType, string logRoot, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            // No log statement here (see comments at top of file)

            string logDir;

            switch (eventType)
            {
                case "debug":
                    logDir = BuildDebugLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.{eventType}";

                case "trace":
                    logDir = BuildTraceLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.trace";

                default:
                    logDir = BuildLostLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.lost";
            }
        }

        /// <summary>
        /// Builds a timestamped log file path.
        /// </summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="logRoot">The session root directory.</param>
        /// <returns>A completed log file path with a timestamp.</returns>
        public static string Timestamped(string eventType, string logRoot)
        {
            // No log statement here (see comments at top of file)

            string logDir;

            switch (eventType.ToLower())
            {
                case "primevaldebug":
                case "debuggler":
                    logDir = BuildPrimevalDebugLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}.{eventType}";

                case "webconfigdebug":
                    logDir = BuildDebugLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}.{eventType}";

                case "quickmedorder":
                case "session":
                    return $@"{logRoot}\{DateTime.Now:yyMMdd}.{eventType}";

                default:
                    logDir = BuildLostLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}.lost";
            }
        }

        /// <summary>
        /// Builds a log file path with the log message in the name.
        /// </summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="logRoot">The session root directory.</param>
        /// <param name="logMsg">The log message.</param>
        /// <returns>A log file path with the log message in the name.</returns>
        public static string MessageName(string eventType, string logRoot, string logMsg)
        {
            // No log statement here (see comments at top of file)

            string logDir;

            switch (eventType.ToLower())
            {
                case "access":
                    return $@"{logRoot}\{logMsg}.{eventType}";

                default:
                    logDir = BuildLostLogDir(logRoot);
                    return $@"{logDir}\{DateTime.Now:HHmmss_fffffff}.{eventType}";
            }
        }
        /// <summary>
        /// Build the path to a debug log.
        /// </summary>
        /// <param name="logRoot">The log root.</param>
        /// <returns>The path to the log root.</returns>
        private static string BuildDebugLogDir(string logRoot)
        {
            var debugLogDir = $@"{logRoot}\{DateTime.Now:yyMMdd}";
            Maintenance.VerifyDir(debugLogDir);

            return debugLogDir;
        }

        /// <summary>
        /// Build the path to a lost log.
        /// </summary>
        /// <param name="logRoot">The log root.</param>
        /// <returns>The path to the log root.</returns>
        private static string BuildLostLogDir(string logRoot)
        {
            var lostLogDir = $@"{logRoot}\{DateTime.Now:yyMMdd}";
            Maintenance.VerifyDir(lostLogDir);

            return lostLogDir;
        }

        /// <summary>
        /// Build the path to a primeval debug log.
        /// </summary>
        /// <param name="logRoot">The log root.</param>
        /// <returns>The path to the log root.</returns>
        private static string BuildPrimevalDebugLogDir(string logRoot)
        {
            var debugLogDir = $@"{logRoot}\debug\{DateTime.Now:yyMMdd}";
            Maintenance.VerifyDir(debugLogDir);

            return debugLogDir;
        }

        /// <summary>
        /// Build the path to a trace log.
        /// </summary>
        /// <param name="logRoot">The log root.</param>
        /// <returns>The path to the log root.</returns>
        private static string BuildTraceLogDir(string traceLogRoot)
        {
            var traceLogDir = $@"{traceLogRoot}\trace";
            Maintenance.VerifyDir(traceLogDir);

            return traceLogDir;
        }
    }
}