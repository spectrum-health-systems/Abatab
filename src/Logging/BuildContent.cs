/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * v0.0.1.0-devbuild+220907.121935
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.Logging.BuildContent.cs: Builds content for a logfile.
 * b220907.122057
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ========================================================================================================
 */

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
                case "trace":
                    // Don't do anything
                    break;

                case "sessionInformation":
                    // Don't do anything
                    break;

                default:
                    // Include Trace?
                    break;
            }


            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static string BodySessionInformation(Session abatabSession)
        {
            // TODO - Verify this works.
            var workerOptObjModified = OptionObject.Verify.NotModified(abatabSession.SentOptObj, abatabSession.WorkerOptObj);

            var workerOptObjModified = OptionObject.Verify.NotModified(abatabSession.SentOptObj, abatabSession.WorkerOptObj);

            return $"{Environment.NewLine}" +
                          $"              Abatab mode: {abatabSession.AbatabMode}{Environment.NewLine}" +
                          $"                 Log mode: {abatabSession.LogMode}{Environment.NewLine}" +
                          $"    Abatab root directory: {abatabSession.AbatabRootDirectory}{Environment.NewLine}" +
                          $"Avatar fallback user name: {abatabSession.AvatarFallbackUserName}{Environment.NewLine}" +
                          $"                Datestamp: {abatabSession.DateStamp}{Environment.NewLine}" +
                          $"                Timestamp: {abatabSession.TimeStamp}{Environment.NewLine}" +
                          $"           Abatab request: {abatabSession.AvatarUserName}{Environment.NewLine}" +
                          $"  Working Object modified: {workerOptObjModified}{Environment.NewLine}" +
                          $"    Final Object modified: {finalOptObjModified}{Environment.NewLine}";

        }


        /*
         * 

        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkerOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
        
         */



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