/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabSession.csproj                                                                             v0.91.0
 * Instance.cs                                                                               b221004.105628
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

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

            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);

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


            // NOTE If the option is missing.
            if (requestComponents.Length == 2)
            {
                requestComponents[3] = "undefined";
            }

            //foreach (var component in requestComponents)
            //{
            //    if (string.IsNullOrWhiteSpace(component))
            //    {
            //        var test = Array.IndexOf(requestComponents, component);
            //        requestComponents[test] = "undefined";
            //    }
            //}

            return new Dictionary<string, string>
            {
                { "Module",  requestComponents[0].ToLower() },
                { "Command", requestComponents[1].ToLower() },
                { "Action",  requestComponents[2].ToLower() },
                { "Option",  requestComponents[3].ToLower() }
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