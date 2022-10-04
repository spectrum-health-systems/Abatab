/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildContent.cs                                                                           b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using NTST.ScriptLinkService.Objects;
using System;
using System.IO;
using System.Reflection;

namespace AbatabLogging
{
    public class BuildContent
    {
        /// <summary>
        /// Build the logfile content with trace information.
        /// </summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Contents for a logfile with trace information.</returns>
        public static string LogTextWithTrace(string eventType, string executingAssemblyName, SessionData abatabSession, string logMessage, string callerFilePath, string callerMemberName, int callerLine)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            var logHeader  = LogHeader(logMessage);
            var logDetails = LogDetailsWithTrace(eventType, executingAssemblyName, callerFilePath, callerMemberName, callerLine);
            var logBody    = LogBody(eventType, abatabSession);
            var logFooter  = LogFooter();

            return $"{logHeader}{Environment.NewLine}" +
                   $"{logDetails}{Environment.NewLine}" +
                   $"{logBody}{Environment.NewLine}" +
                   $"{logFooter}{Environment.NewLine}";
        }


        public static string Debug(string executingAssemblyName, string debugMode, string debugLogDirRoot, string debugMsg, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logHeader  = LogHeader(debugMsg);
            var logDetails = LogDetailsWithTrace("debug", executingAssemblyName, callerFilePath, callerMemberName, callerLine);
            var logBody    = "";
            var logFooter  = LogFooter();

            return $"{logHeader}" +
                   $"{logDetails}" +
                   $"{logBody}" +
                   $"{logFooter}";
        }

        /// <summary>
        /// Build the logfile content without trace information.
        /// </summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="assemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <returns>Contents for a logfile without trace information.</returns>
        public static string LogTextWithoutTrace(string eventType, SessionData abatabSession, string logMessage)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            var logHeader  = LogHeader(logMessage);
            var logDetails = LogDetailsWithoutTrace(eventType);
            var logBody    = LogBody(eventType, abatabSession);
            var logFooter  = LogFooter();

            return $"{logHeader}{Environment.NewLine}" +
                   $"{logDetails}{Environment.NewLine}" +
                   $"{logBody}{Environment.NewLine}" +
                   $"{logFooter}{Environment.NewLine}";
        }

        /// <summary>
        /// Build a standard log header.
        /// </summary>
        /// <param name="logMessage">Log message.</param>
        /// <returns> Standard log header.</returns>
        private static string LogHeader(string logMessage)
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return $"{logMessage}{Environment.NewLine}";
        }

        /// <summary>
        /// Build standard log details with trace information.
        /// </summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Standard log details with trace information.</returns>
        private static string LogDetailsWithTrace(string eventType, string executingAssemblyName, string callerFilePath, string callerMemberName, int callerLine)
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return $"{Environment.NewLine}" +
                   $"Log type: {eventType}{Environment.NewLine}" +
                   $"Assembly: {executingAssemblyName}{Environment.NewLine}" +
                   $"  Source: {Path.GetFileName(callerFilePath)}{Environment.NewLine}" +
                   $"  Member: {callerMemberName}{Environment.NewLine}" +
                   $"    Line: {callerLine}{Environment.NewLine}";
        }

        /// <summary>
        /// Build standard log details without trace information.
        /// </summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="assemblyName">Name of executing assembly.</param>
        /// <returns>Standard log details without trace information.</returns>
        private static string LogDetailsWithoutTrace(string eventType)
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return $"{Environment.NewLine}" +
                   $"Log type: {eventType}{Environment.NewLine}";
        }

        /// <summary>
        /// Build standard log body for different log events.
        /// </summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Standard log body.</returns>
        private static string LogBody(string eventType, SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            switch (eventType)
            {
                case "sessionInformation":
                    return BodySessionInformation(abatabSession);

                case "allOptObjInformation":
                    return BodyAllOptObjInformation(abatabSession);

                case "sentOptObjInformation":
                    return BodyOptObjInformation(abatabSession.SentOptObj, "sentOptObj");

                case "workerOptObjInformation":
                    return BodyOptObjInformation(abatabSession.WorkOptObj, "workerOptObj");

                case "finalOptObjInformation":
                    return BodyOptObjInformation(abatabSession.FinalOptObj, "finalOptObj");

                case "trace":
                default:
                    return "";
            }
        }

        /// <summary>
        /// Build information for all OptionObject types.
        /// </summary>
        /// <param name="optObj">OptionObject2015 object to get information for.</param>
        /// <returns>Information for all OptionObject types.</returns>
        private static string BodyAllOptObjInformation(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            var sentOptObjectInformation   = BodyOptObjInformation(abatabSession.SentOptObj, "sentOptObj");
            var workerOptObjectInformation = BodyOptObjInformation(abatabSession.SentOptObj, "workerOptObj");
            var finalOptObjectInformation  = BodyOptObjInformation(abatabSession.SentOptObj, "finalOptObj");

            return $"{sentOptObjectInformation}{Environment.NewLine}" +
                   $"{workerOptObjectInformation}{Environment.NewLine}" +
                   $"{finalOptObjectInformation}{Environment.NewLine}";
        }



        /// <summary>
        /// Build OptionObject information for log body.
        /// </summary>
        /// <param name="optObj">OptionObject2015 object to get information for.</param>
        /// <returns>Standard OptionObject information.</returns>
        private static string BodyOptObjInformation(OptionObject2015 optObj, string optObjType)
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return $" OptionObject Type: {optObjType}{Environment.NewLine}" +
                   $"          EntityID: {optObj.EntityID}{Environment.NewLine}" +
                   $"          Facility: {optObj.Facility}{Environment.NewLine}" +
                   $"     NamespaceName: {optObj.NamespaceName}{Environment.NewLine}" +
                   $"          OptionId: {optObj.OptionId}{Environment.NewLine}" +
                   $"   ParentNamespace: {optObj.ParentNamespace}{Environment.NewLine}" +
                   $"        ServerName: {optObj.ServerName}{Environment.NewLine}" +
                   $"        SystemCode: {optObj.SystemCode}{Environment.NewLine}" +
                   $"     EpisodeNumber: {optObj.EpisodeNumber}{Environment.NewLine}" +
                   $"     OptionStaffId: {optObj.OptionStaffId}{Environment.NewLine}" +
                   $"      OptionUserId: {optObj.OptionUserId}{Environment.NewLine}" +
                   $"         ErrorCode: {optObj.ErrorCode}{Environment.NewLine}" +
                   $"         ErrorMesg: {optObj.ErrorMesg}";
        }

        /// <summary>
        /// Build standard session information log body.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Standard session information.</returns>
        private static string BodySessionInformation(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            var allOptObjInformation =BodyAllOptObjInformation(abatabSession);

            // TODO - Verify this works, especially the modification stuff.
            return $"{Environment.NewLine}" +
                          $"              Abatab mode: {abatabSession.AbatabMode}{Environment.NewLine}" +
                          $"               Debug mode: {abatabSession.DebugMode}{Environment.NewLine}" +
                          $"             Logging mode: {abatabSession.LoggingMode}{Environment.NewLine}" +
                          $"          Logging details: {abatabSession.LoggingDetails}{Environment.NewLine}" +
                          $"    Abatab root directory: {abatabSession.AbatabRoot}{Environment.NewLine}" +
                          $"Avatar fallback user name: {abatabSession.AvatarFallbackUserName}{Environment.NewLine}" +
                          $"    Session log directory: {abatabSession.SessionLogDirectory}{Environment.NewLine}" +
                          $"          Avatar username: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"           Abatab request: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"    Abatab request module: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"   Abatab request command: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"    Abatab request action: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"    Abatab request option: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"{allOptObjInformation}";
        }

        /// <summary>
        /// Build a standard log footer.
        /// </summary>
        /// <returns>Standard log footer.</returns>
        private static string LogFooter()
        {
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return $"End of log.{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }
    }
}