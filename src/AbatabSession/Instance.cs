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
        public static SessionData Build(Dictionary<string, string> webConfigSettings, OptionObject2015 sentOptObj, string abatabRequest)
        {

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\A.txt", "none");

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

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\b.txt", "none");

            abatabSession.AvatarUserName      = VerifyAvatarUserName(abatabSession.AvatarUserName, abatabSession.AvatarFallbackUserName);

            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\c.txt", "none");
            //abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRootDirectory}\logs\{DateTime.Now.ToString("yyMMdd")}\{abatabSession.AvatarUserName}";
            abatabSession.SessionLogDirectory = $@"{abatabSession.AbatabRootDirectory}\logs\12345\test";
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\d.txt", "none");
            VerifySessionLogDir(abatabSession.SessionLogDirectory);
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\e.txt", "none");
            LogEvent.Trace(Assembly.GetExecutingAssembly().GetName().Name, abatabSession);
            File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\12345\test\f.txt", "none");
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