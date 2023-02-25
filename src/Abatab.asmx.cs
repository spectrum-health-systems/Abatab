/* Abatab v23.2.0
 * Development build 230225.1749
 */

// Abatab.asmx.cs
// b230225.1749
// (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Web.Services;
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

            Dictionary<string, string> webConfigContent = WebConfig.Load();

            if (webConfigContent["AbatabMode"] == "enabled")
            {
                Flightpath.Starter(sentOptionObject, scriptParameter, webConfigContent);

                return sentOptionObject.ToReturnOptionObject();
            }
            else
            {
                PrimevalLog.WriteLocal("disabled");

                return sentOptionObject.ToReturnOptionObject();
            }
        }
    }
}