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

namespace Abatab.Core.Catalog.Output
{
    /// <summary>Summary goes here.</summary>
    public static class Setting
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Current(AbSession abSession) =>
            "# Current Abatab Settings" +
            Environment.NewLine +
            Body.Setting.Current(abSession);
    }
}