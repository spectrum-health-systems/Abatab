// Abatab 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221212.0810

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
    /// <remarks>
    /// <para>
    /// Abatab receives two things from Avatar:
    /// <br/>
    /// 1. An <c>OptionObject</c>, which contains all of the information that Abatab needs to do it's thing<br/>
    /// 2. A <c>Script Parameter</c> that tells Abatab what it needs to do with the OptionObject.
    /// </para>
    /// <para>
    /// For more information about <see href="../man/manGlossary.html#optionobject">OptionObjects</see> and <see href="../man/manGlossary.html#script-paramater">Script Parameters</see>, please see the <see href="../man/index.html">Abatab Manual.</see>
    /// </para>
    /// </remarks>
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
        /// * The version number is always the version that is in development. For example, while developing
        ///   v1.0, this will return <c>1.0</c>.
        /// </remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.0";
        }

        /// <summary>
        /// Executes script parameter request from Avatar, then returns a potentially modified OptionObject to Avatar.
        /// </summary>
        /// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The original Script Parameter request from Avatar.</param>
        /// <returns>A finalized OptionObject that will be returned to Avatar.</returns>
        /// <remarks>
        /// * This method is required by Avatar.
        /// * This is the only time a <see href="../man/manGlossary.html#primeval-debug-log">Primeval debug log</see> is written.
        /// </remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            LogEvent.PrimevalDebug(Settings.Default.DebugMode, Assembly.GetExecutingAssembly().GetName().Name, $@"{Settings.Default.AbatabDataRoot}\{Settings.Default.AvatarEnvironment}\logs");

            Dictionary<string, string> webConfig = WebConfig.Load();

            Session abatabSession = Build.NewSession(sentOptionObject, scriptParameter, webConfig);

            Roundhouse.ParseRequest(abatabSession);

            LogEvent.Session(abatabSession, "Session complete.");

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            return abatabSession.FinalOptObj;
        }
    }
}