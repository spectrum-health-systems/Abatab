/* ========================================================================================================
 * Abatab v0.6.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabOptionObject v0.6.0
 * AbatabOptionObject.BuildContent.cs b220928.091558
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabOptionObject.md
 * ===================================================================================================== */

using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    public static class Verify
    {
        /// <summary>
        /// Verify that the sentOptObj has not been modified.
        /// </summary>
        /// <param name="sentOptObj"></param>
        /// <param name="alternateOptObj"></param>
        /// <returns></returns>
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 alternateOptObj)
        {
            return alternateOptObj == sentOptObj;
        }
    }
}