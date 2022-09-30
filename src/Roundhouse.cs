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
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    public class Roundhouse
    {
        public static SessionData Request(SessionData abatabSession, string abatabRequest)
        {
            Dictionary<string, string> requestComponent = ParseRequest(abatabRequest);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ParseRequest(string abatabRequest)
        {
            string[] requestComponents = abatabRequest.Split('-');

            foreach (var component in requestComponents)
            {
                if (string.IsNullOrWhiteSpace(component))
                {

                }
            }

            return new Dictionary<string, string>
            {
                { "Module",  requestComponents[0] },
                { "Command", requestComponents[1] },
                { "Action",  requestComponents[2] },
                { "Action",  requestComponents[3] }
            };
        }
    }
}