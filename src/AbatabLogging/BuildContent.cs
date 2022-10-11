/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabLogging.csproj                                                                             v0.92.0
 * BuildContent.cs                                                                           b221011.074325
 * --------------------------------------------------------------------------------------------------------
 * Builds the various components of a log file.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

/* Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates  logs results in strange behavior. For the most part, LogEvent.Trace() is replaced
 * with Debugger.BuildDebugLog(), although in some cases log files aren't written at all. This makes it a
 * little difficult to troubleshoot logging, which is why it's a good idea to test the logging funcionality
 * extensively prior to deploying to production.
 */

using AbatabData;
using NTST.ScriptLinkService.Objects;
using System;
using System.IO;
using System.Reflection;

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
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Creating log components..");

            var logHead = ComponentHead(logMsg);
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Created log header.");

            var logDetail = ComponentDetail(eventType, exeAssembly, callPath, callMember, callLine);
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Created log detail.");

            var logBody = ComponentBody(eventType, abatabSession);
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Created log body.");

            var logFoot = ComponentFoot();
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Created log footer.");

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

            // No LogEvent.Trace() here because the necessary information doesn't exist.
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
                    // No LogEvent.Trace() here because the necessary information doesn't exist.
                    return BodySessionDetail(abatabSession);

                case "quickmedorder":
                    // No LogEvent.Trace() here because the necessary information doesn't exist.
                    return BodyModQuickMedOrderDetail(abatabSession);

                case "trace":
                default:
                    // No LogEvent.Trace() here because the necessary information doesn't exist.
                    return "";
            }
        }

        /// <summary>Build session information log body.</summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Session information for log body.</returns>
        private static string BodySessionDetail(SessionData abatabSession)
        {
            var sessionHead = $"{Environment.NewLine}" +
                              $"==============={Environment.NewLine}" +
                              $"Session details{Environment.NewLine}" +
                              $"===============";

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

        private static string BodyModuleDetail(SessionData abatabSession, string modName)
        {
            var moduleHead = $"{Environment.NewLine}" +
                             $"-------------{Environment.NewLine}" +
                             $"{modName}{Environment.NewLine}" +
                             $"-------------{Environment.NewLine}";

            string moduleDetail;

            switch (modName.ToLower())
            {
                case "quickmedorder":
                    moduleDetail = $"Mode:                 {abatabSession.ModQuickMedOrderMode}{Environment.NewLine}" +
                                   $"Test users:           {abatabSession.ModQuickMedOrderTesters}{Environment.NewLine}" +
                                   $"Max percent increase: {abatabSession.ModQuickMedOrderDosePercentMaxInc}";
                    break;

                case "prototype":
                    moduleDetail = $"Mode: {abatabSession.ModPrototypeMode}";
                    break;

                case "testing":
                    moduleDetail = $"Mode: {abatabSession.ModTestingMode}";
                    break;

                default:
                    moduleDetail = $"Undefined.";
                    break;
            }

            return $"{moduleHead}" +
                   $"{moduleDetail}";
        }

        /// <summary><param name="thisOptObj">OptionObject2015 object to get information for.</param>
        /// <returns>Details of an OptionObject.</returns>
        private static string BodyModQuickMedOrderDetail(SessionData abatabSession)
        {
            var modQuickMedOrderHead = $"{Environment.NewLine}" +
                                       $"====================={Environment.NewLine}" +
                                       $"QuickMedOrder details{Environment.NewLine}" +
                                       $"====================";

            var modQuickMedOrderDetail = $"{Environment.NewLine}" +
                                         $"OrderType field ID:                {abatabSession.ModQuickMedOrderData.OrderTypeFieldId}{Environment.NewLine}" +
                                         $"Found OrderType field ID:          {abatabSession.ModQuickMedOrderData.FoundOrderTypeFieldId}{Environment.NewLine}" +
                                         $"OrderType:                         {abatabSession.ModQuickMedOrderData.OrderType}{Environment.NewLine}" +
                                         $"LastOrderScheduled field ID:       {abatabSession.ModQuickMedOrderData.LastOrderScheduleFieldId}{Environment.NewLine}" +
                                         $"Found LastOrderScheduled field ID: {abatabSession.ModQuickMedOrderData.FoundLastOrderScheduleFieldId}{Environment.NewLine}" +
                                         $"LastOrderScheduled text:           {abatabSession.ModQuickMedOrderData.LastOrderScheduleText}{Environment.NewLine}" +
                                         $"DosageOne field ID:                {abatabSession.ModQuickMedOrderData.DosageOneFieldId}{Environment.NewLine}" +
                                         $"Found DosageOne field ID:          {abatabSession.ModQuickMedOrderData.FoundDosageOneFieldId}{Environment.NewLine}" +
                                         $"CurrentDose:                       {abatabSession.ModQuickMedOrderData.CurrentDose}{Environment.NewLine}" +
                                         $"Found all required fields:         {abatabSession.ModQuickMedOrderData.FoundAllRequiredFieldIds}{Environment.NewLine}";

            return $"{modQuickMedOrderHead}" +
                   $"{modQuickMedOrderDetail}";
        }

        /// <summary><param name="thisOptObj">OptionObject2015 object to get information for.</param>
        /// <returns>Details of an OptionObject.</returns>
        private static string BodyOptObjDetail(OptionObject2015 thisOptObj, string optObjType)
        {
            var optObjHead = $"{Environment.NewLine}" +
                             $"------------{Environment.NewLine}" +
                             $"{optObjType}{Environment.NewLine}" +
                             $"------------{Environment.NewLine}";

            var optObjDetail = $"EntityID:          {thisOptObj.EntityID}{Environment.NewLine}" +
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
                   $"{optObjDetail}";
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