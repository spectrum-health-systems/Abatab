﻿/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * LogEvent.cs                                                                               b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AbatabLogging
{
    public class LogEvent
    {
        /// <summary>
        /// Build a OptionObject information log.
        /// </summary>
        /// <param name="optObjType">Type of OptionObject.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void AllOptionObjectInformation(SessionData abatabSession, string logMessage = "OptionObject information log.")
        {
            BuildContent.LogTextWithoutTrace("allOptObjInformation", abatabSession, logMessage);
        }

        ////public static void Debug(string executingAssemblyName, string debugModuleMode, string debugModuleDir, string debugMsg, string fileExt = "debug")
        ////{
        ////    // NOTE For detailed logs.
        ////    Thread.Sleep(10);

        ////    var debugLogDir = $@"{debugModuleDir}\{DateTime.Now:yyMMdd}";
        ////    _=Directory.CreateDirectory($@"{debugModuleDir}\{DateTime.Now:yyMMdd}");

        ////    File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}.{fileExt}", debugMsg);
        ////}

        /// <summary>
        /// Basic debugging for a module.
        /// </summary>
        /// <param name="executingAssemblyName">Module name.</param>
        /// <param name="debugModuleDir">Directory to write the logfile.</param>
        /// <param name="logContents">Log contents (leave blank for low-level debugging).</param>
        public static void Debug(string executingAssemblyName, string debugMode, string debugLogRoot, string debugMsg = "", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            /* NOTE The advantage of debug logs is that they can be created prior to a SessionData object being created. You can put a LogEvent.Debug() call
             * anywhere in your code, and a logfile will be written. This is for development/debugging purposes, therefore the DebugMode setting in Web.config
             * should be set to "off" in your production environment.
             */

            bool debugDebugger = false;

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

        /// <summary>
        ///
        /// </summary>
        /// <param name="debugDebugger"></param>
        /// <param name="debugLogDir"></param>
        /// <param name="debugMsg"></param>
        private static void DebugDebugger(bool debugDebugger, string debugLogDir, string debugMsg)
        {
            if (debugDebugger)
            {
                Thread.Sleep(1000);

                File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}-Debugger[{debugMsg}].debug", debugMsg);
            }
        }


        /// <summary>
        /// Build a session information log.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void SessionData(SessionData abatabSession, string logMessage = "Session information log.")
        {
            var filePath   = $@"{abatabSession.SessionLogDir}\{DateTime.Now.ToString("HHmmss.fffffff")}.SessionData";
            var logContent = BuildContent.LogTextWithoutTrace("sessionInformation", abatabSession, logMessage);

            // NOTE For detailed logs.
            Thread.Sleep(10);

            File.WriteAllText(filePath, logContent);
        }

        /// <summary>
        /// Build a trace log.
        /// </summary>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void Trace(string executingAssemblyName, SessionData abatabSession, string logMessage = "Trace log.", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            var filePath   = $@"{abatabSession.SessionLogDir}\{DateTime.Now.ToString("HHmmss.fffffff")}-{executingAssemblyName}-{Path.GetFileName(callerFilePath)}-{callerMemberName}-{callerLine}.trace";

            var logContent = BuildContent.LogTextWithTrace("trace", executingAssemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);

            // NOTE For detailed logs.
            Thread.Sleep(10);

            File.WriteAllText(filePath, logContent);
        }

        /// <summary>
        /// Build a trace log.
        /// </summary>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void TraceDetails(string executingAssemblyName, SessionData abatabSession, string logMessage = "Trace log.", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            var filePath   = $@"{abatabSession.SessionLogDir}\{DateTime.Now.ToString("HHmmss.fffffff")}-{executingAssemblyName}-{Path.GetFileName(callerFilePath)}-{callerMemberName}-{callerLine}.trace";

            var logContent = BuildContent.LogTextWithTrace("trace", executingAssemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);

            // NOTE For detailed logs.
            Thread.Sleep(10);

            File.WriteAllText(filePath, logContent);

        }
    }
}