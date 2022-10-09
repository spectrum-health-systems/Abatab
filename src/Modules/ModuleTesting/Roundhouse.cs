/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * ModuleTesting.csproj                                                                             v0.91.0
 * Roundhouse.cs                                                                             b221009.083236
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/*
 */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleTesting
{
    public class Roundhouse
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        public static void ParseCommand(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabCommand)
            {
                case "datadump":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ParseDataDump(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            //return abatabSession;
        }

        /// <summary></summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static void ParseDataDump(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabAction)
            {
                case "sessiondata":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    AbatabOptionObject.Finalize.ForPassthrough(abatabSession);
                    DataDump.SessionData(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            // return abatabSession;
        }
    }
}