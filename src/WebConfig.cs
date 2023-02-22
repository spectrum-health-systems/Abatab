// Abatab.WebConfig.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using Abatab.Properties;

namespace Abatab
{
    /// <summary>Loads settings from the local Web.config file.</summary>
    public static class WebConfig
    {
        /// <summary>Load the settings from the Web.config file.</summary>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>These configuration settings are setup in <i>src/Properties/Settings.settings</i>, and modified in the Web.config file.</item>
        ///         <item>Whenever a new value is added/removed to <i>src/Properties/Settings.settings</i>, it needs to be added/removed here as well.</item>
        ///         <item>Settings are trimmed and converted to lowercase.</item>
        ///     </list>
        /// </remarks>
        public static Dictionary<string, string> Load() => new Dictionary<string, string>
        {
            { "AbatabMode",                             Settings.Default.AbatabMode.ToLower() },
            { "AbatabServiceRoot",                      Settings.Default.AbatabServiceRoot.ToLower() },
            { "AbatabDataRoot",                         Settings.Default.AbatabDataRoot.ToLower() },
            { "PublicAccessRoot",                       Settings.Default.PublicAccessRoot.ToLower() },
            { "LoggerMode",                             Settings.Default.LoggerMode.ToLower() },
            { "LoggerDelay",                            Settings.Default.LoggerDelay.ToLower() },
            { "AvatarEnvironment",                      Settings.Default.AvatarEnvironment.ToLower() },
            { "AbatabFallbackUserName",                 Settings.Default.AbatabFallbackUserName.ToLower() },
            { "ModProgressNoteMode",                    Settings.Default.ModProgressNoteMode.ToLower() },
            { "ModProgressNoteAuthorizedUsers",         Settings.Default.ModProgressNoteAuthorizedUsers.ToLower() },
            { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode.ToLower() },
            { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode.ToLower() },
            { "ModQuickMedOrderAuthorizedUsers",        Settings.Default.ModQuickMedOrderAuthorizedUsers.ToLower() },
            { "ModQuickMedOrderValidOrderTypes",        Settings.Default.ModQuickMedOrderValidOrderTypes.ToLower() },
            { "ModQuickMedOrderDosePercentBoundary",    Settings.Default.ModQuickMedOrderDosePercentBoundary.ToLower() },
            { "ModQuickMedOrderDoseMilligramsBoundary", Settings.Default.ModQuickMedOrderDoseMilligramsBoundary.ToLower() },
            { "ModTestingMode",                         Settings.Default.ModTestingMode.ToLower() }
        };
    }
}