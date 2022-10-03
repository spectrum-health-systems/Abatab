/* ========================================================================================================
 * Abatab v0.90.1
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabSession v0.90.1
 * AbatabSession.Instance.cs b221003.075515
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabSession.md
 * ===================================================================================================== */

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
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
            var abatabRequestComponents = ParseAbatabRequest(abatabRequest);

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
                AbatabModule           = abatabRequestComponents["Module"],
                AbatabCommand          = abatabRequestComponents["Command"],
                AbatabAction           = abatabRequestComponents["Action"],
                AbatabOption           = abatabRequestComponents["Option"],
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };

            abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRoot}\logs\{DateTime.Now:yyMMdd}\{abatabSession.AvatarUserName}";

            VerifySessionLogDir(abatabSession.SessionLogDirectory);

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        /// <summary>
        /// Parse the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ParseAbatabRequest(string abatabRequest)
        {
            string[] requestComponents = abatabRequest.Split('-');

            // TODO What if a component is empty/whitespace?

            return new Dictionary<string, string>
            {
                { "Module",  requestComponents[0] },
                { "Command", requestComponents[1] },
                { "Action",  requestComponents[2] },
                { "Option",  requestComponents[3] }
            };
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