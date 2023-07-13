// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Body.Module.cs
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
    public static class Module
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Standard(AbSession abSession) =>
            "## Modules" +
            Environment.NewLine +
            Component.ModProgressNote.Detail(abSession) +
            Environment.NewLine +
            Component.ModPrototype.Detail(abSession) +
            Environment.NewLine +
            Component.ModQuickMedicationOrder.Detail(abSession) +
            Environment.NewLine +
            Component.ModTesting.Detail(abSession) +
            Environment.NewLine;
    }
}