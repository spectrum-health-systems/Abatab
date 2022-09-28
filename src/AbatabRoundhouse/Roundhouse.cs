/* ========================================================================================================
 * Abatab v0.6.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabRoundhouse v0.6.0
 * AbatabRoundhouse.Roundhouse.cs b220928.091558
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabRoundhouse.md
 * ===================================================================================================== */
using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabRoundhouse
{
    public class Roundhouse
    {
        public static void ParseRequest(SessionData abatabSession, string abatabRequest)
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
                    break;

                default:
                    // Gracefully exit.
                    break;
            }
        }

        public static void TestB()
        {

        }

        public static void TestC()
        {

        }
    }
}
