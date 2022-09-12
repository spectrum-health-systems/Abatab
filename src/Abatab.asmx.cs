/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * v0.2.2-devbuild+220912.125400
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.asmx.cs: Entry point for MAWSC.
 * b220912.112513
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using Abatab.Logging;
using NTST.ScriptLinkService.Objects;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class Abatab : System.Web.Services.WebService
    {
        /// <summary>
        /// Return Abatab version.
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
            var executingAssembly = Assembly.GetExecutingAssembly().GetName().Name.ToLower();


            var abatabSession = Configuration.Settings.Build(sentOptionObject, abatabRequest);
            LogEvent.Trace(executingAssembly, abatabSession);
            LogEvent.SessionInformation(abatabSession);
            LogEvent.AllOptionObjectInformation(abatabSession);


            switch (abatabSession.AbatabMode)
            {
                case "enabled":
                    LogEvent.Trace(executingAssembly, abatabSession);
                    // Normal operation.
                    break;

                case "disabled":
                    LogEvent.Trace(executingAssembly, abatabSession);
                    // Don't do anything.
                    break;

                case "passthrough":
                    LogEvent.Trace(executingAssembly, abatabSession);
                    // Just create logs, don't make any changes to data.
                    break;

                default:
                    // Gracefully exit.
                    break;
            }

            return abatabSession.FinalOptObj;
        }
    }
}
