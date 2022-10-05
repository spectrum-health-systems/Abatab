/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSession.csproj                                                                             v0.91.0
 * Instance.cs                                                                               b221005.090329
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using AbatabSession.Properties;
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
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

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
                AvatarUserName         = sentOptObj.OptionUserId,
                SentOptObj             = sentOptObj,
                WorkOptObj             = sentOptObj,
                FinalOptObj            = sentOptObj,
            };

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            abatabSession.AvatarUserName = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            VerifySessionLogDir(abatabSession);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            ParseAbatabRequest(abatabSession);
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            return abatabSession;
        }

        /// <summary>
        /// Parse the abatabRequest into separate components.
        /// </summary>
        /// <param name="abatabRequest"></param>
        /// <returns></returns>
        private static void ParseAbatabRequest(SessionData abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir, abatabSession.AbatabRequest);
            //LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

            string[] req = abatabSession.AbatabRequest.Split('-');

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            abatabSession.AbatabModule  = req[0].ToLower();
            abatabSession.AbatabCommand = req[1].ToLower();
            abatabSession.AbatabAction  = req[2].ToLower();

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);

            if (req.Length == 4)
            {
                LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);
                abatabSession.AbatabOption = req[3].ToLower();
            }

            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogDir);
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
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
        /// Verify the session log directory exists.
        /// </summary>
        /// <param name="sessionLogDirectory"></param>
        private static void VerifySessionLogDir(SessionData abatabSession)
        {
            //abatabSession.AvatarUserName      = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);
            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRoot}\logs\{DateTime.Now:yyMMdd}\{abatabSession.AvatarUserName}";

            if (!Directory.Exists(abatabSession.SessionLogDirectory))
            {
                _=Directory.CreateDirectory(abatabSession.SessionLogDirectory);
            }
        }
    }
}