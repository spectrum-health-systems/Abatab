/* ========================================================================================================
 * AbatabLogging.LogEvent.cs: Logs an Abatab event.
 * b220922.110913
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using AbatabSession;
using System.Runtime.CompilerServices;

namespace AbatabLogging
{
    public class LogEvent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        public static void AllEvents(string executingAssemblyName, SessionData abatabSession)
        {
            Trace(executingAssemblyName, abatabSession);
            SessionData(abatabSession);
            AllOptionObjectInformation(abatabSession);
        }

        /// <summary>
        /// Build a OptionObject information log.
        /// </summary>
        /// <param name="optObjType">Type of OptionObject.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        public static void AllOptionObjectInformation(SessionData abatabSession, string logMessage = "OptionObject information log.")
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
        public static void SessionData(SessionData abatabSession, string logMessage = "Session information log.")
        {
            BuildContent.LogTextWithoutTrace("sessionInformation", abatabSession, logMessage);
        }

        /// <summary>
        /// Build a trace log.
        /// </summary>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        public static void Trace(string executingAssemblyName, SessionData abatabSession, string logMessage = "Trace log.", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            // TODO See if we can get the Executing Assembly name here, instead of passing it.
            BuildContent.LogTextWithTrace("trace", executingAssemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);
        }
    }
}