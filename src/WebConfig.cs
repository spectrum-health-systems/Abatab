// Abatab.WebConfig.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using Abatab.Properties;
using AbatabLogger;

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
        ///         <item>Settings are trimmed.</item>
        ///     </list>
        /// </remarks>
        public static Dictionary<string, string> Load()
        {
            LogEvent.Primeval(@"C:\AbatabData\primeval.log6", $"Hi");

            var test = new Dictionary<string, string>()
            {
                { "AbatabMode",                             Settings.Default.AbatabMode.Trim() },
                { "AbatabServiceRoot",                      Settings.Default.AbatabServiceRoot.Trim() },
                { "AbatabDataRoot",                         Settings.Default.AbatabDataRoot.Trim() },
                { "PublicAccessRoot",                       Settings.Default.PublicAccessRoot.Trim() },
                { "LoggerMode",                             Settings.Default.LoggerMode.Trim() },
                { "LoggerDelay",                            Settings.Default.LoggerDelay.Trim() },
                { "AvatarEnvironment",                      Settings.Default.AvatarEnvironment.Trim() },
                { "AbatabFallbackUserName",                 Settings.Default.AbatabFallbackUserName.Trim() },
                { "ModProgressNoteMode",                    Settings.Default.ModProgressNoteMode.Trim() },
                { "ModProgressNoteAuthorizedUsers",         Settings.Default.ModProgressNoteAuthorizedUsers.Trim() },
                { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode.Trim() },
                { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode.Trim() },
                { "ModQuickMedOrderAuthorizedUsers",        Settings.Default.ModQuickMedOrderAuthorizedUsers.Trim()  },
                { "ModQuickMedOrderValidOrderTypes",        Settings.Default.ModQuickMedOrderValidOrderTypes.Trim() },
                { "ModQuickMedOrderDosePercentBoundary",    Settings.Default.ModQuickMedOrderDosePercentBoundary.Trim() },
                { "ModQuickMedOrderDoseMilligramsBoundary", Settings.Default.ModQuickMedOrderDoseMilligramsBoundary.Trim() },
                { "ModTestingMode",                         Settings.Default.ModTestingMode.Trim() }
            };

            return test;
        }
    }
}