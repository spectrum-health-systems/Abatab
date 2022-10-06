/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildPath.cs                                                                              b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Builds the log file path.
 */

using System;
using System.IO;
using System.Reflection;

namespace AbatabLogging
{
    public class BuildPath
    {

        /// <summary></summary>
        /// <param name="eventType"></param>
        /// <param name="sessionLogDir"></param>
        /// <param name="executingAssemblyName"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        public static string FullPath(string eventType, string sessionLogDir, string executingAssemblyName = "", string callerFilePath = "", string callerMemberName = "", int callerLine = 0)
        {
            // debugMode and debugLogPath are hardcoded here, since they don't exist.
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", "[DEBUG] Building logPath.");

            var fullPath = $@"{sessionLogDir}\{DateTime.Now:HHmmss.fffffff}";

            if (!string.IsNullOrWhiteSpace(executingAssemblyName))
            {
                fullPath += $"-{executingAssemblyName}";
            }

            if (!string.IsNullOrWhiteSpace(callerFilePath))
            {
                fullPath += $"-{Path.GetFileName(callerFilePath)}-{callerMemberName}-{callerLine}";
            }

            return $"{fullPath}.{eventType}";
        }
    }
}