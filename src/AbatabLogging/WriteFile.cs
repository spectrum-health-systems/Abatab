/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * WriteFile.cs                                                                              b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

// NOTE Probably depreciated

using System.IO;

namespace AbatabLogging
{
    public class WriteFile
    {
        public static void ToLocalFile(string filePath, string logContent = "")
        {
            File.WriteAllText(filePath, logContent);
        }
    }
}
