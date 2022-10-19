﻿// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221019.101024

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

using AbatabData;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for building log files for various events.
    /// </summary>
    public static class LogEvent
    {
        /// <summary>
        /// Builds detailed information for the QuickMedOrder module.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="logMsg">The log message.</param>
        public static void ModQuickMedOrder(Session abatabSession, string logMsg = "QuickMedOrder detail log.")
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("quickmedorder"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.FullPath("quickmedorder",abatabSession.SessionTimeStamp, abatabSession.SessionLogRoot);
                var logContent = BuildContent.LogComponents("quickmedorder", abatabSession, logMsg);
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, logPath);
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, logContent);
                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Builds a session detail log.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="logMsg">The log message.</param>
        public static void Session(Session abatabSession, string logMsg = "Session detail log.")
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.FullPath("session", abatabSession.SessionTimeStamp, abatabSession.SessionLogRoot);
                var logContent = BuildContent.LogComponents("session", abatabSession, logMsg);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>Build a trace log.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param
        /// <param name="logMsg">The log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void Trace(Session abatabSession, string exeAssembly, string logMsg = "Trace log start...", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG]");
            // Can't really put a trace log here!

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("trace"))
            {
                // Can't really put a trace log here!
                var logPath    = BuildPath.FullPath("trace", abatabSession.SessionTimeStamp, abatabSession.SessionLogRoot, exeAssembly, callPath, callMember, callLine);
                var logContent = BuildContent.LogComponents("trace", abatabSession, logMsg, exeAssembly, callPath, callMember, callLine);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }
        }
    }
}