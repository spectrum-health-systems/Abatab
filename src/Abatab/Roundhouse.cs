﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Roundhouse.cs
// Logic for parsing the module component of the Script Parameter.
// b230718.1044
// -----------------------------------------------------------------------------

/* DEVNOTE
 *
 */


using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Logic for parsing the module component of the Script Parameter.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>This is defined at the start of the class so it can be easily used throughout the method.</remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Method summary goes here.
        ///
        /// </summary>
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.Testing.Roundhouse.ParseCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.ProgressNote.Roundhouse.ParseCommand(abSession);

                    break;

                case "qmedordr":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.QuickMedicationOrder.Roundhouse.ParseCommand(abSession);

                    break;

                default:

                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    // TODO: Eventually this should exit gracefully

                    break;
            }

            // Normal comment
            //INFO This is important
            //Strike This is depreciated
            //// Also depreciated
            //REVIEW This is a questoion
            //TODO This is a todo
        }
    }
}