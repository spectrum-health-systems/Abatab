// AbatabSession 0.96.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221102.151929

using AbatabData;
using AbatabData.Core;
using AbatabData.Module;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AbatabSession
{
    /// <summary>
    /// Logic for session instances.
    /// </summary>
    public static class Build
    {
        /// <summary>
        /// Builds configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session NewSession(OptionObject2015 sentOptObj, string scriptParameter, Dictionary<string, string> abatabSettings)
        {
            //?LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], "[DEBUG]");
            // Can't really put a trace log here.

            //var debug_ = $"TEST:{abatabSettings["LogMode"]} - {abatabSettings["LogDetail"]} - {abatabSettings["LogWriteDelay"]}";
            var debug_ = $"TEST-- {abatabSettings["LogMode"]}";

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], $@"{abatabSettings["AbatabRoot"]}\{abatabSettings["DebugLogRoot"]}", debug_);

            var abatabSession = new Session
            {
                Mode                   = abatabSettings["AbatabMode"],
                Env                    = abatabSettings["AbatabEnvironment"],
                Root                   = $@"{abatabSettings["AbatabRoot"]}\{abatabSettings["AbatabEnvironment"]}",
                AbatabFallbackUserName = abatabSettings["AbatabFallbackUserName"],
                SessionDateStamp       = $"{DateTime.Now:yyMMdd}",
                SessionTimeStamp       = $"{DateTime.Now:HHmmss}",
                AbatabRequest          = scriptParameter.ToLower(),
                AbatabModule           = "undefined",
                AbatabCommand          = "undefined",
                AbatabAction           = "undefined",
                AbatabOption           = "undefined",
                AbatabUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = AbatabOptionObject.WorkObj.Build(sentOptObj),
                FinalOptObj            = new OptionObject2015()
            };

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildDebugglerConfig(abatabSettings, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildLoggingConfig(abatabSettings, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildModQuickMedOrderConfig(abatabSettings, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildModTestingConfig(abatabSettings, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildModPrototypeConfig(abatabSettings, abatabSession);

            abatabSession.LoggingConfig.SessionRoot = $@"{abatabSession.Root}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AbatabUserName}\{abatabSession.SessionTimeStamp}";
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            AbatabSystem.Maintenance.VerifyDir(abatabSession.LoggingConfig.SessionRoot);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            VerifyAbatabUserName(abatabSession);

            ParseAbatabRequest(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            return abatabSession;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModTestingConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModTestingConfig = new Testing
            {
                Mode = abatabSettings["ModTestingMode"],
            };
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModPrototypeConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModPrototypeConfig = new Prototype
            {
                Mode = abatabSettings["ModPrototypeMode"],
            };
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModQuickMedOrderConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModQuickMedOrderConfig = new QuickMedOrder
            {

                Mode                           = abatabSettings["ModQuickMedOrderMode"],
                ValidUsers                     = abatabSettings["ModQuickMedOrderValidUsers"],
                DoseMaxPercentIncrease         = abatabSettings["ModQuickMedOrderDoseMaxPercentIncrease"],
                PrevDosePrefix                 = "Recurring Dosage:",
                PrevDoseSuffix                 = " mgs",
                DosageOneFieldId               = "107",
                FoundDosageOneFieldId          = false,
                CurrentDose                    = "0.0",
                OrderTypeFieldId               = "121",
                FoundOrderTypeFieldId          = false,
                OrderType                      = "0",
                LastOrderScheduleFieldId       = "142",
                FoundLastOrderScheduleFieldId  = false,
                LastOrderScheduleText          = "",
                FoundAllRequiredFieldIds       = false
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildDebugglerConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.DebugglerConfig = new AbatabData.Core.Debuggler
            {
                Mode           = abatabSettings["DebugMode"],
                DebugEventRoot = $@"{abatabSession.Root}\{abatabSettings["DebugLogRoot"]}",
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildLoggingConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            /* For some reason, if the log settings are called "Log*" (e.g., "LogMode"), Abatab crashes. For now I am leaving the log settings as "Logging*".
             */

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);

            //var debug_ = $"TEST:{abatabSettings["LogMode"]} - {abatabSettings["LogDetail"]} - {abatabSettings["LogWriteDelayDetail"]}";
            var debug_ = $"TEST:{abatabSettings["LogMode"]} - {abatabSettings["DebugLogRoot"]} - {abatabSettings["ModTestingMode"]}";

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], debug_);

            abatabSession.LoggingConfig  = new Logging
            {
                Mode             = $"{abatabSettings["LogMode"]}",
                Detail           = $"{abatabSettings["LogDetail"]}",
                WriteDelay       = $"{abatabSettings["LogWriteDelay"]}",
                SessionRoot      = $@"{abatabSession.Root}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AbatabUserName}\{abatabSession.SessionTimeStamp}",
                EventErrorRoot   = $@"{abatabSession.Root}\logs\error",
                EventLostRoot    = $@"{abatabSession.Root}\logs\lost",
                EventWarningRoot = $@"{abatabSession.Root}\logs\warning",
            };

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            abatabSession.LoggingConfig.EventTraceRoot = $@"{abatabSession.LoggingConfig.SessionRoot}\trace";
        }

        /// <summary>
        /// Verifies the session AbatabUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void VerifyAbatabUserName(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (string.IsNullOrWhiteSpace(abatabSession.AbatabUserName))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                abatabSession.AbatabUserName = abatabSession.AbatabFallbackUserName;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Parses the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseAbatabRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            string[] req = abatabSession.AbatabRequest.Split('-');

            abatabSession.AbatabModule  = req[0].ToLower();
            abatabSession.AbatabCommand = req[1].ToLower();
            abatabSession.AbatabAction  = req[2].ToLower();

            if (req.Length == 4)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                abatabSession.AbatabOption = req[3].ToLower();
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}


//private static void InitializeDoseData(Session abatabSession)
//{
//    LogEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
//    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

//    abatabSession.ModQuickMedOrderData.PrevDosePrefix                = "Recurring Dosage:";
//    abatabSession.ModQuickMedOrderData.PrevDoseSuffix                = " mgs";
//    abatabSession.ModQuickMedOrderData.DosageOneFieldId              = "107";
//    abatabSession.ModQuickMedOrderData.FoundDosageOneFieldId         = false;
//    abatabSession.ModQuickMedOrderData.CurrentDose                   = "0.0";
//    abatabSession.ModQuickMedOrderData.OrderTypeFieldId              = "121";
//    abatabSession.ModQuickMedOrderData.FoundOrderTypeFieldId         = false;
//    abatabSession.ModQuickMedOrderData.OrderType                     = "0";
//    abatabSession.ModQuickMedOrderData.LastOrderScheduleFieldId      = "142";
//    abatabSession.ModQuickMedOrderData.FoundLastOrderScheduleFieldId = false;
//    abatabSession.ModQuickMedOrderData.LastOrderScheduleText         = "";
//    abatabSession.ModQuickMedOrderData.FoundAllRequiredFieldIds      = false;

//    LogEvent.ModQuickMedOrder(abatabSession);
//    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
//}