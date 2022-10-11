/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * Abatab.csproj                                                                                    v0.92.0
 * Abatab.asmx.cs                                                                            b221011.093856
 * --------------------------------------------------------------------------------------------------------
 * Entry point for Abatab.
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
        /// <returns>Version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>Execute Abatab request.</summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="scriptParameter">Request from Avatar.</param>
        /// <returns>Finalized OptionObject2015.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Session started.");
            // No LogEvent.Trace()

            SessionData abatabSession = AbatabSettings.Build(sentOptionObject, scriptParameter);

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
- Required
- More information: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method

RunScript()
-----------
01 Build required data for the current session
03 Parse the ScriptLink script parameter to determine where the OptionObject needs to be sent
04 Write the session details to a log file for reference
05 Return the final OptionObject to Avatar
- Entry point for Abatab.
- Required
- More information: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method

*/