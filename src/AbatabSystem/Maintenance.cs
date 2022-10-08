/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSystem.csproj                                                                              v0.91.0
 * Class1.cs                                                                                 b221008.094839
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/*
 */

using System.IO;

namespace AbatabSystem
{
    public class Maintenance
    {
        /// <summary>Verify directory exists, and create if not.</summary>
        public static void VerifyDir(string dir)
        {
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\debug\MAINTENANCE.debug", dir);

            _=Directory.CreateDirectory(dir);
        }
    }
}