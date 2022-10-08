/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildPath.cs                                                                              b221008.094839
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Builds the log file path.
 */

using System;
using System.Collections.Generic;
using System.IO;

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
            var fullPath = sessionLogDir;

            var subDirTypes = new List<string>
            {
                "trace"
            };

            if (eventType == "trace")
            {
                fullPath += $@"\{eventType}";
                AbatabSystem.Maintenance.VerifyDir(fullPath);
            }

            fullPath += $@"\{DateTime.Now:HHmmss.fffffff}";

            //if (subDirTypes.Any(eventType.Contains))
            //{
            //    fullPath += $@"\{eventType}\{DateTime.Now:HHmmss.fffffff}";
            //}
            //else
            //{
            //    fullPath += $@"\{DateTime.Now:HHmmss.fffffff}";
            //}

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