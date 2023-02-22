// Abatab v23.2.0-development+230222.1611
// Abatab.asmx.cs bxxxxxx.xxxx
// (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Web.Services;
using AbatabLogger;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Abatab: A custom web service for myAvatar.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <summary>Returns the current version of Abatab.</summary>
        /// <returns>The current version of Abatab.</returns>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This method is required by Avatar.</item>
        ///         <item>The version number is always the version that is in development.</item>
        ///     </list>
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
        ///     <list type="bullet">
        ///         <item>This method is required by Avatar.</item>
        ///     </list>
        /// </remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            LogEvent.Primeval(@"C:\AbatabData\primeval.log", $"Script Parameter: {scriptParameter}");

            Dictionary<string, string> webConfig = WebConfig.Load();

            //if (webConfig["AbatabMode"] == "enabled")
            //{
            Flightpath.Starter(sentOptionObject, scriptParameter, webConfig);
            LogEvent.Primeval(@"C:\AbatabData\primeval.log1", $"Script Parameter: {scriptParameter}");
            return sentOptionObject.ToReturnOptionObject();
            //}
            //else
            //{
            //    LogEvent.Primeval(@"C:\AbatabData\primeval.log12", $"Script Parameter: {scriptParameter}");

            //    return sentOptionObject.ToReturnOptionObject();
            //}


        }
    }
}