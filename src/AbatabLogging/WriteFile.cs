/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * WriteFile.cs                                                                              b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

// NOTE Probably depreciated

using System.IO;
using System.Threading;

namespace AbatabLogging
{
    public class WriteFile
    {
        public static void LocalFile(string logPath, string logContent, int loggingDelay)
        {
            Thread.Sleep(loggingDelay);

            File.WriteAllText(logPath, logContent);
        }
    }
}
