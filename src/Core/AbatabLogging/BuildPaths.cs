// Abatab.AbatabLogging.BuildPaths.cs b230123.1210
// Copyright (c) A Pretty Cool Program

/* ========================================================================================================
 * Logging is done a little differently in AbatabLogging classes, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using System;
using System.Collections.Generic;

namespace AbatabLogging
{
    /// <summary>Logic for building multiople log file paths.</summary>
    public static class BuildPaths
    {
        /// <summary>TBD</summary>
        /// <param name="abatabUserName"></param>
        /// <param name="logDirs"></param>
        /// <returns></returns>
        public static List<string> BuildWarningLogPaths(string abatabUserName, List<string> logDirs)
        {
            var warningLogDirs = new List<string>();

            foreach (var logDir in logDirs)
            {
                warningLogDirs.Add($@"{logDir}\{abatabUserName}-{DateTime.Now:yyMMdd_HHmmss}.warning");
            }

            return warningLogDirs;
        }
    }
}
