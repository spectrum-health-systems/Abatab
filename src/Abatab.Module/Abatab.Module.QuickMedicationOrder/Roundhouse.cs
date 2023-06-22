// b230516.0855

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.QuickMedicationOrder
{
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.QuickMedicationOrder.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseCommand(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "vfyamount":

                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.VerifyAmount.ParseAction(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO - Exit gracefully.

                    break;
            }
        }
    }
}
