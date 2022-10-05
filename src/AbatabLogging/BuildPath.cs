using System;
using System.Reflection;

namespace AbatabLogging
{
    public class BuildPath
    {
        public static string FullPath(string eventType, string sessionLogDir, string executingAssemblyName = "", string callerFilePath = "", string callerMemberName = "", int callerLine = 0)
        {
            var fullPath = $@"{sessionLogDir}\{DateTime.Now:HHmmss.fffffff}";

            if (!string.IsNullOrWhiteSpace(executingAssemblyName))
            {
                fullPath = $"{fullPath}-{executingAssemblyName}";
            }

            if (!string.IsNullOrWhiteSpace(callerFilePath))
            {
                fullPath = $"{fullPath}-{callerFilePath}-{callerMemberName}-{callerLine}";
            }

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", "${fullPath}.{eventType}");

            return $"{fullPath}.{eventType}";
        }
    }
}
