﻿/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * AbatabOptionObject.csproj                                                                        v0.91.0
 * Verify.cs                                                                                 b221003.130759
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

// NOTE Probably depreciated, or put someplace else

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