// b240318.1310

using System.Reflection;

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab
{
    /// <summary>Parses the module component of the Script Parameter.</summary>
    /// <remarks>
    /// - This class should not be modified unless a new Abatab Module is added.
    /// - When a new Abatab Module is added, you will need to <see href="https://github.com/spectrum-health-systems/Abatab-Documentation-Project/blob/main/Development/Processes/adding-a-new-roundhouse-case.md">add a new case to the `SendToModule` method</see>.
    /// - For more information about why this class is designed the way it is, please read about <see href="https://github.com/spectrum-health-systems/Abatab-Documentation-Project/blob/main/Development/the-methedology-behind-abatab.md">the methodology behind Abatab</see>.
    /// </remarks>
    public static class Roundhouse
    {
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Sends the OptionObject to a specific Abatab Module.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        /// * The `command` component of the Script Parameter determines where to route the data sent from Avatar.
        /// * This method ignores all other Script Parameter components are added, since they will be handled by the
        /// recieving module's Roundhouse class.
        /// </remarks>
        public static void SendToModule(AbSession abSession)
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

                    // TODO Eventually this should exit gracefully

                    break;
            }
        }
    }
}