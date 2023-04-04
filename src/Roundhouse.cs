﻿// Abatab.Roundhouse.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Session;
using Abatab.Core.Logger;

namespace Abatab
{
    /// <summary>
    /// Determines what should be done with the <b>module</b> component of the Script Parameter.
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

                default:

                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // Todo: Eventually this should exit gracefully

                    break;
            }
        }
    }
}