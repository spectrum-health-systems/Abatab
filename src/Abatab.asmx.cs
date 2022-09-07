// Built using: https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service
//
// September 7, 2022

using NTST.ScriptLinkService.Objects;
using System.Web.Services;

namespace Abatab
{
    /// <summary>
    /// Summary description for Abatab
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class Abatab : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string action)
        {
            switch (action)
            {
                case "doSomething":
                    return MethodName(sentOptionObject);

                default:
                    break;
            }

            return sentOptionObject;
        }

        private static OptionObject2015 MethodName(OptionObject2015 sentOptionObject)
        {
            // You'll write the logic you need here.
            return new OptionObject2015();
        }
    }
}
