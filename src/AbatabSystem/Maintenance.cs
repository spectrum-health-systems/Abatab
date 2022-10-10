/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSystem.csproj                                                                              v0.91.0
 * Maintenance.cs                                                                            b221009.090325
 * --------------------------------------------------------------------------------------------------------
 * General maintenance logic
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using System.IO;

namespace AbatabSystem
{
    public class Maintenance
    {
        /// <summary>Verify directory exists, and create if not.</summary>
        public static void VerifyDir(string dir)
        {
            _=Directory.CreateDirectory(dir);
        }
    }
}