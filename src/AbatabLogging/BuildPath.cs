/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabLogging.csproj                                                                             v0.92.0
 * BuildPath.cs                                                                              b221010.115437
 * --------------------------------------------------------------------------------------------------------
 * Builds the log file path.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

/* Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates  logs results in strange behavior. For the most part, LogEvent.Trace() is replaced
 * with Debugger.BuildDebugLog(), although in some cases log files aren't written at all. This makes it a
 * little difficult to troubleshoot logging, which is why it's a good idea to test the logging funcionality
 * extensively prior to deploying to production.
 */

using System;
using System.IO;

namespace AbatabLogging
{
    public class BuildPath
    {

        /// <summary>Build log file path.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="sessionLogRoot"></param>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="callPath">Filename of where the log is coming from.</param>
        /// <param name="callMember">Method of where the log is coming from.</param>
        /// <param name="callLine">File line of where the log is coming from.</param>
        /// <returns>Log file path.</returns>
        public static string FullPath(string eventType, string sessionLogRoot, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            var fullPath = sessionLogRoot;

            if (eventType == "trace")
            {
                fullPath += $@"\{eventType}";
                AbatabSystem.Maintenance.VerifyDir(fullPath);
            }

            fullPath += $@"\{DateTime.Now:HHmmss.fffffff}";

            if (!string.IsNullOrWhiteSpace(exeAssembly))
            {
                fullPath += $"-{exeAssembly}";
            }

            if (!string.IsNullOrWhiteSpace(callPath))
            {
                fullPath += $"-{Path.GetFileName(callPath)}-{callMember}-{callLine}";
            }

            return $"{fullPath}.{eventType}";
        }
    }
}