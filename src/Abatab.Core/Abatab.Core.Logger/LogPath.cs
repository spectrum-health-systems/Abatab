// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogPath.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Logger
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    internal static class LogPath
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Alert(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            var logPath = $@"{abSession.AlertLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}";
            Utility.FileSys.VerifyDirectory(logPath); // TODO - need.

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }


        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Trace(AbSession abSession, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.TraceLogDirectory}\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}-[TRACE].md";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Session(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
 */
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.SessionDataDirectory}\{DateTime.Now:HHmmss.fffffff}-[SESSION].md";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Setting(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            return $@"{abSession.AbatabDataRoot}\{abSession.AvatarEnvironment}\Abatab current settings.md";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Warning(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            var logPath = $@"{abSession.WarningLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}";
            Utility.FileSys.VerifyDirectory(logPath);

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }
    }
}