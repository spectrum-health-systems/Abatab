/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * DataDump.cs                                                                               b221008.180009
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/*
 */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleTesting
{
    public class DataDump
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        public static void SessionData(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            LogEvent.SessionInformation(abatabSession, "Testing data dump functionality.");
        }
    }
}
