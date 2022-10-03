/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * BuildContent.cs                                                                           b221003.130759
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System;
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
            DebugModule();

            OptionObject2015 finalOptObj = DoIt(sentOptionObject, abatabRequest);

            return finalOptObj;
        }

        /// <summary>Debug logic for this module.</summary>
        private static void DebugModule()
        {
            if (string.Equals(Properties.Settings.Default.DebugMode, "on", StringComparison.OrdinalIgnoreCase))
            {
                LogEvent.DebugModule(Assembly.GetExecutingAssembly().GetName().Name, Properties.Settings.Default.DebugLogDir);
            }
        }

        /// <summary></summary>
        /// <param name="abatabSession"></param>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static OptionObject2015 DoIt(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            SessionData abatabSession = CreateNewSession(sentOptionObject, abatabRequest);

            // TODO Need to verify if we need to assign this.
            abatabSession = AbatabRoundhouse.Roundhouse.ParseRequest(abatabSession);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession.FinalOptObj;
        }

        /// <summary></summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static SessionData CreateNewSession(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            SessionData abatabSession = Instance.Build(sentOptionObject, abatabRequest);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }
    }
}