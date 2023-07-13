// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Body.Setting.cs
// String values.
// b230713.1524
// -----------------------------------------------------------------------------

/* DEVELOPER_NOTE
 * The strings that these methods return use Markdown syntax, which creates a
 * carriage return when a line ends with two blank characters:
 *
 *      $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                                  ^^
 * Removing the blank characters will break the Markdown output.
 */

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Body
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Setting
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Standard(AbSession abSession) =>
            "## Abatab settings" +
            Environment.NewLine +
            Component.Setting.Detail(abSession);

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Current(AbSession abSession) =>
            "## Current Abatab settings" +
            Environment.NewLine +
            Component.Setting.Current(abSession);
    }
}