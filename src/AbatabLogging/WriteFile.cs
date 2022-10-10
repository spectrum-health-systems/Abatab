/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabLogging.csproj                                                                             v0.92.0
 * WriteFile.cs                                                                              b221010.124123
 * --------------------------------------------------------------------------------------------------------
 * Write a log files.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using System.IO;
using System.Threading;

namespace AbatabLogging
{
    public class WriteFile
    {
        /// <summary>Write a log file.</summary>
        /// <param name="logPath">Log file path.</param>
        /// <param name="logContent">Log file content.</param>
        /// <param name="loggingDelay">Log file delay.</param>
        public static void LocalFile(string logPath, string logContent, int loggingDelay)
        {
            Thread.Sleep(loggingDelay);

            File.WriteAllText(logPath, logContent);
        }
    }
}