/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * v0.0.1.0-devbuild+220907.121935
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.Configuration.Settings.cs: Creates session configuration settings.
 * b220907.122057
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ========================================================================================================
 */

using NTST.ScriptLinkService.Objects;
using System;

namespace Abatab.Configuration
{
    public class Settings
    {
        /// <summary>
        /// Build configuration settings for this Abatab session.
        /// </summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request to be executed.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session Build(OptionObject2015 sentOptObj, string abatabRequest)
        {
            Session abatabSession = Initialize(sentOptObj, abatabRequest);
            // Assume reference type
            _=Verify(abatabSession);

            return abatabSession;
        }

        /// <summary>
        /// Initialize the Abatab session configuration settings.
        /// </summary>
        /// <param name="sentOptionObject">OptionObject2015 sent from myAvatar.</param>
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
        /// Verify the Abatab session configuration settings.
        /// </summary>
        /// <param name="abatabSession"></param>
        /// <returns></returns>
        private static Session Verify(Session abatabSession)
        {
            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            return abatabSession;
        }
    }
}