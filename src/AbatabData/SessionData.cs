﻿/* ========================================================================================================
 * AbatabData.SessionData.cs: Session object properties.
 * b220926.102216
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
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
        public string AvatarUserName { get; set; }
        public string AbatabRequest { get; set; }
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkerOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }
}
