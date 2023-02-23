﻿// Abatab.WebConfig.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using Abatab.Properties;

namespace Abatab
{
    /// <summary>Logic for working with the Web.config file.</summary>
    public static class WebConfig
    {
        /// <summary>Load the settings from the local Web.config file.</summary>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>These configuration settings are setup in <i>src/Properties/Settings.settings</i>, and modified in the Web.config file.</item>
        ///         <item>Whenever a new value is added/removed to <i>src/Properties/Settings.settings</i>, it needs to be added/removed here as well.</item>
        ///     </list>
        /// </remarks>
        public static Dictionary<string, string> Load()
        {
            /* For testing/debugging only */
            //LogEvent.Primeval(@"C:\AbatabData\Testing\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);

            return new Dictionary<string, string>()
            {
                { "AbatabMode",                             Settings.Default.AbatabMode },
                { "AbatabServiceRoot",                      Settings.Default.AbatabServiceRoot },
                { "AbatabDataRoot",                         Settings.Default.AbatabDataRoot },
                { "PublicAccessRoot",                       Settings.Default.PublicAccessRoot },
                { "LoggerMode",                             Settings.Default.LoggerMode },
                { "LoggerDelay",                            Settings.Default.LoggerDelay },
                { "AvatarEnvironment",                      Settings.Default.AvatarEnvironment },
                { "AbatabFallbackUserName",                 Settings.Default.AbatabFallbackUserName },
                { "ModProgressNoteMode",                    Settings.Default.ModProgressNoteMode },
                { "ModProgressNoteAuthorizedUsers",         Settings.Default.ModProgressNoteAuthorizedUsers },
                { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode },
                { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode },
                { "ModQuickMedOrderAuthorizedUsers",        Settings.Default.ModQuickMedOrderAuthorizedUsers  },
                { "ModQuickMedOrderValidOrderTypes",        Settings.Default.ModQuickMedOrderValidOrderTypes },
                { "ModQuickMedOrderDosePercentBoundary",    Settings.Default.ModQuickMedOrderDosePercentBoundary },
                { "ModQuickMedOrderDoseMilligramsBoundary", Settings.Default.ModQuickMedOrderDoseMilligramsBoundary },
                { "TestingMode",                            Settings.Default.TestingMode },
                { "DebugMode",                              Settings.Default.DebugMode }
            };
        }
    }
}