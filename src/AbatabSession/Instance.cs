/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabSession v0.8.0
 * AbatabSession.Instance.cs b220928.093453
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
            SessionData abatabSession = Initialize(sentOptObj, abatabRequest);

            _=VerifyAvatarUserName(abatabSession); // TODO Assume reference type, but make sure this works.

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        /// <summary>
        /// Initialize the Abatab session configuration settings.
        /// </summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request to be executed.</param>
        /// <returns></returns>
        private static SessionData Initialize(OptionObject2015 sentOptObj, string abatabRequest)
        {
            var abatabSession = new SessionData
            {
                AbatabMode             = Properties.Settings.Default.AbatabMode.ToLower(),
                LogMode                = Properties.Settings.Default.LoggingMode.ToLower(),
                AbatabRootDirectory    = Properties.Settings.Default.AbatabRootDirectory,
                AvatarFallbackUserName = Properties.Settings.Default.AvatarFallbackUserName,
                DateStamp              = DateTime.Now.ToString("yyMMdd"),
                TimeStamp              = DateTime.Now.ToString("HHmmss.fffffff"),
                AbatabRequest          = abatabRequest.ToLower(),
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };

            var dailyLogDir = $@"{abatabSession.AbatabRootDirectory}\logs\{abatabSession.DateStamp}";

            if (!Directory.Exists(dailyLogDir))
            {
                _=Directory.CreateDirectory(dailyLogDir);
            }

            return abatabSession;

        }

        /// <summary>
        /// Verify the session AvatarUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Session object with verified AvatarUserName</returns>
        private static SessionData VerifyAvatarUserName(SessionData abatabSession)
        {
            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            return abatabSession;
        }
    }
}