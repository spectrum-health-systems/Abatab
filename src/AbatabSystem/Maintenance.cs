/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabSystem.csproj                                                                              v0.92.0
 * Maintenance.cs                                                                            b221011.074325
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
            // No Debugger.BuildDebugLog() or LogEvent.Trace() here because it isn't worth it...yet.

            _=Directory.CreateDirectory(dir);
        }
    }
}