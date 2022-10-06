/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * WriteFile.cs                                                                              b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Write log data to a file.
 */

using System.IO;
using System.Reflection;
using System.Threading;

namespace AbatabLogging
{
    public class WriteFile
    {
        /// <summary></summary>
        /// <param name="logPath"></param>
        /// <param name="logContent"></param>
        /// <param name="loggingDelay"></param>
        public static void LocalFile(string logPath, string logContent, int loggingDelay)
        {
            Thread.Sleep(loggingDelay);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", $"{logPath}");
            File.WriteAllText(logPath, logContent);
        }
    }
}