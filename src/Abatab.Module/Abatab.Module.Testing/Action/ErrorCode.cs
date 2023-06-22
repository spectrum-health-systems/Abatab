// b230516.0855

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    /// <summary>Summary goes here.</summary>
    public class ErrorCode
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.Testing.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestAction)
            {
                case "errorcode1":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    abSession.ReturnOptionObject.SetFieldValue("50004", "T102");
                    abSession.ReturnOptionObject.SetFieldValue("10750", "TEST 230301.1147");
                    abSession.ReturnOptionObject.ToReturnOptionObject(4, "Testing Error Code 1");

                    //abSession.ReturnOptionObject.ErrorCode = 1;
                    //abSession.ReturnOptionObject.ErrorMesg = "Testing: Error Code 1";

                    break;

                default:

                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO - Exit gracefully.

                    break;
            }
        }

    }
}
