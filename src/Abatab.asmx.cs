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
using System.IO;
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
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\46.txt", "none");

            var webConfigSettings = GetWebConfigSettings();

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\50.txt", "none");
            var abatabSession     = Instance.Build(webConfigSettings, sentOptionObject, abatabRequest);

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\53.txt", "none");
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\556.txt", "none");
            // TODO Need to verify if we need to assign this.
            abatabSession = Roundhouse.ParseRequest(abatabSession, abatabRequest);
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\58.txt", "none");
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
