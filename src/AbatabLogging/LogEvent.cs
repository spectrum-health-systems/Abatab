/* ========================================================================================================
 * Abatab v0.90.1
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLogging v0.90.1
 * AbatabLogging.LogEvent.cs b221003.075515
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabLogging.md
 * ===================================================================================================== */

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

        public static void Debug(string executingAssemblyName, string debugModuleMode, string debugModuleDir, string debugMsg, string fileExt = "debug")
        {
            // NOTE For detailed logs.
            Thread.Sleep(10);

            var debugLogDir = $@"{debugModuleDir}\{DateTime.Now:yyMMdd}";
            _=Directory.CreateDirectory($@"{debugModuleDir}\{DateTime.Now:yyMMdd}");

            File.WriteAllText($@"{debugLogDir}\{DateTime.Now:fffffff}.{fileExt}", debugMsg);
        }

        /// <summary>Write a debug logfile.</summary>
        public static void DebugModule(string executingAssemblyName, string debugModuleMode, string debugModuleDir, string debugMsg)
        {
            // NOTE For debugging purposes only! By default DebugMode in Web.config should be set to "off".

            // NOTE For detailed logs.
            Thread.Sleep(10);

            if (string.Equals(debugModuleMode, "on", StringComparison.OrdinalIgnoreCase))
            {
                var debugLogDir = $@"{debugModuleDir}\{DateTime.Now:yyMMdd}";
                _=Directory.CreateDirectory(debugLogDir);

                File.WriteAllText($@"{debugLogDir}\{DateTime.Now.ToString("HHmmss.fffffff")}.{executingAssemblyName}", debugMsg);
            }
        }

        /// <summary>
        /// Build a session information log.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void SessionData(SessionData abatabSession, string logMessage = "Session information log.")
        {
            BuildContent.LogTextWithoutTrace("sessionInformation", abatabSession, logMessage);
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
            var filePath   = $@"{abatabSession.SessionLogDirectory}\{DateTime.Now.ToString("HHmmss.fffffff")}-{executingAssemblyName}-{Path.GetFileName(callerFilePath)}-{callerMemberName}-{callerLine}.trace";
            var logContent = BuildContent.LogTextWithTrace("trace", executingAssemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);

            // NOTE For detailed logs.
            Thread.Sleep(10);

            File.WriteAllText(filePath, logContent);
        }


    }
}