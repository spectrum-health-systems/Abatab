/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * LogDebug.cs                                                                               b221009.144127
 * --------------------------------------------------------------------------------------------------------
 * Build and write a debug log file.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

/* Abatab debugging functionality should only be used for development/debugging. There is a hardcoded 100ms
 * delay when writing a debug log file, and there for should not be used production environments due to
 * the performance penalties it creates.
 *
 * The "DebugMode" setting in Web.config should be set to "off" unless you are debugging the Abatab source
 * code. Debug logs will only be written if DebugMode is set to "on".
 *
 * The advantage of debug logs is that you can create them at any time, even prior to the creation of a
 * SessionData object. All you need to do is add the following line anywhere in your code:
 *
 *      LogDebug.Debug()
 *
 * This will create a basic debug log file in the following hardcoded location:
 *
 *      C:\AvatoolWebService\Abatab_UAT\logs\debug\%yyMMdd%\%HHmmssfffffff%-%executingAssembly%-%callerPath%}-%callerMember%-%callerLine%.debug"
 *
 * You can also debug the debugger by setting "debugDebugger" to "true" in LogDebug.DebugContent(), which
 * will create additional debug files to aid in troubleshooting. These files have an additional hardcoded
 * 1000ms delay when they are written, and will cause significant performance issues when Abatab executes.
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
        /// <param name="debugMode"></param>
        /// <param name="debugMsg"></param>
        /// <param name="debugLogRoot"></param>
        /// <param name="exeAssembly"></param>
        /// <param name="callPath"></param>
        /// <param name="callMember"></param>
        /// <param name="callLine"></param>
        public static void Debugger(string debugMode, string debugMsg = "", string debugLogRoot = "", string exeAssembly = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {

            //if (debugMode == "on" || debugMode == "undefined")
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

                    var debugContent = BuildContent.Debug(exeAssembly, debugMode, debugMsg, callPath, callMember, callLine);

                    DebugDebugger(debugDebugger, debugLogDir, "004");

                    File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debug", debugContent);

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
