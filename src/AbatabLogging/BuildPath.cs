using System;
using System.Reflection;

namespace AbatabLogging
{
    public class BuildPath
    {
        public static string FullPath(string eventType, string sessionLogDir, string executingAssemblyName = "", string callerFilePath = "", string callerMemberName = "", int callerLine = 0)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on");

            var fullPath = $@"{sessionLogDir}\{DateTime.Now:HHmmss.fffffff}";

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", "fullPath");

            if (!string.IsNullOrWhiteSpace(executingAssemblyName))
            {
                fullPath += $"-{executingAssemblyName}";
                LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", "fullPath");
            }

            if (!string.IsNullOrWhiteSpace(callerFilePath))
            {
                fullPath += $"-{callerFilePath}-{callerMemberName}-{callerLine}";
                LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", "fullPath");
            }

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", $"{fullPath}.{eventType}");

            return $"{fullPath}.{eventType}";
        }
    }
}
