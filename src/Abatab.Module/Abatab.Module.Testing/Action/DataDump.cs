﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Module.Testing.Action.DataDump.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

/* DEVNOTE
 * Write something about what this testing functionality is used for.
 */

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab.Module.Testing.Action
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    internal class DataDump
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

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}