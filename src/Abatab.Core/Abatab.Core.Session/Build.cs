// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utility;
using ScriptLinkStandard.Objects;
using System;
using System.Reflection;

namespace Abatab.Core.Session
{
    /// <summary>Summary goes here.</summary>
    public static class Build
    {
        /// <summary>Executing assembly name for log files.</summary>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void NewSession(OptionObject2015 sentOptionObject, string scriptParameter, AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            BuildSessionRuntimeDetail(abSession);
            BuildSessionOptionObjectDetail(abSession, sentOptionObject);
            BuildAbatabUserName(abSession);
            BuildSessionFrameworkDetail(abSession);
            BuildAbatabRequest(abSession, scriptParameter);
            //BuildModProgressNote(abSession);
            //BuildModPrototype(abSession);
            BuildModQuickMedicationOrder(abSession);
            //BuildModTesting(abSession);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void BuildSessionRuntimeDetail(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            abSession.Datestamp = $"{DateTime.Now:yyMMdd}";
            abSession.Timestamp = $"{DateTime.Now:HHmmss}";
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void BuildSessionFrameworkDetail(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            abSession.SessionDataRoot           = $@"{abSession.AbatabDataRoot}\{abSession.AvatarEnvironment}\{abSession.Datestamp}";
            abSession.SessionDataDirectory      = $@"{abSession.SessionDataRoot}\{abSession.AbatabUserName}\{abSession.Timestamp}";
            abSession.TraceLogDirectory         = $@"{abSession.SessionDataDirectory}\trace";
            abSession.WarningLogDirectory       = $@"{abSession.SessionDataDirectory}\warnings";
            abSession.PublicDataRoot            = $@"{abSession.AbatabDataRoot}\public\";
            abSession.AlertLogDirectory         = $@"{abSession.AbatabDataRoot}\public\alert";
            abSession.DebugglerLogDirectory     = $@"{abSession.AbatabDataRoot}\debuggler";

            Utility.FileSys.VerifyDirectories(Catalog.Key.Directories.Session(abSession));
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void BuildAbatabUserName(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            abSession.AbatabUserName = string.IsNullOrWhiteSpace(abSession.SentOptionObject.OptionUserId)
                ? abSession.AbatabFallbackUserName
                : abSession.SentOptionObject.OptionUserId;
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void BuildSessionOptionObjectDetail(AbSession abSession, OptionObject2015 sentOptionObject)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            //LogEvent.Trace(abSession, "trace", AssemblyName);

            abSession.SentOptionObject   = sentOptionObject;
            abSession.ReturnOptionObject = sentOptionObject.Clone();
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Session.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void BuildAbatabRequest(AbSession abSession, string scriptParameter)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            string[] parameterComponent = scriptParameter.ToLower().Split('-');

            abSession.RequestModule  = parameterComponent[0].Trim().ToLower();
            abSession.RequestCommand = parameterComponent[1].Trim().ToLower();
            abSession.RequestAction  = parameterComponent[2].Trim().ToLower();

            if (parameterComponent.Length == 4)
            {
                LogEvent.Trace("traceinternal", abSession, AssemblyName);
                abSession.RequestOption = parameterComponent[3].ToLower();
            }
        }

        //private static void BuildModPrototype(AbSession abSession, Dictionary<string, string> webConfigContent)
        //{
        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

        //    abSession.ModPrototype = new ModPrototype
        //    {
        //        Mode            = webConfigContent["ModProgressNoteMode"],
        //        AuthorizedUsers = webConfigContent["ModProgressNoteAuthorizedUsers"]
        //    };
        //}

        private static void BuildModQuickMedicationOrder(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            /* These are the Quick Medication Order module settings that are created at runtime. There are also setting for the Progress Note module that are stored in
             * the local Web.config file that are loaded in Abatab.WebConfig.Load().
             */

            //abSession.ModQMedOrdr.

        }

        //private static void BuildModTesting(AbSession abSession, Dictionary<string)
        //{
        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
        //}
    }
}