/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * LogEvent.cs                                                                               b221009.144127
 * --------------------------------------------------------------------------------------------------------
 * Build a log files.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AbatabLogging
{
    public class LogEvent
    {
        /// <summary>Build a OptionObject information log.</summary>
        /// <param name="abatabSession"></param>
        /// <param name="logMessage"></param>
        public static void AllOptionObjectInformation(SessionData abatabSession, string logMessage = "OptionObject information log.")
        {
            BuildContent.LogContent("allOptObjInformation", abatabSession, logMessage);
        }


        /// <summary>Build a session information log.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void SessionInformation(SessionData abatabSession, string logMessage = "Session information log.")
        {
            LogDebug.Debugger(abatabSession.DebugMode, "[DEBUG] Creating session log.", abatabSession.DebugLogRoot, Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);
                var logPath    = BuildPath.FullPath("session", abatabSession.SessionLogDir);
                var logContent = BuildContent.LogContent("sessionInformation", abatabSession, logMessage);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }

        }

        /// <summary>Build a trace log.</summary>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void Trace(SessionData abatabSession, string executingAssemblyName, string logMessage = "Trace log start...", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            LogDebug.Debugger(abatabSession.DebugMode, "[DEBUG] Creating trace log.", abatabSession.DebugLogRoot, Assembly.GetExecutingAssembly().GetName().Name);

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("trace"))
            {
                var logPath    = BuildPath.FullPath("trace", abatabSession.SessionLogDir, executingAssemblyName, callerFilePath, callerMemberName, callerLine);

                var logContent = BuildContent.LogContent("trace", abatabSession, logMessage, executingAssemblyName, callerFilePath, callerMemberName, callerLine);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }
        }
    }
}