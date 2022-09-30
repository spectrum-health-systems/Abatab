/* ========================================================================================================
 * Abatab v0.90.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabSession v0.90.0
 * AbatabSession.Instance.cs b220930.082025
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

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\A.txt", "none");

            var webConfigSettings = GetWebConfigSettings();
            var abatabSession = new SessionData
            {
                AbatabMode             = webConfigSettings["AbatabMode"].ToLower(),
                LogMode                = webConfigSettings["LoggingMode"].ToLower(),
                AbatabRootDirectory    = webConfigSettings["AbatabRootDirectory"],
                AvatarFallbackUserName = webConfigSettings["AvatarFallbackUserName"],
                SessionLogDirectory    = "",
                AbatabRequest          = abatabRequest.ToLower(),
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };

            abatabSession.AvatarUserName      = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRootDirectory}\logs\{DateTime.Now:yyMMdd}\{abatabSession.AvatarUserName}";

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


        /// <summary>
        /// Get the settings in the weg.config file.
        /// </summary>
        /// <returns>Web.config settings.</returns>
        private static Dictionary<string, string> GetWebConfigSettings()
        {
            return new Dictionary<string, string>
            {
                { "AbatabMode" ,            Properties.Settings.Default.AbatabMode.ToLower() },
                { "LoggingMode",            Properties.Settings.Default.LoggingMode.ToLower() },
                { "AbatabRootDirectory",    Properties.Settings.Default.AbatabRoot },
                { "AvatarFallbackUserName", Properties.Settings.Default.AvatarFallbackUserName },
            };
        }
    }
}