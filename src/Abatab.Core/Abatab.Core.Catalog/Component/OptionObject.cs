// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

/* DEVNOTE: The strings that these methods return use Markdown syntax, which creates a carriage return when a line ends
 * with two blank characters:
 *
 *  $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                              ^^
 * Removing the blank characters will break the Markdown output.
 */

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Cues for OptionObjects.</summary>
    public static class OptionObject
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string SentObject(AbSession abSession) =>
            $"### SentOptionObject{Environment.NewLine}" +
            $"```{abSession.SentOptionObject.ToJson()}```  {Environment.NewLine}";

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string ReturnObject(AbSession abSession) =>
            $"### ReturnOptionObject{Environment.NewLine}" +
            $"```{abSession.ReturnOptionObject.ToJson()}```  {Environment.NewLine}";
    }
}