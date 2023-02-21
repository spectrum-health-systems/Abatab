// Abatab.AbatabOptionObject.Verify.cs b230217.1002
// Copyright (c) A Pretty Cool Program

// NOT USED.

using ScriptLinkStandard.Objects;

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