// AbatabLogging 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221219.0925

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
using System.Collections.Generic;
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
        /// Log a user access event.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="accessMsg">The access log message.</param>
        public static void Access(Session abatabSession, string accessMsg)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingConfig.LoggingMode == "all" || abatabSession.LoggingConfig.LoggingMode.Contains("access"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.MessageName("access", abatabSession.LoggingConfig.SessionRoot, accessMsg);
                var logContent = BuildContent.LogComponents("access", abatabSession, accessMsg);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Builds a debug log file.
        /// </summary>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="debugMode">The Abatab debug mode.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="debugMsg">The debug log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void Debug(string exeAssembly, string debugMode, string debugLogRoot = "", string debugMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            /* Change this to "true" to write additional log files. This will significantly affect performance.
             */
            const bool debugDebugger = false;

            Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-001]");

            if (string.Equals(debugMode, "enabled", StringComparison.OrdinalIgnoreCase))
            {
                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-003]");
                var debugLogPath = BuildPath.WithCaller("debug", debugLogRoot, exeAssembly, callPath, callMember, callLine);

                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-002]");
                var debugContent = BuildContent.DebugComponents(exeAssembly, debugMode, debugMsg, callPath, callMember, callLine);

                Debuggler.DebugTheDebugger(debugDebugger, debugLogRoot, "[BuildDebugLog-004]");
                WriteLogFile.LocalFile(debugLogPath, debugContent, 10);
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
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingConfig.LoggingMode == "all" || abatabSession.LoggingConfig.LoggingMode.Contains("quickmedorder"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.Timestamped("quickmedorder",abatabSession.LoggingConfig.SessionRoot);
                var logContent = BuildContent.LogComponents("quickmedorder", abatabSession, logMsg);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Builds a debug log file.
        /// </summary>
        /// <param name="debugMode">The Abatab debug mode.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void PrimevalDebug(string debugMode, string exeAssembly, string primevalPath, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            if (string.Equals(debugMode, "enabled", StringComparison.OrdinalIgnoreCase))
            {
                var debugContent = BuildContent.DebugComponents(exeAssembly, debugMode, "[PRIMEVAL DEBUG]", callPath, callMember, callLine);
                var debugLogPath = BuildPath.Timestamped("primevaldebug", primevalPath);

                /* Delay creating a debug log by 10ms, just to make sure we don't overwrite an
                 * existing log. This will have a significant negative affect on performance.
                 */
                WriteLogFile.LocalFile(debugLogPath, debugContent, 10);
            }
        }

        /// <summary>
        /// Builds a session detail log.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="logMsg">The log message.</param>
        public static void Session(Session abatabSession, string logMsg = "Session detail log.")
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (abatabSession.LoggingConfig.LoggingMode == "all" || abatabSession.LoggingConfig.LoggingMode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                var logPath    = BuildPath.Timestamped("session", abatabSession.LoggingConfig.SessionRoot);
                var logContent = BuildContent.LogComponents("session", abatabSession, logMsg);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Build a trace log.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param
        /// <param name="logMsg">The log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void Trace(Session abatabSession, string exeAssembly, string logMsg = "Trace log start...", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            // Can't really put a trace log here!

            if (abatabSession.LoggingConfig.LoggingMode == "all" || abatabSession.LoggingConfig.LoggingMode.Contains("trace"))
            {
                // Can't really put a trace log here!
                var logPath    = BuildPath.WithCaller("trace", abatabSession.LoggingConfig.SessionRoot, exeAssembly, callPath, callMember, callLine);
                var logContent = BuildContent.LogComponents("trace", abatabSession, logMsg, exeAssembly, callPath, callMember, callLine);

                WriteLogFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingConfig.WriteDelay));
            }
        }

        /// <summary>
        /// Build a webConfig debug log.
        /// </summary>
        /// <param name="webConfig">The contents of Web.config.</param>
        public static void WebConfigDebug(Dictionary<string, string> webConfig)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"], "[DEBUG]");

            var webConfigContents = $"------------------{Environment.NewLine}" +
                                    $"webConfig contents{Environment.NewLine}" +
                                    $"------------------{Environment.NewLine}" +
                                    $"{Environment.NewLine}";

            var logContents = "";

            foreach (var item in webConfig)
            {
                logContents += $"{item.Key} = {item.Value}{Environment.NewLine}";
            }

            var logPath = BuildPath.Timestamped("webconfigdebug", webConfig["DebugLogRoot"]);
            WriteLogFile.LocalFile(logPath, logContents, Convert.ToInt32(webConfig["LogWriteDelay"]));
        }
    }
}