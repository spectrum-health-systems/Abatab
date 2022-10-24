// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221024.091417

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

using System;
using System.IO;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for building log file paths.
    /// </summary>
    public static class BuildPath
    {
        /// <summary>Builds a log file path.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="logRoot">The session root directory.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>A completed log file path.</returns>
        public static string FullPath(string eventType, string logRoot, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
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

        /// <summary>Builds a log file path.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="logRoot">The session root directory.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>A completed log file path.</returns>
        public static string FullPath(string eventType, string logRoot)
        {
            // No log statement here (see comments at top of file)

            string logDir;

            switch (eventType.ToLower())
            {
                case "primevaldebug":
                case "debuggler":
                    logDir = BuildDebugLogDir(logRoot);
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
        ///
        /// </summary>
        /// <param name="logRoot"></param>
        /// <param name="dateStamp"></param>
        /// <returns></returns>
        private static string BuildDebugLogDir(string logRoot)
        {
            var debugLogDir = $@"{logRoot}\{DateTime.Now:yyMMdd}";
            AbatabSystem.Maintenance.VerifyDir(debugLogDir);

            return debugLogDir;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="logRoot"></param>
        /// <param name="dateStamp"></param>
        /// <returns></returns>
        private static string BuildLostLogDir(string logRoot)
        {
            var lostLogDir = $@"{logRoot}\{DateTime.Now:yyMMdd}";
            AbatabSystem.Maintenance.VerifyDir(lostLogDir);

            return lostLogDir;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="logRoot"></param>
        /// <param name="dateStamp"></param>
        /// <returns></returns>
        private static string BuildTraceLogDir(string traceLogRoot)
        {
            var traceLogDir = $@"{traceLogRoot}\trace";
            AbatabSystem.Maintenance.VerifyDir(traceLogDir);

            return traceLogDir;
        }
    }
}