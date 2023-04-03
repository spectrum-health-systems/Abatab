/*************************************************************************
 * Abatab v23.3.0
 * A custom web service/framework for Netsmart's myAvatar EHR.
 * https://github.com/spectrum-health-systems/Abatab
 ************************************************************************/

// Development build 230403.0838

// Abatab.asmx.cs
// b---------x
// (c) A Pretty Cool Program

using System.Reflection;
using System.Web.Services;
using Abatab.Core.Catalog.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Entry point for Abatab.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Abatab.asmx.cs"]/GetVersion/*' />
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.3";
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Abatab.asmx.cs"]/RunScript/*' />
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            /* INFO: Debuggler statement here, since a Trace log won't work. Helpful for development.
             */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Flightpath.InitializeAbatab(abSession, scriptParameter, sentOptionObject);

                Roundhouse.ParseModule(abSession);

                Flightpath.WrapUpAbatab(abSession);
            }
            else
            {
                LogFile.Primeval("disabled");
            }

            return abSession.ReturnOptionObject;
        }
    }
}