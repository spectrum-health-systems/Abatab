/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.csproj v0.8.0
 * Abatab.asmx.cs b220928.093504
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatab.md
 * ===================================================================================================== */

using AbatabLogging;
using AbatabRoundhouse;
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
            var webConfigSettings = GetWebConfigSettings();
            var abatabSession     = Instance.Build(webConfigSettings, sentOptionObject, abatabRequest);

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            // TODO Need to verify if we need to assign this.
            abatabSession = Roundhouse.ParseRequest(abatabSession, abatabRequest);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession.FinalOptObj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetWebConfigSettings()
        {
            return new Dictionary<string, string>
            {
                { "AbatabMode" ,            Properties.Settings.Default.AbatabMode.ToLower() },
                { "LoggingMode",                Properties.Settings.Default.LoggingMode.ToLower() },
                { "AbatabRootDirectory",    Properties.Settings.Default.AbatabRootDirectory },
                { "AvatarFallbackUserName", Properties.Settings.Default.AvatarFallbackUserName },
            };
        }
    }
}
