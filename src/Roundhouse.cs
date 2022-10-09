/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.Roundhouse.cs                                                                      b221009.083236
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Parses the Abatab request, and determines where is should go. Whenever a new module is added, the entire
 * solution will need to be rebuilt. Adding functionality to a module will not require Abatab to be
 * rebuilt, however, only the module that is modified.
 */

using Abatab.Properties;
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
            LogDebug.DebugContent(Settings.Default.DebugMode, "[DEBUG] Parsing request.", Settings.Default.DebugLogRoot, Assembly.GetExecutingAssembly().GetName().Name);

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