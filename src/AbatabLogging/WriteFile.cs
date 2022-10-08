/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * WriteFile.cs                                                                              b221008.180009
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Write log data to a file.
 */

using System.IO;
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

            File.WriteAllText(logPath, logContent);
        }
    }
}