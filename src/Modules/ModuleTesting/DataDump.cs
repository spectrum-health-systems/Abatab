/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * DataDump.cs                                                                               b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/*
 */

using AbatabData;
using AbatabLogging;

namespace ModuleTesting
{
    public class DataDump
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        public static void SessionData(SessionData abatabSession)
        {
            LogEvent.SessionInformation(abatabSession);
        }
    }
}
