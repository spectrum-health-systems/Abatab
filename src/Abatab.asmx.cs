/*************************************************************************
 * Abatab v23.2.0-development+230226.1340
 * A custom web service/framework for Netsmart's myAvatar EHR.
 * https://github.com/spectrum-health-systems/Abatab
 ************************************************************************/

// Abatab.asmx.cs
// b230225.1749
// (c) A Pretty Cool Program

using System.Reflection;
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
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            AbSession abSession = new AbSession();
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            //WebConfig.Load(abSession);

            if (Settings.Default.AbatabMode == "enabled")
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                Flightpath.Starter(sentOptionObject, scriptParameter, abSession);

                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                Flightpath.Finisher(abSession);

                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                Core.DataExport.SessionInformation.ToSessionRoot(abSession);

                abSession.ReturnOptionObject.SetFieldValue("50004", "werwer");
                Core.DataExport.SessionInformation.ToSessionRoot(abSession);
                return abSession.ReturnOptionObject;
            }
            else
            {
                PrimevalLog.WriteLocal("disabled");

                return sentOptionObject.ToReturnOptionObject();
            }
        }
    }
}