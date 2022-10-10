/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * LogEvent.cs                                                                               b221009.090325
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
        /// <param name="logMsg"></param>
        public static void AllOptionObjectInformation(SessionData abatabSession, string logMsg = "OptionObject information log.")
        {
            BuildContent.LogComponents("allOptObjInformation", abatabSession, logMsg);
        }


        /// <summary>Build a session detail log.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMsg">Message for the logfile</param>
        public static void SessionDetail(SessionData abatabSession, string logMsg = "Session detail log.")
        {
            LogDebug.DebugContent(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating session log.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("session"))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.FinalOptObj.ErrorMesg);
                var logPath    = BuildPath.FullPath("session", abatabSession.SessionLogRoot);
                var logContent = BuildContent.LogComponents("sessionInformation", abatabSession, logMsg);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }

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
            LogDebug.DebugContent(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating trace log.");

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("trace"))
            {
                var logPath    = BuildPath.FullPath("trace", abatabSession.SessionLogRoot, exeAssembly, callPath, callMember, callLine);

                var logContent = BuildContent.LogComponents("trace", abatabSession, logMsg, exeAssembly, callPath, callMember, callLine);

                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }
        }
    }
}