// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogEvent.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Abatab.Core.Logger
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class LogEvent
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void Alert(AbSession abSession, string assemblyName, [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "")
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteAlert(abSession, assemblyName, callPath, callMember);
        }

        /* QUESTION Is there a better way to do this, instead of checking if logging is enabled and then checking to see if the types are correct?
         */

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void Trace(string logType, AbSession abSession, string assemblyName, string logMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            /* TODO Refactor &&/|| to and/or */

            if (abSession.LoggerMode == "enabled" && (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains(logType)))
            {
                LogWriter.WriteTrace(abSession, assemblyName, logMsg, callPath, callMember, callLine);
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void Session(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
             */
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteSession(abSession, Catalog.Output.Session.Complete(abSession));
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void CurrentSetting(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
             */
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteSetting(abSession, Catalog.Output.Setting.Current(abSession));
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void Warning(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
             */
            Debuggler.DebugLog(abSession.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            /* DEVELOPER_NOTE
             * We want to write this all the time, so the depreciated code below is probably not needed.
             */

            /* DEPRECIATED
            //if (abSession.LoggerMode == "enabled")
            //{
            //    if (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains("warning"))
            //    {
            //        var logPath = LogPath.ForWarningLog(abSession);
            //        //var logMsg  = Catalog.Component.AlertLog.ModProgressNoteVerifyLocation(abSession);

            //        //LogWriter.LocalFile(logPath, logMsg, Convert.ToInt32(abSession.LoggerDelay));
            //    }
            //}
            */
        }
    }
}