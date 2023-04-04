// Abatab.Flightpath.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Session;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Handles high-level program flow.</summary>
    public static class Flightpath
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/StartAbatab/*' />
        public static void InitializeAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            /* INFO: Debuggler statement here, since a Trace log won't work. Used for development/testing.
             */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            WebConfig.Load(abSession);
            Build.NewSession(sentOptionObject, scriptParameter, abSession);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/FinishAbatab/*' />
        public static void WrapUpAbatab(AbSession abSession)
        {
            /* INFO: Debuggler statement here, since a Trace log won't work. Used for development/testing.
             */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            LogEvent.Trace("trace", abSession, AssemblyName);
            Core.DataExport.SessionInformation.ToSessionRoot(abSession);
        }
    }
}