/* ========================================================================================================
 * AbatabSession.Session.cs: Session object properties.
 * b220912.112816
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Reflection;

namespace AbatabSession
{
    public class SessionData
    {
        // web.config settings.
        public string AbatabMode { get; set; }
        public string LogMode { get; set; }
        public string AbatabRootDirectory { get; set; }
        public string AvatarFallbackUserName { get; set; }

        // Runtime settings.
        public string DateStamp { get; set; }
        public string TimeStamp { get; set; }
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkerOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }


        /// <summary>
        /// Build configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Abatab request to be executed.</param>
        /// <returns>Session configuration settings.</returns>
        public static SessionData Build(OptionObject2015 sentOptObj, string abatabRequest)
        {
            SessionData abatabSession = Initialize(sentOptObj, abatabRequest);

            /* We need to verify components of the Abatab session configuration setting before continuing.
             */
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
            return new SessionData
            {
                AbatabMode             = Properties.Settings.Default.AbatabMode.ToLower(),
                LogMode                = Properties.Settings.Default.LoggingMode.ToLower(),
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
        private static SessionData VerifyAvatarUserName(SessionData abatabSession)
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