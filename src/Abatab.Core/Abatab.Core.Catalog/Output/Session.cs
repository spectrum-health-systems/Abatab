// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Output.Session.cs
// Summary goes here.
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

namespace Abatab.Core.Catalog.Output
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>

    public static class Session
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Complete(AbSession abSession) =>
            "# Abatab session" +
            Environment.NewLine +
            Body.Setting.Standard(abSession) +
            Environment.NewLine +
            Body.Module.Standard(abSession) +
            Environment.NewLine +
            Body.OptionObject.Standard(abSession);
    }
}