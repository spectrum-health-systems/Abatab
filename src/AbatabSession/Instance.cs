﻿/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSession.csproj                                                                             v0.91.0
 * Instance.cs                                                                               b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.IO;
using System.Reflection;

namespace AbatabSession
{
    public class Instance
    {
        /// <summary>
        /// Build configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Abatab request to be executed.</param>
        /// <returns>Session configuration settings.</returns>
        public static SessionData Build(OptionObject2015 sentOptObj, string abatabRequest)
        {
            if (string.Equals(Properties.Settings.Default.DebugMode, "on", StringComparison.OrdinalIgnoreCase))
            {
                LogEvent.DebugModule(Assembly.GetExecutingAssembly().GetName().Name, Properties.Settings.Default.DebugLogDir, "Instance.cs.");
            }

            //var abatabRequestComponents = ParseAbatabRequest(abatabRequest);

            var abatabSession = new SessionData
            {
                AbatabMode             = Properties.Settings.Default.AbatabMode.ToLower(),
                DebugMode              = Properties.Settings.Default.DebugMode.ToLower(),
                AbatabRoot             = Properties.Settings.Default.AbatabRoot.ToLower(),
                LoggingMode            = Properties.Settings.Default.LoggingMode.ToLower(),
                LoggingDetails         = Properties.Settings.Default.LoggingDetail.ToLower(),
                AvatarFallbackUserName = Properties.Settings.Default.AvatarFallbackUserName.ToLower(),
                SessionLogDirectory    = "",
                AbatabRequest          = abatabRequest.ToLower(),
                AbatabModule           = "undefined",
                AbatabCommand          = "undefined",
                AbatabAction           = "undefined",
                AbatabOption           = "undefined",
                //AbatabModule           = abatabRequestComponents["Module"],
                //AbatabCommand          = abatabRequestComponents["Command"],
                //AbatabAction           = abatabRequestComponents["Action"],
                //AbatabOption           = abatabRequestComponents["Option"],
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };

            abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRoot}\logs\{DateTime.Now:yyMMdd}\{abatabSession.AvatarUserName}";

            VerifySessionLogDir(abatabSession.SessionLogDirectory);

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            ParseAbatabRequest(abatabSession);

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            //abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            //abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRoot}\logs\{DateTime.Now:yyMMdd}\{abatabSession.AvatarUserName}";

            //VerifySessionLogDir(abatabSession.SessionLogDirectory);

            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        /// <summary>
        /// Parse the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static void ParseAbatabRequest(SessionData abatabSession)
        {
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            string[] req = abatabSession.AbatabRequest.Split('-');

            abatabSession.AbatabModule = req[0].ToLower();
            abatabSession.AbatabCommand = req[1].ToLower();
            abatabSession.AbatabAction = req[2].ToLower();

            if (req.Length == 4)
            {
                abatabSession.AbatabOption = req[3].ToLower();
            }

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
        }

        /// <summary>
        /// Verify the session log directory exists.
        /// </summary>
        /// <param name="sessionLogDirectory"></param>
        private static void VerifySessionLogDir(string sessionLogDirectory)
        {
            if (!Directory.Exists(sessionLogDirectory))
            {
                _=Directory.CreateDirectory(sessionLogDirectory);
            }
        }

        /// <summary>
        /// Verify the session AvatarUserName is valid.
        /// </summary>
        /// <param name="avatarUserName"></param>
        /// <param name="avatarFallbackUserName"></param>
        /// <returns>Session object with verified AvatarUserName</returns>
        private static string VerifyAvatarUserName(string avatarUserName, string avatarFallbackUserName)
        {
            return string.IsNullOrWhiteSpace(avatarUserName)
                ? avatarFallbackUserName
                : avatarUserName;
        }
    }
}