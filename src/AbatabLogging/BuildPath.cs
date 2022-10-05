using System;

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

            return $"{fullPath}.{eventType}";
        }
    }
}
