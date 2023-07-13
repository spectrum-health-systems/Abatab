// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Logger
{
    /// <summary>Summary goes here.</summary>
    internal static class LogPath
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Alert(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            var logPath = $@"{abSession.AlertLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}";
            Utility.FileSys.VerifyDirectory(logPath); // TODO - need.

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }


        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Trace(AbSession abSession, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.TraceLogDirectory}\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}-[TRACE].md";
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Session(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.SessionDataDirectory}\{DateTime.Now:HHmmss.fffffff}-[SESSION].md";
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Setting(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.AbatabDataRoot}\{abSession.AvatarEnvironment}\Abatab current settings.md";
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Warning(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            var logPath = $@"{abSession.WarningLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}";
            Utility.FileSys.VerifyDirectory(logPath);

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }
    }
}