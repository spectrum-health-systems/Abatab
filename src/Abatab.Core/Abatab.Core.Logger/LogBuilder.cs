﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogBuilder.cs
// Class summary goes here.
// b230810.1112
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Logger
{
    /// <summary>Builds different types of log files.</summary>
    internal static class LogBuilder
    {
        /// <summary>Build an alert log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName")</param>
        /// <param name="callMember">The calling method (e.g., "MethodName")</param>
        /// <returns>The contents for an alert log.</returns>
        public static string BuildAlert(AbSession abSession,string assemblyName,string callPath,string callMember)
        {
            switch (assemblyName)
            {
                case "Abatab.Module.ProgressNote":
                    return LogContent.Alert(abSession,callPath);

                default:
                    return "INVALID";
            }
        }
    }
}