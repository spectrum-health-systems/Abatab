/*************************************************************************
 * Abatab v23.2.0-development+230228.0832
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
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.2";
        }

        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            AbSession abSession = new AbSession();

            if (Settings.Default.AbatabMode == "enabled")
            {
                Flightpath.Starter(sentOptionObject, scriptParameter, abSession);

                Flightpath.Finisher(abSession);
            }
            else
            {
                PrimevalLog.WriteLocal("disabled");
            }

            return abSession.ReturnOptionObject.ToReturnOptionObject();
        }
    }
}