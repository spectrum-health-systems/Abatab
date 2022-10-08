/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.Roundhouse.cs                                                                      b221008.094839
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Parses the Abatab request, and determines where is should go. Whenever a new module is added, the entire
 * solution will need to be rebuilt. Adding functionality to a module will not require Abatab to be
 * rebuilt, however, only the module that is modified.
 */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    public class Roundhouse
    {
        /// <summary>Determine which module should receive the request.</summary>
        /// <param name="abatabSession">Abatab session data.</param>
        /// <returns>Abatab session data, potentially modified.</returns>
        public static void ParseRequest(SessionData abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing request..");

            switch (abatabSession.AbatabModule)
            {
                case "date":
                    // TBD
                    break;

                case "dose":
                    // TBD
                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ModuleTesting.Roundhouse.ParseCommand(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }
        }
    }
}