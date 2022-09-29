/* ========================================================================================================
 * Abatab v0.90.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLogging v0.90.0
 * AbatabLogging.WriteFile.cs b220929.184306
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabLogging.md
 * ===================================================================================================== */


// NOTE Probably depreciated

using System.IO;

namespace AbatabLogging
{
    public class WriteFile
    {
        public static void ToLocalFile(string filePath, string logContent)
        {
            File.WriteAllText(filePath, logContent);
        }
    }
}
