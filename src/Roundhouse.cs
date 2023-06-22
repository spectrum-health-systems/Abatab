// b230615.1008

using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Determines what should be done with the module component of the Script Parameter.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Roundhouse.cs"]/ParseModule/*' />
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Module.Testing.Roundhouse.ParseCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Module.ProgressNote.Roundhouse.ParseCommand(abSession);

                    break;

                case "qmedordr":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Module.QuickMedicationOrder.Roundhouse.ParseCommand(abSession);

                    break;

                default:

                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO: Eventually this should exit gracefully

                    break;
            }
        }
    }
}