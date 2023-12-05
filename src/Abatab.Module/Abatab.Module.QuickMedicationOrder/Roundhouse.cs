﻿// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab.Module.QuickMedicationOrder
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Executing assembly name for log files.
        /// </summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void ParseCommand(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "vfyamount":

                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Action.VerifyAmount.ParseAction(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}
