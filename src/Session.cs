/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * v0.0.1.0-devbuild+220907.121935
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.Session.cs: Session object properties
 * b220907.122057
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ========================================================================================================
 */

using NTST.ScriptLinkService.Objects;

namespace Abatab
{
    public class Session
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