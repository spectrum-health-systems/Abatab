using System.Collections.Generic;
using System.Reflection;
using Abatab.Core.Catalog;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContent)
        {
            if (webConfigContent["DebugglerMode"] == "enabled") /* For testing/debugging only */
            {
                LogEvent.Debuggler($@"C:\AbatabData\Debuggler\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);
            }

            SessionProperties sessionProperties = Build.NewSession(sentOptionObject, scriptParameter, webConfigContent);

            Roundhouse.ParseModule(sessionProperties);
        }
    }
}