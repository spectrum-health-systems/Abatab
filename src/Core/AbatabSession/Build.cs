// Abatab.AbatabSession.Build.cs b230215.1301
// Copyright (c) A Pretty Cool Program

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
    /// <summary>Logic for session instances.</summary>
    public static class Build
    {
        /// <summary>Builds configuration settings for an Abatab session.</summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session NewSession(OptionObject2015 sentOptObj, string scriptParameter, Dictionary<string, string> webConfig)
        {
            // TODO - put the following line back?
            //LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], "[DEBUG]");
            // Can't really put a trace log here.

            // TODO - Verify this order matches other orders

            var abatabSession = new Session
            {
                AbatabMode             = webConfig["AbatabMode"],
                AvatarEnvironment      = webConfig["AvatarEnvironment"],
                AbatabRoot             = $@"{webConfig["AbatabRoot"]}{webConfig["AvatarEnvironment"]}",
                AbatabDataRoot         = $@"{webConfig["AbatabDataRoot"]}\{webConfig["AvatarEnvironment"]}",
                PublicAccessRoot       = webConfig["PublicAccessRoot"],
                AbatabFallbackUserName = webConfig["AbatabFallbackUserName"],
                SessionDateStamp       = $"{DateTime.Now:yyMMdd}",
                SessionTimeStamp       = $"{DateTime.Now:HHmmss}",
                ScriptParameter        = scriptParameter.ToLower(),
                AbatabModule           = "undefined",
                AbatabCommand          = "undefined",
                AbatabAction           = "undefined",
                AbatabOption           = "undefined",
                AbatabUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = AbatabOptionObject.WorkObj.Build(sentOptObj),
                FinalOptObj            = new OptionObject2015()
            };

            // TODO - Are all these debug logs necessary?

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildDebugglerConfig(webConfig, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildLoggingConfig(webConfig, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildModQuickMedOrderConfig(webConfig, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildModTestingConfig(webConfig, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildModPrototypeConfig(webConfig, abatabSession);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, webConfig["DebugMode"], webConfig["DebugLogRoot"]);
            BuildModProgressNoteConfig(webConfig, abatabSession);

            abatabSession.LoggingConfig.SessionRoot = $@"{abatabSession.AbatabDataRoot}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AbatabUserName}\{abatabSession.SessionTimeStamp}";
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            AbatabSystem.Maintenance.VerifyDir(abatabSession.LoggingConfig.SessionRoot);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            VerifyAbatabUserName(abatabSession);

            ParseAbatabRequest(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            return abatabSession;
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModTestingConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModTestingConfig = new Testing
            {
                Mode = abatabSettings["ModTestingMode"],
            };
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModPrototypeConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModPrototypeConfig = new Prototype
            {
                Mode = abatabSettings["ModPrototypeMode"],
            };
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModQuickMedOrderConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModQuickMedOrderConfig = new QuickMedOrder
            {
                Mode                           = abatabSettings["ModQuickMedOrderMode"],
                AuthorizedUsers                = abatabSettings["ModQuickMedOrderAuthorizedUsers"],
                DosePercentBoundary            = abatabSettings["ModQuickMedOrderDosePercentBoundary"],
                DoseMilligramsBoundary         = abatabSettings["ModQuickMedOrderDoseMilligramsBoundary"],
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

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildModProgressNoteConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.ModProgressNoteConfig = new ProgressNote
            {
                Mode             = abatabSettings["ModProgressNoteMode"],
                AuthorizedUsers  = abatabSettings["ModProgressNoteAuthorizedUsers"],
                TelehealthConfig = new Telehealth()
                {
                    ValidServiceChargeCodes = new List<string>
                    {
                        "TMH90853",
                        "AOTMH90853"
                    },
                    ServiceChargeCodeFieldId ="51001",
                    ValidLocations = new List<string>
                    {
                         "Telehealth Patient Home",
                         "Telehealth Patient Loc Not Home"
                    },
                    LocationFieldId ="50004",

                }
            };
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildDebugglerConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            abatabSession.DebugglerConfig = new AbatabData.Core.Debuggler
            {
                DebugMode           = abatabSettings["DebugMode"],
                DebugEventRoot = $@"{abatabSession.AbatabRoot}\{abatabSettings["DebugLogRoot"]}",
            };
        }

        /// <summary>TBD</summary>
        /// <param name="abatabSettings"></param>
        /// <param name="abatabSession"></param>
        private static void BuildLoggingConfig(Dictionary<string, string> abatabSettings, Session abatabSession)
        {
            // TODO - is the following still the case?
            /* For some reason, if the log settings are called "Log*" (e.g., "LogMode"), Abatab crashes. For now I am leaving the log settings as "Logging*".
             */

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);


            // TODO - verify all of this
            abatabSession.LoggingConfig  = new Logging
            {
                LoggingMode      = $"{abatabSettings["LogMode"]}",
                Detail           = $"{abatabSettings["LogDetail"]}",
                WriteDelay       = $"{abatabSettings["LogWriteDelay"]}",
                SessionRoot      = $@"{abatabSession.AbatabDataRoot}\logs\{abatabSession.SessionDateStamp}\{abatabSession.AbatabUserName}\{abatabSession.SessionTimeStamp}",
                EventErrorRoot   = $@"{abatabSession.AbatabRoot}\logs\error",
                EventLostRoot    = $@"{abatabSession.AbatabRoot}\logs\lost",
                EventWarningRoot = $@"{abatabSession.PublicAccessRoot}\warnings",
            };

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"]);
            abatabSession.LoggingConfig.EventTraceRoot = $@"{abatabSession.LoggingConfig.SessionRoot}\trace";
        }

        /// <summary>Verifies the session AbatabUserName is valid.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void VerifyAbatabUserName(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (string.IsNullOrWhiteSpace(abatabSession.AbatabUserName))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                abatabSession.AbatabUserName = abatabSession.AbatabFallbackUserName;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>Parses the abatabRequest into separate components.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseAbatabRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            string[] req = abatabSession.ScriptParameter.Split('-');

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