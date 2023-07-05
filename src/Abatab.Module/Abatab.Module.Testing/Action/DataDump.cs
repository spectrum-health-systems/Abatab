// b230516.0855

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    internal class DataDump
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.Testing.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestAction)
            {
                case "sessioninformation":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    //Core.DataExport.SessionInformation.ToSessionRoot(abSession); // ALREADY DONE?

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    abSession.ReturnOptionObject.ToReturnOptionObject();
                    //abSession.ReturnOptionObject.ErrorCode = 1;
                    //abSession.ReturnOptionObject.ErrorMesg = "Hi!";

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    //Core.DataExport.SessionInformation.ToSessionRoot(abSession);

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    //Abatab.Core.DataExport.

                    //LogEvent.SessionDetails(sessionDetail);
                    //? session.FinalOptionObject = session.SentOptionObject.ToReturnOptionObject();
                    //? AbatabOptionObject.FinalObj.Finalize(sessionDetail);
                    //DataDump.SessionData(session);

                    break;

                default:

                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO - Exit gracefully.

                    break;
            }
        }
    }
}