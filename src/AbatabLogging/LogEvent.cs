/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * LogEvent.cs                                                                               b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Logic for log events.
 */

using AbatabData;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

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

        /// <summary>Basic debugging for a module.</summary>
        /// <param name="executingAssemblyName"></param>
        /// <param name="debugMode"></param>
        /// <param name="debugLogRoot"></param>
        /// <param name="debugMsg"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        public static void Debug(string executingAssemblyName, string debugMode, string debugLogRoot = "", string debugMsg = "", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            /* NOTE The advantage of debug logs is that they can be created prior to a SessionData object being created. You can put a LogEvent.Debug() call
             * anywhere in your code, and a logfile will be written. This is for development/debugging purposes, therefore the DebugMode setting in Web.config
             * should be set to "off" in your production environment.
             */

            if (debugMode == "on")
            {
                const bool debugDebugger = false;

                if (string.IsNullOrWhiteSpace(debugLogRoot))
                {
                    debugLogRoot = @"C:\AvatoolWebService\Abatab_UAT\logs\debug";
                }

                var debugLogDir = $@"{debugLogRoot}\{DateTime.Now:yyMMdd}"; // TODO Move this.
                _=Directory.CreateDirectory(debugLogDir);

                DebugDebugger(debugDebugger, debugLogDir, "001");

                if (string.Equals(debugMode, "on", StringComparison.OrdinalIgnoreCase))
                {
                    DebugDebugger(debugDebugger, debugLogDir, "002");

                    // NOTE Delay creating a debug log by 100ms, just to make sure we don't overwrite an existing log.
                    Thread.Sleep(100);

                    DebugDebugger(debugDebugger, debugLogDir, "003");

                    var debugContent = BuildContent.Debug(executingAssemblyName, debugMode, debugMsg, callerFilePath, callerMemberName, callerLine);

                    DebugDebugger(debugDebugger, debugLogDir, "004");

                    File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}-{executingAssemblyName}-{Path.GetFileName(callerFilePath)}-{callerMemberName}-{callerLine}.debug", debugContent);

                    DebugDebugger(debugDebugger, debugLogDir, "005");
                }

                DebugDebugger(debugDebugger, debugLogDir, "006");
            }
        }

        /// <summary>Debug the debugger.</summary>
        /// <param name="debugDebugger"></param>
        /// <param name="debugLogDir"></param>
        /// <param name="debugMsg"></param>
        private static void DebugDebugger(bool debugDebugger, string debugLogDir, string debugMsg)
        {
            /* This will significantly slow down Abatab, and should only be used when developing/debugging.
             */
            if (debugDebugger)
            {
                Thread.Sleep(1000);

                File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}-Debugger[{debugMsg}].debug", debugMsg);
            }
        }

        /// <summary>Build a session information log.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void SessionInformation(SessionData abatabSession, string logMessage = "Session information log.")
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating session log.");
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
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating trace log.");

            if (abatabSession.LoggingMode == "all" || abatabSession.LoggingMode.Contains("trace"))
            {
                var logPath    = BuildPath.FullPath("trace", abatabSession.SessionLogDir, executingAssemblyName, callerFilePath, callerMemberName, callerLine);
                var logContent = BuildContent.LogContent("trace", abatabSession, logMessage, executingAssemblyName, callerFilePath, callerMemberName, callerLine);
                LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", $"{logPath}");
                WriteFile.LocalFile(logPath, logContent, Convert.ToInt32(abatabSession.LoggingDelay));
            }
        }
    }
}