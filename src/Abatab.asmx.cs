/* ========================================================================================================
 * Abatab v0.90.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.csproj v0.90.0
 * Abatab.asmx.cs b220930.082025
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatab.md
 * ===================================================================================================== */

using AbatabLogging;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System;
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
            DebugLog("Abatab started.");

            var abatabSession = Instance.Build(sentOptionObject, abatabRequest);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            // TODO Need to verify if we need to assign this.
            abatabSession = Roundhouse.ParseRequest(abatabSession, abatabRequest);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession.FinalOptObj;
        }

        /// <summary>
        /// Write a debug logfile.
        /// </summary>
        private static void DebugLog(string msg)
        {
            // NOTE For debugging purposes only! By default DebugMode in Web.config should be set to "off".

            if (Properties.Settings.Default.DebugMode == "on")
            {
                var debugLogDir = $@"{Properties.Settings.Default.DebugLogDir}\{DateTime.Now:yyMMdd}";
                _=Directory.CreateDirectory(debugLogDir);

                File.WriteAllText($@"{debugLogDir}\{DateTime.Now.ToString("HHmmss.fffffff")}.start", msg);
            }
        }
    }
}