// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogContent.cs
// Class summary goes here.
// b230810.1131
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using System.IO;

namespace Abatab.Core.Logger
{
    /// <summary>Creates log file content.</summary>
    public static class LogContent
    {
        /// <summary>Create alert log content</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName").</param>
        /// <returns>Content for an alert log.</returns>
        public static string Alert(AbSession abSession, string callPath)
        {
            switch (Path.GetFileName(callPath))
            {
                case "VerifyLocation.cs":
                    return Catalog.Component.ModProgressNote.VfyLocMessage(abSession, "Alert");

                default:
                    return "Invalid";
            }
        }
    }
}