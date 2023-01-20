// Abatab.AbatabLogging.Debuggler.cs b230119.0941
// Copyright (c) A Pretty Cool Program

/* ========================================================================================================
 * Logging is done a little differently in AbatabLogging classes, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

/* ========================================================================================================
 * Abatab debugging functionality should only be used for development/debugging. There is a hardcoded 100ms
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
 ========================================================================================================*/

namespace AbatabLogging
{
    /// <summary>Logic for debugging functionality.</summary>
    public static class Debuggler
    {
        /// <summary>Debugs the debugger.</summary>
        /// <param name="debugDebugger">The flag that determines if the debugger should be debugged.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="debugMsg">The debugger log message.</param>
        public static void DebugTheDebugger(bool debugDebugger, string debugLogRoot, string debugMsg)
        {
            if (debugDebugger)
            {
                var debugLogPath = BuildPath.Timestamped("debuggler", debugLogRoot);

                // It is recommended that you keep this at 0.
                WriteLogFile.LocalFile(debugLogPath, debugMsg, 0);
            }
        }
    }
}