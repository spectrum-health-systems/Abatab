// b230516.0855

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing
{
    /// <summary>Summary goes here.</summary>
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.Testing.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseCommand(AbSession abSession)
        {
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name); /* For development/troubleshooting only. */

            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "datadump":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.DataDump.ParseAction(abSession);

                    break;

                case "errorcode":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.ErrorCode.ParseAction(abSession);

                    break;

                case "sendemail":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.Messaging.SendEmail(abSession);

                    //Action.Messaging.ParseAction(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO - Exit gracefully.

                    break;
            }
        }
    }
}