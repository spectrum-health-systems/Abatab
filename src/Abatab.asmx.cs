/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * BuildContent.cs                                                                           b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
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
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, "on", @"C:\AvatoolWebService\Abatab_UAT\logs\debug", $"1:{Settings.Default.DebugMode}-{Settings.Default.DebugLogRoot}");
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot);

            Dictionary< string, string> abatabSettings = AbatabSettings.LoadFromWebConfig();
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot);

            SessionData abatabSession = Instance.Build(sentOptionObject, abatabRequest, abatabSettings);
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot);

            //Roundhouse.ParseRequest(abatabSession); // TODO Need to verify if we need to assign this.

            //return abatabSession.FinalOptObj;
            return sentOptionObject;
        }
    }
}