/* ========================================================================================================
 * Abatab v0.90.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.csproj v0.90.0
 * Abatab.Roundhouse.cs b220930.082025
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatab.md
 * ===================================================================================================== */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    public class Roundhouse
    {
        public static SessionData ParseRequest(SessionData abatabSession, string abatabRequest)
        {
            switch (abatabSession.AbatabMode)
            {
                case "enabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    break;

                case "disabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    break;

                case "passthrough":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    abatabSession = AbatabOptionObject.Finalize.ForPassthrough(abatabSession);
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            return abatabSession;
        }

    }
}