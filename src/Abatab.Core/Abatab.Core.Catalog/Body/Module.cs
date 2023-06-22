// b230516.0855

/* DEVNOTE: The strings that these methods return use Markdown syntax, which creates a carriage return when a line ends
 * with two blank characters:
 *
 *  $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                              ^^
 * Removing the blank characters will break the Markdown output.
 */

using System;
using Abatab.Core.Catalog.Definition;

namespace Abatab.Core.Catalog.Body
{
    /// <summary>Summary goes here.</summary>
    public static class Module
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
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