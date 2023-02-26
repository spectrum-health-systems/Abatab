/*************************************************************************
 * Abatab v23.2.0-development+230226.1340
 * A custom web service/framework for Netsmart's myAvatar EHR.
 * https://github.com/spectrum-health-systems/Abatab
 ************************************************************************/

// Abatab.asmx.cs
// b230225.1749
// (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utilities;
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
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);

            AbSession abSession = new AbSession();

            Dictionary<string, string> webConfigContent = WebConfig.Load();

            if (webConfigContent["AbatabMode"] == "enabled")
            {
                Flightpath.Starter(sentOptionObject, scriptParameter, abSession, webConfigContent);
                LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                Core.DataExport.SessionInformation.ToSessionRoot(abSession);
                sentOptionObject.SetFieldValue("50004", "T102");
                Core.DataExport.SessionInformation.ToSessionRoot(abSession);

                return sentOptionObject;
            }
            else
            {
                PrimevalLog.WriteLocal("disabled");

                return sentOptionObject.ToReturnOptionObject();
            }
        }
    }
}