/* ========================================================================================================
 * Abatab.Configuration.Settings.cs: Creates session configuration settings.
 * b220912.112816
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using NTST.ScriptLinkService.Objects;
using System;

namespace Abatab.Configuration
{
    public class Settings
    {
        /// <summary>
        /// Build configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Abatab request to be executed.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session Build(OptionObject2015 sentOptObj, string abatabRequest)
        {
            Session abatabSession = Initialize(sentOptObj, abatabRequest);

            /* We need to verify components of the Abatab session configuration setting before continuing.
             */
            _=VerifyAvatarUserName(abatabSession); // TODO Assume reference type, but make sure this works.

            return abatabSession;
        }

        /// <summary>
        /// Initialize the Abatab session configuration settings.
        /// </summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request to be executed.</param>
        /// <returns></returns>
        private static Session Initialize(OptionObject2015 sentOptObj, string abatabRequest)
        {
            return new Session
            {
                AbatabMode             = Properties.Settings.Default.AbatabMode.ToLower(),
                LogMode                = Properties.Settings.Default.LogMode.ToLower(),
                AbatabRootDirectory    = Properties.Settings.Default.AbatabRootDirectory,
                AvatarFallbackUserName = Properties.Settings.Default.AvatarFallbackUserName,
                DateStamp              = DateTime.Now.ToString("yyMMdd"),
                TimeStamp              = DateTime.Now.ToString($"HHmmss.fffffff"),
                AbatabRequest          = abatabRequest.ToLower(),
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkerOptObj           = sentOptObj,
                FinalOptObj            = sentOptObj,
            };
        }

        /// <summary>
        /// Verify the session AvatarUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Abatab session configuration settings.</param>
        /// <returns>Session object with verified AvatarUserName</returns>
        private static Session VerifyAvatarUserName(Session abatabSession)
        {
            /* The AvatarUserName is used to keep track of various session information, such as logs. If
             * sentOptionObject.OptionUserId is blank, we will force it to be the AvatarFallbackUserName
             * defined in the local configuration settings file.
             */
            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            return abatabSession;
        }
    }
}