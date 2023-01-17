// Abatab.AbatabLogging.BuildContent.cs b230117.0910
// Copyright (c) A Pretty Cool Program

/* ========================================================================================================
 * Logging is done a little differently in AbatabLogging classes, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using AbatabData;

using NTST.ScriptLinkService.Objects;

using System;
using System.IO;
using System.Reflection;

namespace AbatabLogging
{
    /// <summary>Logic for building log file content.</summary>
    public static class BuildContent
    {
        /// <summary>Builds the content for a log file.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="logMsg">The log message.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>The completed content for a log file.</returns>
        public static string LogComponents(string eventType, Session abatabSession, string logMsg, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var logHead = ComponentHead(logMsg);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var logDetail = ComponentDetail(eventType, exeAssembly, callPath, callMember, callLine);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var logBody = ComponentBody(eventType, abatabSession);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var logFoot = ComponentFoot();
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            return $"{logHead}" +
                   $"{logDetail}" +
                   $"{logBody}" +
                   $"{logFoot}";
        }

        /// <summary>Builds the content for a debug log file.</summary>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="debugMode">The Abatab debug mode setting.</param>
        /// <param name="debugMsg">The debug log message.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>The completed content for a debug log file.</returns>
        public static string DebugComponents(string exeAssembly, string debugMode, string debugMsg, string callPath, string callMember, int callLine)
        {
            // No log statement here (see comments at top of file)

            var logHead   = ComponentHead(debugMsg);
            var logDetail = ComponentDetail("debug", exeAssembly, callPath, callMember, callLine);
            var logBody   = $"DebugMode: {debugMode}";
            var logFoot   = ComponentFoot();

            return $"{logHead}" +
                   $"{logDetail}" +
                   $"{logBody}" +
                   $"{logFoot}";
        }

        /// <summary>Builds the log header component.</summary>
        /// <param name="logMsg">The log message.</param>
        /// <returns>The completed log header component.</returns>
        private static string ComponentHead(string logMsg)
        {
            // No log statement here (see comments at top of file)

            return $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}" +
                   $"{logMsg}{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}";
        }

        /// <summary>Builds the log details component.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>The completed log details component.</returns>
        private static string ComponentDetail(string eventType, string exeAssembly, string callPath, string callMember, int callLine = 0)
        {
            // No log statement here (see comments at top of file)

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

        /// <summary>Builds the log body component.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <returns>The completed log body component.</returns>
        private static string ComponentBody(string eventType, Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            switch (eventType)
            {
                case "session":
                    return BodySessionDetail(abatabSession);

                case "quickmedorder":
                    return BodyModQuickMedOrderDetail(abatabSession);

                case "trace":
                default:
                    // Gracefully exit.
                    return "";
            }
        }

        /// <summary>Builds a log body component for session details.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <returns>The completed log body component for session details.</returns>
        private static string BodySessionDetail(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var sessionHead = $"{Environment.NewLine}" +
                              $"==============={Environment.NewLine}" +
                              $"Session details{Environment.NewLine}" +
                              "===============";

            var sessionDetail = $"{Environment.NewLine}" +
                                $"Abatab Mode:         {abatabSession.AbatabMode}{Environment.NewLine}" +
                                $"Abatab Root:         {abatabSession.AbatabRoot}{Environment.NewLine}" +
                                $"Debugging Mode:      {abatabSession.DebugglerConfig.DebugMode}{Environment.NewLine}" +
                                $"Debugging Log root:  {abatabSession.DebugglerConfig.DebugEventRoot}{Environment.NewLine}" +
                                $"Logging Mode:        {abatabSession.LoggingConfig.LoggingMode}{Environment.NewLine}" +
                                $"Logging Detail:      {abatabSession.LoggingConfig.Detail}{Environment.NewLine}" +
                                $"Logging Delay:       {abatabSession.LoggingConfig.WriteDelay}{Environment.NewLine}" +
                                $"Session DateStamp:   {abatabSession.SessionDateStamp}{Environment.NewLine}" +
                                $"Session TimeStamp:   {abatabSession.SessionTimeStamp}{Environment.NewLine}" +
                                $"Session Log root:    {abatabSession.LoggingConfig.SessionRoot}{Environment.NewLine}" +
                                $"Avatar username:     {abatabSession.AbatabUserName}{Environment.NewLine}" +
                                $"Fallback username:   {abatabSession.AbatabFallbackUserName}{Environment.NewLine}" +
                                $"Abatab request:      {abatabSession.ScriptParameter}{Environment.NewLine}" +
                                $"    Module:          {abatabSession.AbatabModule}{Environment.NewLine}" +
                                $"    Command:         {abatabSession.AbatabCommand}{Environment.NewLine}" +
                                $"    Action:          {abatabSession.AbatabAction}{Environment.NewLine}" +
                                $"    Option:          {abatabSession.AbatabOption}{Environment.NewLine}" +
                                $"{Environment.NewLine}" +
                                $"============================{Environment.NewLine}" +
                                $"Module details{Environment.NewLine}" +
                                $"============================" +
                                $"{BodyModuleDetail(abatabSession, "Date")}{Environment.NewLine}" +
                                $"{BodyModuleDetail(abatabSession, "QuickMedOrder")}{Environment.NewLine}" +
                                $"{BodyModuleDetail(abatabSession, "Prototype")}{Environment.NewLine}" +
                                $"{BodyModuleDetail(abatabSession, "Testing")}{Environment.NewLine}" +
                                $"{Environment.NewLine}" +
                                $"===================={Environment.NewLine}" +
                                $"OptionObject details{Environment.NewLine}" +
                                $"====================" +
                                $"{BodyOptObjDetail(abatabSession.SentOptObj, "sentOptObj")}{Environment.NewLine}" +
                                $"{BodyOptObjDetail(abatabSession.WorkOptObj, "workerOptObj")}{Environment.NewLine}" +
                                $"{BodyOptObjDetail(abatabSession.FinalOptObj, "finalOptObj")}{Environment.NewLine}";

            return $"{sessionHead}" +
                   $"{sessionDetail}";
        }

        /// <summary>Builds the log body component for module details.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="modName">The name of the module.</param>
        /// <returns>The completed log body component for module details.</returns>
        private static string BodyModuleDetail(Session abatabSession, string modName)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var moduleHead = $"{Environment.NewLine}" +
                             $"-------------{Environment.NewLine}" +
                             $"{modName}{Environment.NewLine}" +
                             $"-------------{Environment.NewLine}";

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot);

            string moduleDetail;

            switch (modName.ToLower())
            {
                case "quickmedorder":
                    LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot);
                    moduleDetail = $"Mode:                 {abatabSession.ModQuickMedOrderConfig.Mode}{Environment.NewLine}" +
                                   $"Valid users:          {abatabSession.ModQuickMedOrderConfig.AuthorizedUsers}{Environment.NewLine}" +
                                   $"Max percent increase: {abatabSession.ModQuickMedOrderConfig.DosePercentBoundary}";
                    break;

                case "prototype":
                    LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, $"Mode: {abatabSession.ModPrototypeConfig.Mode}");
                    moduleDetail = $"Mode: {abatabSession.ModPrototypeConfig.Mode}";
                    break;

                case "testing":
                    LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot);
                    moduleDetail = $"Mode: {abatabSession.ModTestingConfig.Mode}";
                    break;

                default:
                    LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot);
                    moduleDetail = "Undefined.";
                    break;
            }

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot);

            return $"{moduleHead}" +
                   $"{moduleDetail}";
        }

        /// <summary>Builds the log body component for the QuickMedOrder details.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <returns>The completed log body component for QuickMedOrder details.</returns>
        private static string BodyModQuickMedOrderDetail(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");

            var modQuickMedOrderHead = $"{Environment.NewLine}" +
                                       $"====================={Environment.NewLine}" +
                                       $"QuickMedOrder details{Environment.NewLine}" +
                                       $"====================";

            var modQuickMedOrderDetail = $"{Environment.NewLine}" +
                                         $"Previous dose prefix:              \"{abatabSession.ModQuickMedOrderConfig.PrevDosePrefix}\"{Environment.NewLine}" +
                                         $"Previous dose suffix:              \"{abatabSession.ModQuickMedOrderConfig.PrevDoseSuffix}\"{Environment.NewLine}" +
                                         $"OrderType field ID:                {abatabSession.ModQuickMedOrderConfig.OrderTypeFieldId}{Environment.NewLine}" +
                                         $"Found OrderType field ID:          {abatabSession.ModQuickMedOrderConfig.FoundOrderTypeFieldId}{Environment.NewLine}" +
                                         $"OrderType:                         {abatabSession.ModQuickMedOrderConfig.OrderType}{Environment.NewLine}" +
                                         $"LastOrderScheduled field ID:       {abatabSession.ModQuickMedOrderConfig.LastOrderScheduleFieldId}{Environment.NewLine}" +
                                         $"Found LastOrderScheduled field ID: {abatabSession.ModQuickMedOrderConfig.FoundLastOrderScheduleFieldId}{Environment.NewLine}" +
                                         $"LastOrderScheduled text:           {abatabSession.ModQuickMedOrderConfig.LastOrderScheduleText}{Environment.NewLine}" +
                                         $"DosageOne field ID:                {abatabSession.ModQuickMedOrderConfig.DosageOneFieldId}{Environment.NewLine}" +
                                         $"Found DosageOne field ID:          {abatabSession.ModQuickMedOrderConfig.FoundDosageOneFieldId}{Environment.NewLine}" +
                                         $"CurrentDose:                       {abatabSession.ModQuickMedOrderConfig.CurrentDose}{Environment.NewLine}" +
                                         $"LastScheduledDose:                 {abatabSession.ModQuickMedOrderConfig.LastScheduledDosage}{Environment.NewLine}" +
                                         $"Found all required fields:         {abatabSession.ModQuickMedOrderConfig.FoundAllRequiredFieldIds}{Environment.NewLine}";

            return $"{modQuickMedOrderHead}" +
                   $"{modQuickMedOrderDetail}";
        }

        /// <summary>Builds the log body component for the OptionObject details.</summary>
        /// <param name="optObj">The OptionObject to build from.</param>
        /// <param name="optObjType">The type of OptionObject.</param>
        /// <returns>The completed log body component for OptionObject details.</returns>
        private static string BodyOptObjDetail(OptionObject2015 optObj, string optObjType)
        {
            // No log statement here (see comments at top of file)

            var optObjHead = $"{Environment.NewLine}" +
                             $"------------{Environment.NewLine}" +
                             $"{optObjType}{Environment.NewLine}" +
                             $"------------{Environment.NewLine}";

            var optObjDetail = $"EntityID:        {optObj.EntityID}{Environment.NewLine}" +
                               $"Facility:        {optObj.Facility}{Environment.NewLine}" +
                               $"NamespaceName:   {optObj.NamespaceName}{Environment.NewLine}" +
                               $"OptionId:        {optObj.OptionId}{Environment.NewLine}" +
                               $"ParentNamespace: {optObj.ParentNamespace}{Environment.NewLine}" +
                               $"ServerName:      {optObj.ServerName}{Environment.NewLine}" +
                               $"SystemCode:      {optObj.SystemCode}{Environment.NewLine}" +
                               $"EpisodeNumber:   {optObj.EpisodeNumber}{Environment.NewLine}" +
                               $"OptionStaffId:   {optObj.OptionStaffId}{Environment.NewLine}" +
                               $"OptionUserId:    {optObj.OptionUserId}{Environment.NewLine}" +
                               $"ErrorCode:       {optObj.ErrorCode}{Environment.NewLine}" +
                               $"ErrorMesg:       {optObj.ErrorMesg}";

            return $"{optObjHead}" +
                   $"{optObjDetail}";
        }

        /// <summary>Builds the log footer.</summary>
        /// <returns>The completed log footer.</returns>
        private static string ComponentFoot(string footMsg = "End of log.")
        {
            // No log statement here (see comments at top of file)

            return $"{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={Environment.NewLine}" +
                   $"{footMsg}{Environment.NewLine}" +
                   $"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=";
        }
    }
}