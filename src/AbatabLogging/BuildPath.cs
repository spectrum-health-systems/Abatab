using System;
using System.IO;

namespace AbatabLogging
{
    public class BuildPath
    {
        public static string FullPath(string eventType, string sessionLogDir, string executingAssemblyName = "", string callerFilePath = "", string callerMemberName = "", int callerLine = 0)
        {
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on",  @"C:\AvatoolWebService\Abatab_UAT\logs\debug", "[DEBUG] Building logPath.");

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
