/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * Abatab.csproj                                                                                    v0.92.0
 * Abatab.asmx.cs                                                                            b221011.093856
 * --------------------------------------------------------------------------------------------------------
 * The entry point for Abatab.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

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
        /// <summary>
        /// Returns the current version of Abatab.
        /// </summary>
        /// <returns>The current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>
        /// Executes script parameter request from Avatar, then returns a potentially modified OptionObject to Avatar. abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz
        /// </summary>
        /// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>A finalized OptionObject.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Session started.");

            Dictionary<string, string> webConfig = WebConfig.Load();

            SessionData abatabSession = Instance.Build(sentOptionObject, scriptParameter, webConfig);

            Roundhouse.ParseRequest(abatabSession);

            LogEvent.Session(abatabSession, "Session complete.");

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            return abatabSession.FinalOptObj;
        }
    }
}

/*

=================
DEVELOPMENT NOTES
=================

GetVersion()
------------
01 Returns the Abatab version
- Required method
- More information: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method

RunScript()
-----------
01 Build required data for the current session
03 Parse the ScriptLink script parameter to determine where the OptionObject needs to be sent
04 Write the session details to a log file for reference
05 Return the final OptionObject to Avatar
- Required method
- Entry point for Abatab
- LogEvent.Trace() is not used
- More information: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method

*/