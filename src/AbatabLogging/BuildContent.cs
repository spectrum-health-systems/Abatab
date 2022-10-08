/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildContent.cs                                                                           b221008.094839
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Builds the various components of log file content.
 */

using AbatabData;
using NTST.ScriptLinkService.Objects;
using System;
using System.IO;

namespace AbatabLogging
{
    public class BuildContent
    {
        /// <summary>Build logfile content.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMessage">Message for the logfile</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Content for a logfile with trace information.</returns>
        public static string LogContent(string eventType, SessionData abatabSession, string logMessage, string executingAssemblyName = "", string callerFilePath = "", string callerMemberName = "", int callerLine = 0)
        {
            var logHeader  = LogHeader(logMessage);
            var logDetails = LogDetails(eventType, executingAssemblyName, callerFilePath, callerMemberName, callerLine);
            var logBody    = LogBody(eventType, abatabSession);
            var logFooter  = LogFooter();

            return $"{logHeader}" +
                   $"{logDetails}" +
                   $"{logBody}" +
                   $"{logFooter}";
        }

        /// <summary>Build a standard log header.</summary>
        /// <param name="logMessage">Log message.</param>
        /// <returns> Standard log header.</returns>
        private static string LogHeader(string logMessage)
        {
            return $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}" +
                   $"{logMessage}{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}";
        }

        /// <summary>Build standard log details with trace information.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="executingAssemblyName">Name of executing assembly.</param>
        /// <param name="callerFilePath">Filename of where the log is coming from.</param>
        /// <param name="callerMemberName">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Standard log details with trace information.</returns>
        private static string LogDetails(string eventType, string executingAssemblyName, string callerFilePath, string callerMemberName, int callerLine = 0)
        {
            var detailHeader = $"{Environment.NewLine}" +
                               $"==========={Environment.NewLine}" +
                               $"Log details{Environment.NewLine}" +
                               $"===========";

            var logDetail = string.IsNullOrWhiteSpace(callerFilePath)
                ? $"{Environment.NewLine}" +
                  $"Log type: {eventType}{Environment.NewLine}"
                : $"{Environment.NewLine}" +
                  $"Log type: {eventType}{Environment.NewLine}" +
                  $"Assembly: {executingAssemblyName}{Environment.NewLine}" +
                  $"Source:   {Path.GetFileName(callerFilePath)}{Environment.NewLine}" +
                  $"Member:   {callerMemberName}{Environment.NewLine}" +
                  $"Line:     {callerLine}{Environment.NewLine}";

            return $"{detailHeader}" +
                   $"{logDetail}";

        }

        /// <summary>Build standard log body for different log events.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Standard log body.</returns>
        private static string LogBody(string eventType, SessionData abatabSession)
        {
            switch (eventType)
            {
                case "sessionInformation":
                    return BodySessionInfo(abatabSession);

                case "trace":
                default:
                    return "";
            }
        }

        /// <summary>Build standard session information log body.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Standard session information.</returns>
        private static string BodySessionInfo(SessionData abatabSession)
        {
            var sessionInfoHeader = $"{Environment.NewLine}" +
                                    $"==================={Environment.NewLine}" +
                                    $"Session information{Environment.NewLine}" +
                                    $"===================";

            // TODO - Verify this works, especially the modification stuff.
            var sessionInfo = $"{Environment.NewLine}" +
                              $"Abatab mode:               {abatabSession.AbatabMode}{Environment.NewLine}" +
                              $"Debug mode:                {abatabSession.DebugMode}{Environment.NewLine}" +
                              $"Logging mode:              {abatabSession.LoggingMode}{Environment.NewLine}" +
                              $"Logging detail:            {abatabSession.LoggingDetail}{Environment.NewLine}" +
                              $"Abatab root directory:     {abatabSession.AbatabRoot}{Environment.NewLine}" +
                              $"Avatar fallback user name: {abatabSession.AvatarFallbackUserName}{Environment.NewLine}" +
                              $"Session log directory:     {abatabSession.SessionLogDir}{Environment.NewLine}" +
                              $"Avatar username:           {abatabSession.AvatarUserName}{Environment.NewLine}" +
                              $"Abatab request:            {abatabSession.AbatabRequest}{Environment.NewLine}" +
                              $"Abatab request module:     {abatabSession.AbatabModule}{Environment.NewLine}" +
                              $"Abatab request command:    {abatabSession.AbatabCommand}{Environment.NewLine}" +
                              $"Abatab request action:     {abatabSession.AbatabAction}{Environment.NewLine}" +
                              $"Abatab request option:     {abatabSession.AbatabOption}{Environment.NewLine}" +
                              $"{BodyOptObjInfo(abatabSession.SentOptObj, "sentOptObj")}{Environment.NewLine}" +
                              $"{BodyOptObjInfo(abatabSession.WorkOptObj, "workerOptObj")}{Environment.NewLine}" +
                              $"{BodyOptObjInfo(abatabSession.FinalOptObj, "finalOptObj")}{Environment.NewLine}";

            return $"{sessionInfoHeader}" +
                   $"{sessionInfo}";
        }

        /// <summary><param name="optObj">OptionObject2015 object to get information for.</param>
        /// <returns>Standard OptionObject information.</returns>
        private static string BodyOptObjInfo(OptionObject2015 optObj, string optObjType)
        {
            var optObjHeader = $"{Environment.NewLine}" +
                               $"------------{Environment.NewLine}" +
                               $"{optObjType}{Environment.NewLine}" +
                               $"------------";

            var optObjInfo = $"{Environment.NewLine}" +
                             $"EntityID:          {optObj.EntityID}{Environment.NewLine}" +
                             $"Facility:          {optObj.Facility}{Environment.NewLine}" +
                             $"NamespaceName:     {optObj.NamespaceName}{Environment.NewLine}" +
                             $"OptionId:          {optObj.OptionId}{Environment.NewLine}" +
                             $"ParentNamespace:   {optObj.ParentNamespace}{Environment.NewLine}" +
                             $"ServerName:        {optObj.ServerName}{Environment.NewLine}" +
                             $"SystemCode:        {optObj.SystemCode}{Environment.NewLine}" +
                             $"EpisodeNumber:     {optObj.EpisodeNumber}{Environment.NewLine}" +
                             $"OptionStaffId:     {optObj.OptionStaffId}{Environment.NewLine}" +
                             $"OptionUserId:      {optObj.OptionUserId}{Environment.NewLine}" +
                             $"ErrorCode:         {optObj.ErrorCode}{Environment.NewLine}" +
                             $"ErrorMesg:         {optObj.ErrorMesg}";

            return $"{optObjHeader}" +
                   $"{optObjInfo}";
        }
        /// <summary>Build a standard log footer.</summary>
        /// <returns>Standard log footer.</returns>
        private static string LogFooter()
        {
            return $"{Environment.NewLine}" +
                   $"========================================{Environment.NewLine}" +
                   $"End of log.{Environment.NewLine}" +
                   $"========================================";
        }

        /// <summary></summary>
        /// <param name="executingAssemblyName"></param>
        /// <param name="debugMode"></param>
        /// <param name="debugMsg"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        public static string Debug(string executingAssemblyName, string debugMode, string debugMsg, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logHeader  = LogHeader(debugMsg);
            var logDetails = LogDetails("debug", executingAssemblyName, callerFilePath, callerMemberName, callerLine);
            var logBody    = $"DebugMode: {debugMode}";
            var logFooter  = LogFooter();

            return $"{logHeader}" +
                   $"{logDetails}" +
                   $"{logBody}" +
                   $"{logFooter}";
        }
    }
}