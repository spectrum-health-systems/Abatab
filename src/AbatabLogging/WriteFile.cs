/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.90.2
 * AbatabLogging.csproj                                                                             v0.90.2
 * WriteFile.cs                                                                              b221003.113616
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
