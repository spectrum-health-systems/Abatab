/* Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 *
 * Abatab application information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AppData/AppInfo.md
 *
 * AbatabOptionObject.csproj information:
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AbatabOptionObject/ProjData/ProjInfo.md
 * https://github.com/spectrum-health-systems/Abatab/blob/main/src/AbatabOptionObject/ProjData/Sourcecode.md
 */

// b220926.160724

using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    public static class Verify
    {
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 alternateOptObj)
        {
            return alternateOptObj == sentOptObj;
        }
    }
}