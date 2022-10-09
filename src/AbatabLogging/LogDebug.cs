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
        /// <summary>Basic debugging.</summary>
        /// <param name="debugMode">Debug log mode.</param>
        /// <param name="debugMsg">Debug log message.</param>
        /// <param name="debugLogRoot">Debug log root directory.</param>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="callPath">Filename of where the log is coming from.</param>
        /// <param name="callMember">Method of where the log is coming from.</param>
        /// <param name="callLine">File line of where the log is coming from.</param>
        public static void Debugger(string debugMode, string debugMsg = "", string debugLogRoot = "", string exeAssembly = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {

            //if (debugMode == "on" || debugMode == "undefined")
            if (debugMode == "on")
            {
                const bool debugDebugger = false;

                DebugTheDebugger(debugDebugger, debugLogRoot, "Setting debugLogRoot.");

                if (string.IsNullOrWhiteSpace(debugLogRoot))
                {
                    debugLogRoot = @"C:\AvatoolWebService\Abatab_UAT\logs\debug";
                }

                DebugTheDebugger(debugDebugger, debugLogRoot, "Creating debugLogRoot.");

                var debugLogDir = $@"{debugLogRoot}\{DateTime.Now:yyMMdd}"; // TODO Move this to where other dirs are created.
                _=Directory.CreateDirectory(debugLogDir);

                DebugTheDebugger(debugDebugger, debugLogRoot, "Entering loop.");

                if (string.Equals(debugMode, "on", StringComparison.OrdinalIgnoreCase))
                {
                    DebugTheDebugger(debugDebugger, debugLogRoot, "Sleeping 100ms");

                    /* Delay creating a debug log by 100ms, just to make sure we don't overwrite an
                     * existing log. This will have a negative affect on performance.
                     */
                    Thread.Sleep(100);

                    DebugTheDebugger(debugDebugger, debugLogRoot, "Building debug log content.");

                    var debugContent = BuildContent.Debug(exeAssembly, debugMode, debugMsg, callPath, callMember, callLine);

                    DebugTheDebugger(debugDebugger, debugLogRoot, "Writing debug log content to file.");

                    File.WriteAllText($@"{debugLogDir}\{DateTime.Now:HHmmssfffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debug", debugContent);

                    DebugTheDebugger(debugDebugger, debugLogRoot, "Debug log content written.");
                }

                DebugTheDebugger(debugDebugger, debugLogRoot, "Exited loop.");
            }
        }

        /// <summary>Debug the debugger.</summary>
        /// <param name="debugDebugger">Flag that determines if the debugger should be debugged.</param>
        /// <param name="debugLogRoot">Debug log root directory.</param>
        /// <param name="debugDebuggerMsg">Debugger log message.</param>
        private static void DebugTheDebugger(bool debugDebugger, string debugLogRoot, string debugDebuggerMsg)
        {
            if (debugDebugger)
            {
                /* Delay creating a debug log by 1000ms, just to make sure we don't overwrite an
                 * existing log. This will have a significant negative affect on performance.
                 */
                Thread.Sleep(1000);

                File.WriteAllText($@"{debugLogRoot}\{DateTime.Now:HHmmssfffffff}-Debugger[{debugDebuggerMsg}].debug", debugDebuggerMsg);
            }
        }
    }
}
