// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Component.OptionObject.cs
// String values.
// b230809.1310
// -----------------------------------------------------------------------------

/* DEVNOTE
 * The strings that these methods return use Markdown syntax, which creates a
 * carriage return when a line ends with two blank characters:
 *
 *      $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                                  ^^
 * Removing the blank characters will break the Markdown output.
 */

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Component strings for OptionObjects.</summary>
    public static class OptionObject
    {
        /// <summary>Creates a detail body for the OptionObject sent from Avatar.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A detail body for the OptionObject sent from Avatar.</returns>
        public static string SentObject(AbSession abSession) =>
            $"### SentOptionObject{Environment.NewLine}" +
            $"```{abSession.SentOptionObject.ToJson()}```  {Environment.NewLine}";

        /// <summary>Creates a detail body for the OptionObject that's returned to Avatar.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A detail body for the OptionObject that's returned to Avatar.</returns>
        public static string ReturnObject(AbSession abSession) =>
            $"### ReturnOptionObject{Environment.NewLine}" +
            $"```{abSession.ReturnOptionObject.ToJson()}```  {Environment.NewLine}";
    }
}