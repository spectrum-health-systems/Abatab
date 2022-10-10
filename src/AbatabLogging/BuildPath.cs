/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildPath.cs                                                                              b221010.102030
 * --------------------------------------------------------------------------------------------------------
 * Builds the log file path.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

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
            //LogDebug.DebugContent(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating log components..");

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