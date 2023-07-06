﻿// b230516.0855

/* DEVNOTE: The strings that these methods return use Markdown syntax, which creates a carriage return when a line ends
 * with two blank characters:
 *
 *  $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                              ^^
 * Removing the blank characters will break the Markdown output.
 */

using System;
using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Cues for the Quick Medication Order module.</summary>
    public static class ModQuickMedicationOrder
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Detail(AbSession abSession) =>
            $"### QuickMedicationOrder Module{Environment.NewLine}" +
            $"**Mode:** {abSession.ModQMedOrdr.Mode}  {Environment.NewLine}" +
            $"**Authorized users:** {abSession.ModQMedOrdr.Users}  {Environment.NewLine}" +
            $"**Valid order types:** {abSession.ModQMedOrdr.ValidOrderTypes}  {Environment.NewLine}" +
            $"**Dose percent boundry:** {abSession.ModQMedOrdr.DosePercentBoundary}  {Environment.NewLine}" +
            $"**Dose milligram boundry:** {abSession.ModQMedOrdr.DoseMilligramBoundary}  {Environment.NewLine}";
    }
}