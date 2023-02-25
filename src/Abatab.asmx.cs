/* Abatab v23.2.0
 * Development build b230225.1136
 */

// Abatab.asmx.cs
// b230224.1700
// (c) A Pretty Cool Program

using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Services;
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
            /* For debugging only! Leave commented out in production environments!
             */
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);

            File.WriteAllText($@"C:\AbatabData\Debuggler\{DateTime.Now:HHmmss_fffffff}.debuggler", scriptParameter);


            Dictionary<string, string> webConfigContent = WebConfig.Load();

            if (webConfigContent["AbatabMode"] == "enabled")
            {
                Flightpath.Starter(sentOptionObject, scriptParameter, webConfigContent);

                return sentOptionObject.ToReturnOptionObject();
            }
            else
            {
                // TODO - Write a session log here.

                return sentOptionObject.ToReturnOptionObject();
            }
        }
    }
}