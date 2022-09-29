/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabSession v0.8.0
 * AbatabSession.Instance.cs b220929.170014
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabSession.md
 * ===================================================================================================== */

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
            var abatabSession = new SessionData
            {
                AbatabMode             = Properties.Settings.Default.AbatabMode.ToLower(),
                LogMode                = Properties.Settings.Default.LoggingMode.ToLower(),
                AbatabRootDirectory    = Properties.Settings.Default.AbatabRootDirectory,
                AvatarFallbackUserName = Properties.Settings.Default.AvatarFallbackUserName,
                DateStamp              = DateTime.Now.ToString("yyMMdd"),
                TimeStamp              = DateTime.Now.ToString("HHmmss.fffffff"),
                SessionLogDirectory    = "",
                AbatabRequest          = abatabRequest.ToLower(),
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRootDirectory}\logs\{abatabSession.DateStamp}\{abatabSession.AvatarUserName}";
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            VerifySessionLogDir(abatabSession.SessionLogDirectory);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
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