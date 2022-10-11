/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * AbatabOptionObject.csproj                                                                        v0.92.0
 * Verify.cs                                                                                 b221011.093856
 * --------------------------------------------------------------------------------------------------------
 * Verify an OptionObject.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

// Used?

using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    public static class Verify
    {
        /// <summary>Verify that the sentOptObj has not been modified.</summary>
        /// <param name="sentOptObj"></param>
        /// <param name="altOptObj"></param>
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 altOptObj)
        {
            return altOptObj == sentOptObj;
        }
    }
}