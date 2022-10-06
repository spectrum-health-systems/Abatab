/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.asmx.cs                                                                            b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Main entry point for Abatab. This should be pretty static, but if it is modified, it will require the
 * entire solution to be rebuilt.
 */

using Abatab.Properties;
using AbatabData;
using AbatabLogging;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;

namespace Abatab
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>Return Abatab version.</summary>
        /// <returns>Version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>Execute Abatab request.</summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request from Avatar.</param>
        /// <returns>Finalized OptionObject2015.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Abatab started.");

            Dictionary<string, string> abatabSettings = AbatabSettings.LoadFromWebConfig();

            SessionData abatabSession = Instance.Build(sentOptionObject, abatabRequest, abatabSettings);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            Roundhouse.ParseRequest(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            LogEvent.SessionInformation(abatabSession); // DEBUGING

            //return abatabSession.SentOptObj;
            return abatabSession.FinalOptObj;
        }
    }
}