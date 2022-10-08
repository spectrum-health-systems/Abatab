/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * Debugger.cs                                                                               b221008.094839
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Logic for debugging logs.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AbatabLogging
{
    public class LogDebug
    {
        /// <summary>Basic debugging for a module.</summary>
        /// <param name="executingAssemblyName"></param>
        /// <param name="debugMode"></param>
        /// <param name="debugLogRoot"></param>
        /// <param name="debugMsg"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        public static void Debugger(string executingAssemblyName, string debugMode, string debugLogRoot = "", string debugMsg = "", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            /* NOTE The advantage of debug logs is that they can be created prior to a SessionData object being created. You can put a LogDebug.Debug() call
             * anywhere in your code, and a logfile will be written. This is for development/debugging purposes, therefore the DebugMode setting in Web.config
             * should be set to "off" in your production environment.
             */

            if (debugMode == "on" || debugMode == "undefined")
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

    }
}
