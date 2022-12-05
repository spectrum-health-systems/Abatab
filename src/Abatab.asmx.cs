// Abatab 22.12.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221205.1244

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
    /// The main Abatab project, and where the magic starts.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>
        /// Returns the current version of Abatab.
        /// </summary>
        /// <returns>The current version of Abatab.</returns>
        /// <remarks>
        /// * This method is required by Avatar.
        /// * The version number is always the version that is in development. For example, while developing v1.0, this will return <c>1.0</c>.
        /// </remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 22.11";
        }

        /// <summary>
        /// Executes script parameter request from Avatar, then returns a potentially modified OptionObject to Avatar.
        /// </summary>
        /// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The original Script Parameter request from Avatar.</param>
        /// <returns>A finalized OptionObject that will be returned to Avatar.</returns>
        /// <remarks>
        /// * This method is required by Avatar.
        /// * This is the only time a <see href="https://spectrum-health-systems.github.io/Abatab/man/man-logging-home.html#primeval-debug-log">Primeval debug log</see> is written.
        /// * This method should remain fairly static, since most of the logic is taken care of by external projects.
        /// </remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            LogEvent.PrimevalDebug(Settings.Default.DebugMode, Assembly.GetExecutingAssembly().GetName().Name, $@"{Settings.Default.AbatabDataRoot}\{Settings.Default.AvatarEnvironment}\{Settings.Default.DebugLogRoot}");

            Dictionary<string, string> webConfig = WebConfig.Load();

            Session abatabSession = Build.NewSession(sentOptionObject, scriptParameter, webConfig);

            Roundhouse.ParseRequest(abatabSession);

            LogEvent.Session(abatabSession, "Session complete.");

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            return abatabSession.FinalOptObj;
        }
    }
}