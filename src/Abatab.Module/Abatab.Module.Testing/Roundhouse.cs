﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Module.Testing.Roundhouse.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab.Module.Testing
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
            /* DEVNOTE For development/troubleshooting only. */
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name); 

            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "admin":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    //Action.Admin.SendEmail(abSession);

                    break;

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

                    Abatab.Core.Messaging.EmailMsg.Send(abSession, "chris.banwarth@spectrumhealthsystems.org", abSession.AbatabEmailAddress, abSession.AbatabEmailPassword, "This is a test", "Did the test work?");

                    //Action.Messaging.SendEmail(abSession);

                    //Action.Messaging.ParseAction(abSession);

                    break;


                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}