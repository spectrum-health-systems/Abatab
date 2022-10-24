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
        /// <summary>Builds a debug log file.</summary>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="debugMode">The Abatab debug mode.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="debugMsg">The debug log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void PrimevalDebug(string debugMode, string exeAssembly, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            if (string.Equals(debugMode, "on", StringComparison.OrdinalIgnoreCase))
            {
                var debugContent = BuildContent.DebugComponents(exeAssembly, debugMode, "[PRIMEVAL DEBUG]", callPath, callMember, callLine);
                var debugLogPath = BuildPath.FullPath("primevaldebug", @"C:\AvatoolWebService\Abatab_UAT\logs", exeAssembly, callPath, callMember, callLine);

                /* Delay creating a debug log by 10ms, just to make sure we don't overwrite an
                 * existing log. This will have a significant negative affect on performance.
                 */
                WriteLogFile.LocalFile(debugLogPath, debugContent, 5);
            }
        }

        /// <summary>Builds a debug log file.</summary>
        /// <param name="debugMode">The Abatab debug mode.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="debugMsg">The debug log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void BuildDebugLog(string exeAssembly, string debugMode, string debugLogRoot = "", string debugMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Change this to "true" to write additional log files. This will significantly affect performance.
             */
            const bool debugDebugger = true;

            Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-001]");

            if (string.Equals(debugMode, "on", StringComparison.OrdinalIgnoreCase))
            {
                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-003]");
                var debugLogPath = BuildPath.FullPath("debug", debugLogRoot, exeAssembly, callPath, callMember, callLine);

                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-002]");
                var debugContent = BuildContent.DebugComponents(exeAssembly, debugMode, debugMsg, callPath, callMember, callLine);

                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-004]");
                WriteLogFile.LocalFile(debugLogPath, debugContent, 5);
            }

            Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-005]");
        }

        /// <summary>
        /// Builds detailed information for the QuickMedOrder module.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="logMsg">The log message.</param>
        public static void ModQuickMedOrder(Session abatabSession, string logMsg = "QuickMedOrder detail log.")
        {
            LogEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingConfig.Mode == "all" || abatabSession.LoggingConfig.Mode.Contains("quickmedorder"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.FullPath("session",abatabSession.LoggingConfig.SessionRoot, abatabSession.SessionTimeStamp);
                var logContent = BuildContent.LogComponents("quickmedorder", abatabSession, logMsg);
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, logPath);
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, logContent);
                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
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
            LogEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingConfig.Mode == "all" || abatabSession.LoggingConfig.Mode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.FullPath("session", abatabSession.LoggingConfig.SessionRoot, abatabSession.SessionTimeStamp);
                var logContent = BuildContent.LogComponents("session", abatabSession, logMsg);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
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
            LogEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            // Can't really put a trace log here!

            if (abatabSession.LoggingConfig.Mode == "all" || abatabSession.LoggingConfig.Mode.Contains("trace"))
            {
                // Can't really put a trace log here!
                var logPath    = BuildPath.FullPath("trace", abatabSession.LoggingConfig.SessionRoot, exeAssembly, callPath, callMember, callLine);
                var logContent = BuildContent.LogComponents("trace", abatabSession, logMsg, exeAssembly, callPath, callMember, callLine);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
            }
        }
    }
}