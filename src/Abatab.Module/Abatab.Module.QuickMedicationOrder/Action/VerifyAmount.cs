// b230516.0855

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.QuickMedicationOrder.Action
{
    internal class VerifyAmount
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Module.QuickMedicationOrder.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);


            switch (abSession.RequestAction)
            {
                case "dose":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);


                    break;

                //case "groupindinote":
                //    LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //    if (ValidGroupIndividualizedNote(abSession.ModProgressNote.FlaggedServiceChargeCodeCodes, serviceChargeCodeValue, abSession.ModProgressNote.ValidLocationCodes, locationValue))
                //    {
                //        LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //        abSession.ReturnOptionObject.ToReturnOptionObject();
                //    }
                //    else
                //    {
                //        LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //        CreateWarning(abSession, serviceChargeCodeValue);
                //    }
                //    break;

                //case "indicounselingnote":
                //    LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //    if (ValidIndividualCounselingNote(abSession.ModProgressNote.FlaggedServiceChargeCodePrefixes, serviceChargeCodeValue, abSession.ModProgressNote.ValidLocationCodes, locationValue))
                //    {
                //        LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //        abSession.ReturnOptionObject.ToReturnOptionObject();
                //    }
                //    else
                //    {
                //        LogEvent.Trace("traceinternal", abSession, AssemblyName);
                //        CreateWarning(abSession, serviceChargeCodeValue);
                //    }
                //    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}
