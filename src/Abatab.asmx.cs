// Abatab v23.2.0-development+230217.0818
// Abatab.asmx.cs b230123.0832
// (c) A Pretty Cool Program

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
    /// <summary>The entry point for Abatab.</summary>
    /// <remarks>
    /// Abatab receives two things from Avatar:
    /// <list type="number">
    /// <item>An <see href="../man/manAppendix.html#optionobject">OptionObject</see>, which contains all of the information that Abatab needs to do it's thing.</item>
    /// <item>A <see href="../man/manAppendix.html#script-paramater">Script Parameter</see> that tells Abatab what it needs to do with the OptionObject.</item>
    /// </list>
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>Returns the current version of Abatab.</summary>
        /// <returns>The current version of Abatab.</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item>This method is required by Avatar.</item>
        /// <item>The version number is always the version that is in development.</item>
        /// </list>
        /// </remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.2";
        }

        /// <summary>Executes script parameter request from Avatar, then returns a potentially modified OptionObject to Avatar.</summary>
        /// <param name="sentOptionObject">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The original Script Parameter request from Avatar.</param>
        /// <returns>A finalized OptionObject that will be returned to Avatar.</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item>This method is required by Avatar.</item>
        /// <item>This is the only time a <see href="../man/manAppendix.html#logging">Primeval debug log</see> is written.</item>
        /// </list>
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