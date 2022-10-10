/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabLogging.csproj                                                                             v0.91.0
 * BuildContent.cs                                                                           b221009.090325
 * --------------------------------------------------------------------------------------------------------
 * Builds the various components of a log file.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using NTST.ScriptLinkService.Objects;
using System;
using System.IO;

namespace AbatabLogging
{
    public class BuildContent
    {
        /// <summary>Build all logfile components.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <param name="logMsg">Message for the logfile</param>
        /// <param name="callPath">Filename of where the log is coming from.</param>
        /// <param name="callMember">Method of where the log is coming from.</param>
        /// <param name="callLine">File line of where the log is coming from.</param>
        /// <returns>Content for a log file.</returns>
        public static string LogComponents(string eventType, SessionData abatabSession, string logMsg, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            var logHead   = ComponentHead(logMsg);
            var logDetail = ComponentDetail(eventType, exeAssembly, callPath, callMember, callLine);
            var logBody   = ComponentBody(eventType, abatabSession);
            var logFoot   = ComponentFoot();

            return $"{logHead}" +
                   $"{logDetail}" +
                   $"{logBody}" +
                   $"{logFoot}";
        }

        /// <summary>Build debug log.</summary>
        /// <param name="debugMode">Debug mode setting.</param>
        /// <param name="debugMsg">Debug log message.</param>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="callerPath">Filename of where the log is coming from.</param>
        /// <param name="callerMember">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Content for a debug log file.</returns>
        public static string DebugComponents(string exeAssembly, string debugMode, string debugMsg, string callPath, string callMember, int callLine)
        {
            var logHead   = ComponentHead(debugMsg);
            var logDetail = ComponentDetail("debug", exeAssembly, callPath, callMember, callLine);
            var logBody   = $"DebugMode: {debugMode}";
            var logFoot   = ComponentFoot();

            return $"{logHead}" +
                   $"{logDetail}" +
                   $"{logBody}" +
                   $"{logFoot}";
        }

        /// <summary>Build log header.</summary>
        /// <param name="logMsg">Log message.</param>
        /// <returns>Log header.</returns>
        private static string ComponentHead(string logMsg)
        {
            return $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}" +
                   $"{logMsg}{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}";
        }

        /// <summary>Build log details.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="exeAssembly">Name of executing assembly.</param>
        /// <param name="callerPath">Filename of where the log is coming from.</param>
        /// <param name="callerMember">Method of where the log is coming from.</param>
        /// <param name="callerLine">File line of where the log is coming from.</param>
        /// <returns>Log details.</returns>
        private static string ComponentDetail(string eventType, string exeAssembly, string callPath, string callMember, int callLine = 0)
        {
            var detailHead = $"{Environment.NewLine}" +
                             $"==========={Environment.NewLine}" +
                             $"Log details{Environment.NewLine}" +
                             $"===========";

            var logDetail = string.IsNullOrWhiteSpace(callPath)
                ? $"{Environment.NewLine}" +
                  $"Log type: {eventType}{Environment.NewLine}"
                : $"{Environment.NewLine}" +
                  $"Log type: {eventType}{Environment.NewLine}" +
                  $"Assembly: {exeAssembly}{Environment.NewLine}" +
                  $"Source:   {Path.GetFileName(callPath)}{Environment.NewLine}" +
                  $"Member:   {callMember}{Environment.NewLine}" +
                  $"Line:     {callLine}{Environment.NewLine}";

            return $"{detailHead}" +
                   $"{logDetail}";

        }

        /// <summary>Build log body.</summary>
        /// <param name="eventType">Log type.</param>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Log body.</returns>
        private static string ComponentBody(string eventType, SessionData abatabSession)
        {
            switch (eventType)
            {
                case "session":
                    return BodySessionDetail(abatabSession);

                case "trace":
                default:
                    return "";
            }
        }

        /// <summary>Build session information log body.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Session information for log body.</returns>
        private static string BodySessionDetail(SessionData abatabSession)
        {
            var sessionDetailHead = $"{Environment.NewLine}" +
                                    $"==============={Environment.NewLine}" +
                                    $"Session details{Environment.NewLine}" +
                                    $"===============";

            // TODO - Verify this works, especially the modification stuff.
            var sessionDetail = $"{Environment.NewLine}" +
                                $"Abatab Mode:         {abatabSession.AbatabMode}{Environment.NewLine}" +
                                $"Abatab Root:         {abatabSession.AbatabRoot}{Environment.NewLine}" +
                                $"Debugging Mode:      {abatabSession.DebugMode}{Environment.NewLine}" +
                                $"Debugging Log root:  {abatabSession.DebugLogRoot}{Environment.NewLine}" +
                                $"Logging Mode:        {abatabSession.LoggingMode}{Environment.NewLine}" +
                                $"Logging Detail:      {abatabSession.LoggingDetail}{Environment.NewLine}" +
                                $"Logging Delay:       {abatabSession.LoggingDelay}{Environment.NewLine}" +
                                $"Session Timestamp:   {abatabSession.SessionTimestamp}{Environment.NewLine}" +
                                $"Session Log root:    {abatabSession.SessionLogRoot}{Environment.NewLine}" +
                                $"Avatar username:     {abatabSession.AvatarUserName}{Environment.NewLine}" +
                                $"Fallback username:   {abatabSession.AvatarFallbackUserName}{Environment.NewLine}" +
                                $"Abatab request:      {abatabSession.AbatabRequest}{Environment.NewLine}" +
                                $"    Module:          {abatabSession.AbatabModule}{Environment.NewLine}" +
                                $"    Command:         {abatabSession.AbatabCommand}{Environment.NewLine}" +
                                $"    Action:          {abatabSession.AbatabAction}{Environment.NewLine}" +
                                $"    Option:          {abatabSession.AbatabOption}{Environment.NewLine}" +
                                $"{Environment.NewLine}" +
                                $"===================={Environment.NewLine}" +
                                $"OptionObject details{Environment.NewLine}" +
                                $"====================" +
                                $"{BodyOptObjDetail(abatabSession.SentOptObj, "sentOptObj")}{Environment.NewLine}" +
                                $"{BodyOptObjDetail(abatabSession.WorkOptObj, "workerOptObj")}{Environment.NewLine}" +
                                $"{BodyOptObjDetail(abatabSession.FinalOptObj, "finalOptObj")}{Environment.NewLine}";

            return $"{sessionDetailHead}" +
                   $"{sessionDetail}";
        }

        /// <summary><param name="thisOptObj">OptionObject2015 object to get information for.</param>
        /// <returns>Details of an OptionObject.</returns>
        private static string BodyOptObjDetail(OptionObject2015 thisOptObj, string optObjType)
        {
            var optObjHead = $"{Environment.NewLine}" +
                             $"------------{Environment.NewLine}" +
                             $"{optObjType}{Environment.NewLine}" +
                             $"------------";

            var optObjInfo = $"{Environment.NewLine}" +
                             $"EntityID:          {thisOptObj.EntityID}{Environment.NewLine}" +
                             $"Facility:          {thisOptObj.Facility}{Environment.NewLine}" +
                             $"NamespaceName:     {thisOptObj.NamespaceName}{Environment.NewLine}" +
                             $"OptionId:          {thisOptObj.OptionId}{Environment.NewLine}" +
                             $"ParentNamespace:   {thisOptObj.ParentNamespace}{Environment.NewLine}" +
                             $"ServerName:        {thisOptObj.ServerName}{Environment.NewLine}" +
                             $"SystemCode:        {thisOptObj.SystemCode}{Environment.NewLine}" +
                             $"EpisodeNumber:     {thisOptObj.EpisodeNumber}{Environment.NewLine}" +
                             $"OptionStaffId:     {thisOptObj.OptionStaffId}{Environment.NewLine}" +
                             $"OptionUserId:      {thisOptObj.OptionUserId}{Environment.NewLine}" +
                             $"ErrorCode:         {thisOptObj.ErrorCode}{Environment.NewLine}" +
                             $"ErrorMesg:         {thisOptObj.ErrorMesg}";

            return $"{optObjHead}" +
                   $"{optObjInfo}";
        }

        /// <summary>Build log footer.</summary>
        /// <returns>Log footer.</returns>
        private static string ComponentFoot(string footMsg = "End of log.")
        {
            return $"{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}" +
                   $"{footMsg}{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=";
        }
    }
}