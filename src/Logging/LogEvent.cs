/* ========================================================================================================
 * Abatab.Logging.LogEvent.cs: Logs an Abatab event.
 * b220912.112738
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using System.Runtime.CompilerServices;

namespace Abatab.Logging
{
    public class LogEvent
    {
        public static void Trace(string assemblyName, Session abatabSession, string logMessage = "No log message", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            BuildContent.Message("trace", assemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);
        }
    }
}