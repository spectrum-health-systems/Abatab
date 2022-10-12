// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.082547

using AbatabData;
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
    public class Instance
    {
        /// <summary>
        /// Builds configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session Build(OptionObject2015 sentOptObj, string scriptParameter, Dictionary<string, string> abatabSettings)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], "[DEBUG] Building session data.");
            // No LogEvent.Trace() here because we don't have the necessary information yet.

            var abatabSession = new Session
            {
                AbatabMode                        = abatabSettings["AbatabMode"],
                AbatabRoot                        = abatabSettings["AbatabRoot"],
                DebugMode                         = abatabSettings["DebugMode"],
                DebugLogRoot                      = abatabSettings["DebugLogRoot"],
                LoggingMode                       = abatabSettings["LoggingMode"],
                LoggingDetail                     = abatabSettings["LoggingDetail"],
                LoggingDelay                      = abatabSettings["LoggingDelay"],
                AvatarFallbackUserName            = abatabSettings["AvatarFallbackUserName"],
                ModQuickMedOrderMode              = abatabSettings["ModQuickMedOrderMode"],
                ModQuickMedOrderValidUsers        = abatabSettings["ModQuickMedOrderValidUsers"],
                ModQuickMedOrderDosePercentMaxInc = abatabSettings["ModQuickMedOrderDosePercentMaxInc"],
                ModQuickMedOrderData              = new QuickMedOrder(),
                ModPrototypeMode                  = abatabSettings["ModPrototypeMode"],
                ModTestingMode                    = abatabSettings["ModTestingMode"],
                SessionTimestamp                  = $"{DateTime.Now:yyMMdd}",
                SessionLogRoot                    = "",
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

            abatabSession.SessionLogRoot = $@"{abatabSession.AbatabRoot}\logs\{abatabSession.SessionTimestamp}\{abatabSession.AvatarUserName}";
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            AbatabSystem.Maintenance.VerifyDir(abatabSession.SessionLogRoot);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            VerifyAvatarUserName(abatabSession);

            ParseAbatabRequest(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            return abatabSession;
        }

        /// <summary>
        /// Verifies the session AvatarUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void VerifyAvatarUserName(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// Parses the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseAbatabRequest(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            string[] req = abatabSession.AbatabRequest.Split('-');

            abatabSession.AbatabModule  = req[0].ToLower();
            abatabSession.AbatabCommand = req[1].ToLower();
            abatabSession.AbatabAction  = req[2].ToLower();

            if (req.Length == 4)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

                abatabSession.AbatabOption = req[3].ToLower();
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}