/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLogging v0.8.0
 * AbatabLogging.WriteFile.cs b220928.091558
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabLogging.md
 * ===================================================================================================== */

using System.IO;

namespace AbatabLogging
{
    public class WriteFile
    {
        public static void ToLocalFile(string logContent)
        {
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_Logs\log.txt", logContent);
        }
    }
}
