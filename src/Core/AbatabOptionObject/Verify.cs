// AbatabOptionObject 22.11.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221108.081135

// NOT USED.

using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    /// <summary>
    /// Verification for OptionObjects
    /// </summary>
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