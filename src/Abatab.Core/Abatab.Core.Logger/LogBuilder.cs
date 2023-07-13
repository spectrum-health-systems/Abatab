// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogBuilder.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Logger
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    internal static class LogBuilder
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string BuildAlert(AbSession abSession, string assemblyName, string callPath, string callMember)
        {
            switch (assemblyName)
            {
                case "Abatab.Module.ProgressNote":
                    return LogContent.Alert(abSession, callPath);

                default:
                    return "INVALID";
            }
        }
    }
}