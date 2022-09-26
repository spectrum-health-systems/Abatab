﻿/* Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 *
 * Abatab application information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AppData/AppInfo.md
 *
 * Abatab.csproj information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/ProjData/ProjInfo.md
 *
 * Abatab.asmx.cs information
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/ProjData/Sourcecode.md
 */

// b220926.160724

using AbatabLogging;
using AbatabRoundhouse;
using AbatabSession;

using NTST.ScriptLinkService.Objects;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>
        /// Return the Abatab version.
        /// </summary>
        /// <returns>Version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>
        /// Execute an Abatab request.
        /// </summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request to be executed.</param>
        /// <returns>OptionObject2015, which may have been modified.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            var abatabSession = Instance.Build(sentOptionObject, abatabRequest);
            LogEvent.AllEvents(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (abatabSession.AbatabMode)
            {
                case "enabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    Roundhouse.TestA();
                    break;

                case "disabled":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    Roundhouse.TestB();
                    break;

                case "passthrough":
                    LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
                    Roundhouse.TestC();
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            return abatabSession.FinalOptObj;
        }
    }
}
