/* Abatab.AbatabData.SessionData.cs
 * Project: AbatabData
 * Class: SessionData.
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 *
 * AbatabData.csproj v0.4.1
 * Data object definitions for Abatab.
 *
 * AbatabData.SessionData.cs b220926.111024
 * Session data object definitions.
 *
/* For more information about this source code, please see:
 *   https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * *******************************************************************************************************/


/* ********************************************************************************************************
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 *
 * AbatabData.csproj v0.4.1
 * Data object definitions for Abatab.
 *
 * AbatabData.SessionData.cs b220926.111024
 * Session data object definitions.
 *
/* For more information about this source code, please see:
 *   https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * *******************************************************************************************************/








/* =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- APPLICATION -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= */

/* ================================================ PROJECT ===============================================
 * AbatabData.csproj v0.4.1
 * Data object definitions for Abatab.
 * ===================================================================================================== */

/* ------------------------------------------------- CLASS ------------------------------------------------
 * AbatabData.SessionData.cs b220926.111024
 * Entry point for Abatab, and primarily focuses on the processing the initial ScriptLink call from
 * myAvatar™. This class should remain fairly static and rely external source code to do the heavy lifting.
 *
 * For more information about this source code, please see:
 *   https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ----------------------------------------------------------------------------------------------------- */



/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.asmx.cs: Entry point for Abatab.
 * b220926.111024
 * ===================================================================================================== */



/* ========================================================================================================
 * AbatabData.SessionData.cs: Session object properties.
 * b220926.113408
 * ===================================================================================================== */

/* NOTE For more information about this source code, please see:
 *          https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 */


/* INFO This class is the entry point for Abatab, and primarily focuses on the processing the initial
 *      ScriptLink call from myAvatar™. As such, it should remain fairly static and allow external
 *      projects/classes to do the heavy lifting.
 */



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
