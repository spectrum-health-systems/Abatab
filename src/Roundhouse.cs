/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.Roundhouse.cs                                                                      b221009.144127
 * --------------------------------------------------------------------------------------------------------
 * When a ScriptLink event is executed in Avatar, an OptionObject (the information/data from Avatar that
 * Abatab needs to do it's job) and script parameter (also referred to as the "Abatab request") are sent to
 * Abatab. This class parses the request, and determines where the OptionObject should go for further work.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

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
            LogDebug.Debugger(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing request..");

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