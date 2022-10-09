/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSession.csproj                                                                             v0.91.0
 * Instance.cs                                                                               b221009.090325
 * --------------------------------------------------------------------------------------------------------
 * Logic for Abatab sessions.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AbatabSession
{
    public class Instance
    {
        /// <summary>Build configuration settings for an Abatab session.</summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Abatab request to be executed.</param>
        /// <returns>Session configuration settings.</returns>
        //public static SessionData Build(OptionObject2015 sentOptObj, string abatabRequest)
        public static SessionData Build(OptionObject2015 sentOptObj, string abatabRequest, Dictionary<string, string> abatabSettings)
        {
            LogDebug.DebugContent(abatabSettings["DebugMode"], "[DEBUG] Building session data.", abatabSettings["DebugLogRoot"], Assembly.GetExecutingAssembly().GetName().Name);

            LogDebug.DebugContent(abatabSettings["DebugMode"], sentOptObj.EpisodeNumber.ToString(), abatabSettings["DebugLogRoot"], Assembly.GetExecutingAssembly().GetName().Name);


            var abatabSession = new SessionData
            {
                AbatabVer              = Assembly.GetEntryAssembly().GetName().Version.ToString(),
                AbatabMode             = abatabSettings["AbatabMode"],
                AbatabRoot             = abatabSettings["AbatabRoot"],
                DebugMode              = abatabSettings["DebugMode"],
                DebugLogRoot           = abatabSettings["DebugLogRoot"],
                LoggingMode            = abatabSettings["LoggingMode"],
                LoggingDetail          = abatabSettings["LoggingDetail"],
                LoggingDelay           = abatabSettings["LoggingDelay"],
                AvatarFallbackUserName = abatabSettings["AvatarFallbackUserName"],
                SessionTimestamp       = $"{DateTime.Now:yyMMdd}",
                SessionLogRoot         = "",
                AbatabRequest          = abatabRequest.ToLower(),
                AbatabModule           = "undefined",
                AbatabCommand          = "undefined",
                AbatabAction           = "undefined",
                AbatabOption           = "undefined",
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = new OptionObject2015(),
                FinalOptObj            = new OptionObject2015()
            };

            abatabSession.SessionLogRoot = $@"{abatabSession.AbatabRoot}\logs\{abatabSession.SessionTimestamp}\{abatabSession.AvatarUserName}";

            AbatabSystem.Maintenance.VerifyDir(abatabSession.SessionLogRoot);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            ParseAbatabRequest(abatabSession);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            return abatabSession;
        }

        /// <summary>Verify the session AvatarUserName is valid.</summary>
        /// <param name="avatarUserName"></param>
        /// <param name="avatarFallbackUserName"></param>
        /// <returns>Session object with verified AvatarUserName</returns>
        private static string VerifyAvatarUserName(string avatarUserName, string avatarFallbackUserName)
        {
            return string.IsNullOrWhiteSpace(avatarUserName)
                ? avatarFallbackUserName
                : avatarUserName;
        }

        /// <summary>Parse the abatabRequest into separate components.</summary>
        /// <param name="abatabSession"></param>
        private static void ParseAbatabRequest(SessionData abatabSession)
        {
            string[] req = abatabSession.AbatabRequest.Split('-');

            abatabSession.AbatabModule  = req[0].ToLower();
            abatabSession.AbatabCommand = req[1].ToLower();
            abatabSession.AbatabAction  = req[2].ToLower();

            if (req.Length == 4)
            {
                abatabSession.AbatabOption = req[3].ToLower();
            }
        }
    }
}