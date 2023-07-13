// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Module.QuickMedicationOrder.VerifyAmount.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab.Module.QuickMedicationOrder.Action
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    internal class VerifyAmount
    {
        /// <summary>
        /// Executing assembly name for log files.
        /// </summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Method summary goes here.
        /// </summary>
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

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}
