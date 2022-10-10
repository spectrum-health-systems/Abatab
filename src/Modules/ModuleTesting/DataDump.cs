/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * DataDump.cs                                                                               b221010.115103
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleTesting
{
    public class DataDump
    {
        /// <summary>Do a data dump.</summary>
        /// <param name="abatabSession">Abatab session settings.</param>
        public static void SessionData(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.Session(abatabSession, "Testing data dump functionality.");
        }
    }
}
