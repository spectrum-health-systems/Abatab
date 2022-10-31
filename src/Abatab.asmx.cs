// Abatab 0.95.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221031.163946

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
    /// <summary>
    /// The entry point for Abatab.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>
        /// Returns the current version of Abatab.
        /// </summary>
        /// <remarks>
        /// This method is required by Avatar.
        /// </remarks>
        /// <returns>The current version of Abatab.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>
        /// Executes script parameter request from Avatar, then returns a potentially modified OptionObject to Avatar.
        /// </summary>
        /// <remarks>
        /// This method is required by Avatar.
        /// </remarks>
        /// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The original Script Parameter request from Avatar.</param>
        /// <returns>A finalized OptionObject.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            LogEvent.PrimevalDebug(Settings.Default.DebugMode, Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugLogRoot);

            Dictionary<string, string> webConfig = WebConfig.Load();

            Session abatabSession = Build.NewSession(sentOptionObject, scriptParameter, webConfig);

            Roundhouse.ParseRequest(abatabSession);

            LogEvent.Session(abatabSession, "Session complete.");

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            return abatabSession.FinalOptObj;
        }
    }
}