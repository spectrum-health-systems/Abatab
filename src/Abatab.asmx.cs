/*************************************************************************
 * Abatab v23.2.0-development+230301.1048
 * A custom web service/framework for Netsmart's myAvatar EHR.
 * https://github.com/spectrum-health-systems/Abatab
 ************************************************************************/

// Abatab.asmx.cs
// b---------x
// (c) A Pretty Cool Program

using System.Web.Services;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utilities;
using Abatab.Properties;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>The entry point for Abatab.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <include file='Documentation/Abatab.xmldoc' path='XMLDoc/Class[@name="Abatab.asmx.cs"]/GetVersion/*' />
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.2";
        }

        /// <include file='Documentation/Abatab.xmldoc' path='XMLDoc/Class[@name="Abatab.asmx.cs"]/RunScript/*' />
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Flightpath.StartAbatab(sentOptionObject, scriptParameter, abSession);

                Flightpath.FinishAbatab(abSession);
            }
            else
            {
                PrimevalLog.WriteLocal("disabled");
            }

            return abSession.ReturnOptionObject;
        }
    }
}