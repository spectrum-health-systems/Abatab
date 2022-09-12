﻿/* ========================================================================================================
 * Abatab.Logging.LogEvent.cs: Logs an Abatab event.
 * b220912.112738
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using System.Runtime.CompilerServices;

namespace Abatab.Logging
{
    public class LogEvent
    {
        /// <summary>
        /// Build a OptionObject information log.
        /// </summary>
        /// <param name="optObjType">Type of OptionObject.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void AllOptionObjectInformation(Session abatabSession, string logMessage = "OptionObject information log.")
        {
            BuildContent.LogTextWithoutTrace("allOptObjInformation", abatabSession, logMessage);
        }

        ///// <summary>
        ///// Build a session information log.
        ///// </summary>
        ///// <param name="assemblyName">Name of executing assembly.</param>
        ///// <param name="abatabSession">Abatab session configuration settings.</param>
        ///// <param name="logMessage">Message for the logfile</param>
        ///// <param name="callerFilePath">Filename of where the log is coming from.</param>
        ///// <param name="callerMemberName">Method of where the log is coming from.</param>
        ///// <param name="callerLine">File line of where the log is coming from.</param>
        //public static void SessionInformation(string assemblyName, Session abatabSession, string logMessage = "Session information log.", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        //{
        //    BuildContent.LogText("session-information", assemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);
        //}

        /// <summary>
        /// Build a session information log.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void SessionInformation(Session abatabSession, string logMessage = "Session information log.")
        {
            BuildContent.LogTextWithoutTrace("sessionInformation", abatabSession, logMessage);
        }

        /// <summary>
        /// Build a trace log.
        /// </summary>
        /// <param name="assemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void Trace(string assemblyName, Session abatabSession, string logMessage = "Trace log.", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            BuildContent.LogTextWithTrace("trace", assemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);
        }

    }
}