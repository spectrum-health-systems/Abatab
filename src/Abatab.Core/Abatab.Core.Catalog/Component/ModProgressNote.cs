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
using Abatab.Core.Utility;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Cues for the Progress Note module.</summary>
    public static class ModProgressNote
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string Detail(AbSession abSession) =>
            $"### Progress Note Module{Environment.NewLine}" +
            $"**Mode:** {abSession.ModProgNote.Mode}  {Environment.NewLine}" +
            $"**Authorized users:** {abSession.ModProgNote.Users}  {Environment.NewLine}" +
            $"**Service Charge Code FieldId:** {abSession.ModProgNote.ServiceChargeCodeFieldId}  {Environment.NewLine}" +
            $"**Service Charge Code prefixes:** {ConvertCollection.ListToString(abSession.ModProgNote.FlaggedServiceChargeCodePrefixes)}  {Environment.NewLine}" +
            $"**Service Charge Code codes:** {ConvertCollection.ListToString(abSession.ModProgNote.FlaggedServiceChargeCodeCodes)}  {Environment.NewLine}" +
            $"**Location FieldId:** {abSession.ModProgNote.LocationFieldId}  {Environment.NewLine}" +
            $"**Valid location codes:** {ConvertCollection.ListToString(abSession.ModProgNote.ValidLocationCodes)}  {Environment.NewLine}" +
            $"**Valid location names:** {ConvertCollection.ListToString(abSession.ModProgNote.ValidLocationNames)}  {Environment.NewLine}";

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Catalog.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static string VfyLocMessage(AbSession abSession, string logType) =>
            $"# [{logType}] Progress Note >+ Verify Location{Environment.NewLine}" +
            $"{Detail(abSession)}{Environment.NewLine}" +
            $"# {logType} information{Environment.NewLine}" +
            $"Error Code: `{abSession.ReturnOptionObject.ErrorCode}`<br>{Environment.NewLine}" +
            $"Error Message:  {Environment.NewLine}" +
            $"```{abSession.ReturnOptionObject.ErrorMesg}```";
    }
}