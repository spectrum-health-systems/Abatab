// Abatab.AbatabOptionObject.Verify.cs b230109.0859
// Copyright (c) A Pretty Cool Program

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