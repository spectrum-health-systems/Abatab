// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Abatab.Core.Logger
{
    /// <summary>Summary goes here.</summary>
    public static class LogEvent
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void Alert(AbSession abSession, string assemblyName, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "")
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteAlert(abSession, assemblyName, callPath, callMember);
        }

        // TODO - Maybe figure out a better way to do this, instead of checking if logging is enabled and then checking to see if the types are correct.

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void Trace(string logType, AbSession abSession, string assemblyName, string logMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            if (abSession.LoggerMode == "enabled" && (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains(logType)))
            {
                LogWriter.WriteTrace(abSession, assemblyName, logMsg, callPath, callMember, callLine);
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void Session(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteSession(abSession, Catalog.Output.Session.Complete(abSession));
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void CurrentSetting(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteSetting(abSession, Catalog.Output.Setting.Current(abSession));
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void Warning(AbSession abSession)
        {
            // REVIEW: Can a trace log go here?
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            // DEVNOTE: We want to write this all the time.

            //if (abSession.LoggerMode == "enabled")
            //{
            //    if (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains("warning"))
            //    {
            //        var logPath = LogPath.ForWarningLog(abSession);
            //        //var logMsg  = Catalog.Component.AlertLog.ModProgressNoteVerifyLocation(abSession);

            //        //LogWriter.LocalFile(logPath, logMsg, Convert.ToInt32(abSession.LoggerDelay));
            //    }
            //}
        }
    }
}