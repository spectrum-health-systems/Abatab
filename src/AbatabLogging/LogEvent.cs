/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabLogging.csproj                                                                             v0.92.0
 * LogEvent.cs                                                                               b221010.124123
 * --------------------------------------------------------------------------------------------------------
 * Build a log files.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

/* Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates  logs results in strange behavior. For the most part, LogEvent.Trace() is replaced
 * with Debugger.BuildDebugLog(), although in some cases log files aren't written at all. This makes it a
 * little difficult to troubleshoot logging, which is why it's a good idea to test the logging funcionality
 * extensively prior to deploying to production.
 */

using AbatabData;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AbatabLogging
{
    public class LogEvent
    {
        /// <summary>Build a session detail log.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMsg">Message for the logfile</param>
        public static void Session(SessionData abatabSession, string logMsg = "Session detail log.")
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating session log.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);

                var logPath    = BuildPath.FullPath("session", abatabSession.SessionLogRoot);
                var logContent = BuildContent.LogComponents("session", abatabSession, logMsg);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);
        }

        /// <summary>Build a trace log.</summary>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMsg">Message for the logfile</param>
        /// <param name="callerPath">Filename of where the log is coming from.</param>
        /// <param name="callerMember">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void Trace(SessionData abatabSession, string exeAssembly, string logMsg = "Trace log start...", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating trace log.");

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("trace"))
            {
                var logPath    = BuildPath.FullPath("trace", abatabSession.SessionLogRoot, exeAssembly, callPath, callMember, callLine);
                var logContent = BuildContent.LogComponents("trace", abatabSession, logMsg, exeAssembly, callPath, callMember, callLine);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }
        }
    }
}