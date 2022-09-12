/* ========================================================================================================
 * Abatab.Logging.BuildContent.cs: Builds content for a logfile.
 * b220912.112747
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using NTST.ScriptLinkService.Objects;
using System;
using System.IO;

namespace Abatab.Logging
{
    public class BuildContent
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="assemblyName"></param>
        /// <param name="abatabSession"></param>
        /// <param name="logMessage"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        public static string Message(string eventType, string assemblyName, Session abatabSession, string logMessage, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logHeader  = LogHeader(logMessage);
            var logDetails = LogDetails(eventType, assemblyName, callerFilePath, callerMemberName, callerLine);
            var logBody    = LogBody(eventType, abatabSession);
            var logFooter  = LogFooter();

            return "";
        }

        /// <summary>
        /// Standard log header
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        private static string LogHeader(string logMessage)
        {
            return $"{logMessage}:{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }

        /// <summary>
        /// Standard log details.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        private static string LogDetails(string eventType, string assemblyName, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logBody = $"{Environment.NewLine}" +
                          $"Log type: {eventType}{Environment.NewLine}" +
                          $"Assembly: {assemblyName}{Environment.NewLine}" +
                          $"  Source: {Path.GetFileName(callerFilePath)}{Environment.NewLine}" +
                          $"  Member: {callerMemberName}{Environment.NewLine}" +
                          $"    Line: {callerLine}{Environment.NewLine}";

            return logBody;
        }

        /// <summary>
        /// Build the log body.
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static string LogBody(string eventType, Session abatabSession)
        {
            switch (eventType)
            {
                case "sessionInformation":
                    return BodySessionInformation(abatabSession);

                case "SentOptObjInformation":
                    return BodyOptObjInformation(abatabSession.SentOptObj);

                case "WorkerOptObjInformation":
                    return BodyOptObjInformation(abatabSession.WorkerOptObj);

                case "FinalOptObjInformation":
                    return BodyOptObjInformation(abatabSession.FinalOptObj);

                case "trace":
                default:
                    return "";
            }
        }

        /// <summary>
        /// OptionObject information for log body.
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static string BodyOptObjInformation(OptionObject2015 optObj)
        {
            return $"       EntityID: {optObj.EntityID}{Environment.NewLine}" +
                   $"       Facility: {optObj.Facility}{Environment.NewLine}" +
                   $"  NamespaceName: {optObj.NamespaceName}{Environment.NewLine}" +
                   $"       OptionId: {optObj.OptionId}{Environment.NewLine}" +
                   $"ParentNamespace: {optObj.ParentNamespace}{Environment.NewLine}" +
                   $"     ServerName: {optObj.ServerName}{Environment.NewLine}" +
                   $"     SystemCode: {optObj.SystemCode}{Environment.NewLine}" +
                   $"  EpisodeNumber: {optObj.EpisodeNumber}{Environment.NewLine}" +
                   $"  OptionStaffId: {optObj.OptionStaffId}{Environment.NewLine}" +
                   $"   OptionUserId: {optObj.OptionUserId}{Environment.NewLine}" +
                   $"      ErrorCode: {optObj.ErrorCode}{Environment.NewLine}" +
                   $"      ErrorMesg: {optObj.ErrorMesg}";
        }

        /// <summary>
        /// Session information log body.
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static string BodySessionInformation(Session abatabSession)
        {
            // TODO - Verify this works, especially the modification stuff.
            return $"{Environment.NewLine}" +
                          $"              Abatab mode: {abatabSession.AbatabMode}{Environment.NewLine}" +
                          $"                 Log mode: {abatabSession.LogMode}{Environment.NewLine}" +
                          $"    Abatab root directory: {abatabSession.AbatabRootDirectory}{Environment.NewLine}" +
                          $"Avatar fallback user name: {abatabSession.AvatarFallbackUserName}{Environment.NewLine}" +
                          $"                Datestamp: {abatabSession.DateStamp}{Environment.NewLine}" +
                          $"                Timestamp: {abatabSession.TimeStamp}{Environment.NewLine}" +
                          $"           Abatab request: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $" Working Object unchanged: {OptionObject.Verify.NotModified(abatabSession.SentOptObj, abatabSession.WorkerOptObj)}{Environment.NewLine}" +
                          $"   Final Object unchanged: {OptionObject.Verify.NotModified(abatabSession.SentOptObj, abatabSession.FinalOptObj)}{Environment.NewLine}";
        }

        /// <summary>
        /// Standard log footer
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        private static string LogFooter()
        {
            return $"End of log.{Environment.NewLine}" +
                   $"{Environment.NewLine}";
        }
    }
}