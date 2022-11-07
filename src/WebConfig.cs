// Abatab 0.97.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221107.095059

using Abatab.Properties;
using AbatabLogging;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Logic for working with the local Web.config file, which contains local settings for an Abatab session.
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// Load the settings from the local Web.config file.
        /// </summary>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        /// <remarks>
        /// * Whenever a new value is added/removed to Properties/Settings.settings, it needs to be added/removed here as well.
        /// * Settings are trimmed and converted to lowercase <see href="https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/Variables.html#casing-and-trimming">[more info]</see>
        /// </remarks>
        public static Dictionary<string, string> Load()
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG]");
            // Can't really put a trace log here.

            var webConfig =  new Dictionary<string, string>
            {
                { "AbatabMode",                             Settings.Default.AbatabMode.ToLower() },
                { "AbatabEnvironment",                      Settings.Default.AbatabEnvironment.ToLower() },
                { "AbatabRoot",                             Settings.Default.AbatabRoot.ToLower() },
                { "DebugMode",                              Settings.Default.DebugMode.ToLower() },
                { "DebugDebugValidUsers",                   Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                           Settings.Default.DebugLogRoot.ToLower() },
                { "LogMode",                                Settings.Default.LogMode.ToLower() },
                { "LogDetail",                              Settings.Default.LogDetail.ToLower() },
                { "LogWriteDelay",                          Settings.Default.LogWriteDelay.ToLower() },
                { "AbatabFallbackUserName",                 Settings.Default.AbatabFallbackUserName.ToLower() },
                { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode.ToLower() },
                { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidUsers",             Settings.Default.ModQuickMedOrderValidUsers.ToLower() },
                { "ModQuickMedOrderDoseMaxPercentIncrease", Settings.Default.ModQuickMedOrderDoseMaxPercentIncrease.ToLower() },
                { "ModTestingMode",                         Settings.Default.ModTestingMode.ToLower() }
            };

            if (webConfig["DebugMode"] == "on")
            {
                LogEvent.WebConfigDebug(webConfig);
            }

            return webConfig;
        }
    }
}