// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.074722

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
    public static class Instance
    {
        /// <summary>
        /// Builds configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session Build(OptionObject2015 sentOptObj, string scriptParameter, Dictionary<string, string> abatabSettings)
        {
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], "[DEBUG]");
            // Can't really put a trace log here.

            //var debug_ = $"TEST:{abatabSettings["LogMode"]} - {abatabSettings["LogDetail"]} - {abatabSettings["LogWriteDelay"]}";
            var debug_ = $"TEST-- {abatabSettings["LoggingMode"]}";

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], debug_);

            var abatabSession = new Session
            {
                Mode                              = abatabSettings["AbatabMode"],
                Root                              = abatabSettings["AbatabRoot"],
                AvatarFallbackUserName = abatabSettings["AvatarFallbackUserName"],
                SessionDateStamp                  = $"{DateTime.Now:yyMMdd}",
                SessionTimeStamp                  = $"{DateTime.Now:HHmmss}",
                AbatabRequest                     = scriptParameter.ToLower(),
                AbatabModule                      = "undefined",
                AbatabCommand                     = "undefined",
                AbatabAction                      = "undefined",
                AbatabOption                      = "undefined",
                AvatarUserName                    = sentOptObj.OptionUserId,
                SentOptObj                        = sentOptObj,
                WorkOptObj                        = AbatabOptionObject.WorkObj.Build(sentOptObj),
                FinalOptObj                       = new OptionObject2015()
            };

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildDebugglerConfig(abatabSettings, abatabSession);

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildLoggingConfig(abatabSettings, abatabSession);

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildModQuickMedOrderConfig(abatabSettings, abatabSession);

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            BuildModTestingConfig(abatabSettings, abatabSession);

            abatabSession.LoggingConfig.SessionRoot = $@"{abatabSession.Root}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AvatarUserName}\{abatabSession.SessionTimeStamp}";
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            AbatabSystem.Maintenance.VerifyDir(abatabSession.LoggingConfig.SessionRoot);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            VerifyAvatarUserName(abatabSession);

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
        private static void BuildModQuickMedOrderConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModQuickMedOrderConfig = new QuickMedOrder
            {

                Mode                           = abatabSettings["ModQuickMedOrderMode"],
                ValidUsers                     = abatabSettings["ModQuickMedOrderValidUsers"],
                DosePercentMaxIncrease         = abatabSettings["ModQuickMedOrderDosePercentMaxIncrease"],
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
            abatabSession.DebugglerConfig = new Debuggler
            {
                Mode           = abatabSettings["DebugMode"],
                DebugEventRoot = abatabSettings["DebugLogRoot"],
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

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);

            var debug_ = $"TEST:{abatabSettings["LoggingMode"]} - {abatabSettings["LoggingDetail"]} - {abatabSettings["LoggingWriteDelay"]}";
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], debug_);

            abatabSession.LoggingConfig  = new Logging
            {
                Mode = abatabSettings["LoggingMode"],
                Detail = abatabSettings["LoggingDetail"],
                WriteDelay = abatabSettings["LoggingWriteDelay"],
                SessionRoot = $@"{abatabSession.Root}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AvatarUserName}\{abatabSession.SessionTimeStamp}",
                EventErrorRoot = $@"{abatabSession.Root}\logs\error",
                EventLostRoot = $@"{abatabSession.Root}\logs\lost",
                EventWarningRoot = $@"{abatabSession.Root}\logs\warning",
            };

            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            abatabSession.LoggingConfig.EventTraceRoot = $@"{abatabSession.LoggingConfig.SessionRoot}\trace";
        }

        /// <summary>
        /// Verifies the session AvatarUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void VerifyAvatarUserName(Session abatabSession)
        {
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Parses the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseAbatabRequest(Session abatabSession)
        {
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
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
//    DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
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