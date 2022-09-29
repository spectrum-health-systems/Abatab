/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabData v0.8.0
 * AbatabData.SessionData.cs b220928.091558
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabData.md
 * ===================================================================================================== */

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
        public string SessionLogDirectory { get; set; }
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }
}
