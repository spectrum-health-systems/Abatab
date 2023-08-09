// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Component.ModQuickMedicationOrder.cs
// String values.
// b230809.1309
// -----------------------------------------------------------------------------

/* DEVNOTE
 * The strings that these methods return use Markdown syntax, which creates a
 * carriage return when a line ends with two blank characters:
 *
 *      $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                                  ^^
 * Removing the blank characters will break the Markdown output.
 */

// REVIEW Should this be moved to Abatab.Module.QuickMedicationOrder

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Component strings for progress notes.</summary>
    public static class ModQuickMedicationOrder
    {
        /// <summary>Creates a detail body for Quick Medication Orders.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A detail body for Quick Medication Orders.</returns>
        public static string Detail(AbSession abSession) =>
            $"### QuickMedicationOrder Module{Environment.NewLine}" +
            $"**Mode:** {abSession.ModQMedOrdr.Mode}  {Environment.NewLine}" +
            $"**Authorized users:** {abSession.ModQMedOrdr.Users}  {Environment.NewLine}" +
            $"**Valid order types:** {abSession.ModQMedOrdr.ValidOrderTypes}  {Environment.NewLine}" +
            $"**Dose percent boundry:** {abSession.ModQMedOrdr.DosePercentBoundary}  {Environment.NewLine}" +
            $"**Dose milligram boundry:** {abSession.ModQMedOrdr.DoseMilligramBoundary}  {Environment.NewLine}";
    }
}