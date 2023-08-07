// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Catalog.Component.Setting.cs
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

namespace Abatab.Core.Catalog.Component
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Setting
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Detail(AbSession abSession) =>
            $"**Abatab version:** {abSession.AbatabVersion}  {Environment.NewLine}" +
            $"**Abatab build:** {abSession.AbatabBuild}  {Environment.NewLine}" +
            $"**Abatab username:** {abSession.AbatabUserName}  {Environment.NewLine}" +
            $"**Date:** {abSession.Datestamp}  {Environment.NewLine}" +
            $"**Time:** {abSession.Timestamp}  {Environment.NewLine}" +
            $"**Abatab mode:** {abSession.AbatabMode}  {Environment.NewLine}" +
            $"**Avatar environment:** {abSession.AvatarEnvironment}  {Environment.NewLine}" +
            $"**Abatab fallback username:** {abSession.AbatabFallbackUserName}  {Environment.NewLine}" +
            $"**Abatab service root:** {abSession.AbatabServiceRoot}  {Environment.NewLine}" +
            $"**Abatab data root:** {abSession.AbatabDataRoot}  {Environment.NewLine}" +
            $"**Session data root:** {abSession.SessionDataDirectory}  {Environment.NewLine}" +
            $"**Trace log directory:** {abSession.TraceLogDirectory}  {Environment.NewLine}" +
            $"**Warning log directory:** {abSession.WarningLogDirectory}  {Environment.NewLine}" +
            $"**Debuggler mode:** {abSession.DebugglerMode}  {Environment.NewLine}" +
            $"**Debuggler log directory:** {abSession.DebugglerLogDirectory}  {Environment.NewLine}" +
            $"### Public data  {Environment.NewLine}" +
            $"**Public data root:** {abSession.PublicDataRoot}  {Environment.NewLine}" +
            $"**Public warning log directory:** {abSession.AlertLogDirectory}  {Environment.NewLine}" +
            $"### Logger  {Environment.NewLine}" +
            $"**Logger mode:** {abSession.LoggerMode}  {Environment.NewLine}" +
            $"**Logger types:** {abSession.LoggerTypes}  {Environment.NewLine}" +
            $"**Logger delay:** {abSession.LoggerDelay}  {Environment.NewLine}" +
            $"### Request  {Environment.NewLine}" +
            $"**Request module:** {abSession.RequestModule}  {Environment.NewLine}" +
            $"**Request command:** {abSession.RequestCommand}  {Environment.NewLine}" +
            $"**Request action:** {abSession.RequestAction}  {Environment.NewLine}" +
            $"**Request option:** {abSession.RequestOption}  {Environment.NewLine}";

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Current(AbSession abSession) =>
            $"> These settings are current as of {abSession.Datestamp}.{abSession.Timestamp} {Environment.NewLine}" +
            $"**Avatar version:** {abSession.AbatabVersion} {abSession.AbatabBuild}  {Environment.NewLine}" +
            $"**Abatab mode:** {abSession.AbatabMode}  {Environment.NewLine}" +
            $"**Avatar environment:** {abSession.AvatarEnvironment}  {Environment.NewLine}" +
            $"**Abatab fallback username:** {abSession.AbatabFallbackUserName}  {Environment.NewLine}" +
            $"**Abatab service root:** {abSession.AbatabServiceRoot}  {Environment.NewLine}" +
            $@"**Abatab data root:** {abSession.AbatabDataRoot}\  {Environment.NewLine}" +
            $"**Session data root:** {abSession.SessionDataRoot}  {Environment.NewLine}" +
            $"**Debuggler mode:** {abSession.DebugglerMode}  {Environment.NewLine}" +
            $"**Debuggler log directory:** {abSession.DebugglerLogDirectory}  {Environment.NewLine}" +
            $"## Public data  {Environment.NewLine}" +
            $"**Public data root:** {abSession.PublicDataRoot}  {Environment.NewLine}" +
            $"**Public warning log directory:** {abSession.AlertLogDirectory}  {Environment.NewLine}" +
            $"## Logger  {Environment.NewLine}" +
            $"**Logger mode:** {abSession.LoggerMode}  {Environment.NewLine}" +
            $"**Logger types:** {abSession.LoggerTypes}  {Environment.NewLine}" +
            $"**Logger delay:** {abSession.LoggerDelay}  {Environment.NewLine}";
    }
}