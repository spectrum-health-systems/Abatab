/* Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 *
 * Abatab application information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AppData/AppInfo.md
 *
 * AbatabData.csproj information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AbatabData/ProjData/ProjInfo.md
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AbatabData/ProjData/Sourcecode.md
 */

// b220926.160724

using NTST.ScriptLinkService.Objects;

namespace AbatabData
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
    }
}
