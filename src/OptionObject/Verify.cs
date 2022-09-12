/* ========================================================================================================
 * Abatab.OptionObject.Verify.cs: Verify OptionObject2015 components.
 * b220912.112534
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ===================================================================================================== */

using NTST.ScriptLinkService.Objects;

namespace Abatab.OptionObject
{
    public static class Verify
    {
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 alternateOptObj)
        {
            return alternateOptObj == sentOptObj;
        }
    }
}