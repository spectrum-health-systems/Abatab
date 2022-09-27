/* ========================================================================================================
 * Abatab v0.5.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabOptionObject.BuildContent.cs v0.5.0-development+220927.110333
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabOptionObject.md
 * ===================================================================================================== */

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