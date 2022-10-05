/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * BuildContent.cs                                                                           b221005.134422
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

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
        /// <summary>Return the Abatab version.</summary>
        /// <returns>Version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>Execute an Abatab request.</summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request from Avatar.</param>
        /// <returns>OptionObject2015, which may have been modified.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            // Only used in development.
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "Abatab started.");

            Dictionary<string, string> abatabSettings = AbatabSettings.LoadFromWebConfig();

            SessionData abatabSession = Instance.Build(sentOptionObject, abatabRequest, abatabSettings);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            Roundhouse.ParseRequest(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            return abatabSession.FinalOptObj;
        }
    }
}