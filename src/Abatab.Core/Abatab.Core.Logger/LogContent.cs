// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogContent.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using System.IO;

namespace Abatab.Core.Logger
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class LogContent
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
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