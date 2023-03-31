// Abatab.Flightpath.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.IO;
using System.Reflection;
using Abatab.Core.Catalog.Session;
using Abatab.Core.Framework;
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
        public static void StartAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            /* We can't put a trace log here, so we'll do the next best thing and put a debuggler statement that fires if the DebugglerMode is "enabled". This is helpful for
            * development, but eventually I'll probably remove or simplify these in order to keep the code clean.
            */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            InitializeAbatab(abSession, scriptParameter, sentOptionObject);
            RefreshAbatab(abSession, scriptParameter, sentOptionObject);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/FinishAbatab/*' />
        public static void FinishAbatab(AbSession abSession)
        {
            /* We can't put a trace log here, so we'll do the next best thing and put a debuggler statement that fires if the DebugglerMode is "enabled". This is helpful for
            * development, but eventually I'll probably remove or simplify these in order to keep the code clean.
            */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            LogEvent.Trace("trace", abSession, AssemblyName);
            Core.DataExport.SessionInformation.ToSessionRoot(abSession);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/StartAbatab/*' />
        private static void InitializeAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            /* We can't put a trace log here, so we'll do the next best thing and put a debuggler statement that fires if the DebugglerMode is "enabled". This is helpful for
            * development, but eventually I'll probably remove or simplify these in order to keep the code clean.
            */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            WebConfig.Load(abSession);
            Build.NewSession(sentOptionObject, scriptParameter, abSession);

            Roundhouse.ParseModule(abSession);
        }

        /// <include file='docs/doc/xml/inc/Abatab.xmldoc' path='XMLDoc/Class[@name="Flightpath.cs"]/StartAbatab/*' />
        private static void RefreshAbatab(AbSession abSession, string scriptParameter, OptionObject2015 sentOptionObject)
        {
            /* We can't put a trace log here, so we'll do the next best thing and put a debuggler statement that fires if the DebugglerMode is "enabled". This is helpful for
            * development, but eventually I'll probably remove or simplify these in order to keep the code clean.
            */
            if (Settings.Default.DebugglerMode == "enabled")
            {
                LogFile.Debuggler(Assembly.GetExecutingAssembly().GetName().Name);
            }

            if (!Directory.Exists(abSession.SessionDataRoot))
            {
                LogEvent.Trace("traceinternal", abSession, AssemblyName);
                Refresh.Daily(abSession);
            }

            //Roundhouse.ParseModule(abSession);
        }
    }
}