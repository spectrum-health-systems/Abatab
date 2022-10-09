/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * Abatab.asmx.cs                                                                            b221009.090325
 * --------------------------------------------------------------------------------------------------------
 * Main entry point for Abatab.
 *
 * When a ScriptLink event is executed in Avatar, an OptionObject (the information/data from Avatar that
 * Abatab needs to do it's job) and script parameter (also referred to as the "Abatab request") are sent to
 * here.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using Abatab.Properties;
using AbatabData;
using AbatabLogging;
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
        /// <summary>Return Abatab version.</summary>
        /// <returns>Current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>Execute Abatab request.</summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request from Avatar.</param>
        /// <returns>Finalized OptionObject2015 that will be returned to Avatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            LogDebug.DebugContent(Settings.Default.DebugMode, "[DEBUG] Abatab started.", Settings.Default.DebugLogRoot, Assembly.GetExecutingAssembly().GetName().Name);
            LogDebug.DebugContent("on", sentOptionObject.OptionUserId, @"C:\AvatoolWebService\Abatab_UAT\logs\debug\test.debug", Assembly.GetExecutingAssembly().GetName().Name);
            SessionData abatabSession = AbatabSettings.BuildSettings(sentOptionObject, abatabRequest);

            Roundhouse.ParseRequest(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.SessionInformation(abatabSession, "Completed session information");

            return abatabSession.FinalOptObj;
        }
    }
}