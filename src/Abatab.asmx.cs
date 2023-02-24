using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;
using Abatab.Core.Logger;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 23.2";
        }

        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            /* For testing/debugging only */
            LogEvent.Debuggler($@"C:\AbatabData\Debuggler\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);

            Dictionary<string, string> webConfigContent = WebConfig.Load();

            if (webConfigContent["AbatabMode"] == "enabled")
            {
                if (webConfigContent["DebugglerMode"] == "enabled") /* For testing/debugging only */
                {
                    LogEvent.Debuggler($@"C:\AbatabData\Debuggler\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);
                }

                Flightpath.Starter(sentOptionObject, scriptParameter, webConfigContent);

                return sentOptionObject.ToReturnOptionObject();
            }
            else
            {
                if (webConfigContent["DebugglerMode"] == "enabled") /* For testing/debugging only */
                {
                    LogEvent.Debuggler($@"C:\AbatabData\Debuggler\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);
                }

                return sentOptionObject.ToReturnOptionObject();
            }
        }
    }
}
