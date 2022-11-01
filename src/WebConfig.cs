// Abatab 0.96.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221101.093903

using Abatab.Properties;
using AbatabLogging;
using System.Collections.Generic;

namespace Abatab
{
    /// <summary>
    /// Logic for working with Web.config.
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// Load the settings from Web.config.
        /// </summary>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        public static Dictionary<string, string> Load()
        {
            //?LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG]");
            // Can't really put a trace log here.

            var webConfig =  new Dictionary<string, string>
            {
                { "DebugMode",                              Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                           Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",                             Settings.Default.AbatabMode.ToLower() },
                { "AbatabEnvironment",                      Settings.Default.AbatabEnvironment.ToLower() },
                { "AbatabRoot",                             Settings.Default.AbatabRoot.ToLower() },
                { "LogMode",                                Settings.Default.LogMode.ToLower() },
                { "LogDetail",                              Settings.Default.LogDetail.ToLower() },
                { "LogWriteDelay",                          Settings.Default.LogWriteDelayDetail.ToLower() },
                { "AvatarFallbackUserName",                 Settings.Default.AvatarFallbackUserName.ToLower() },
                { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidUsers",             Settings.Default.ModQuickMedOrderValidUsers.ToLower() },
                { "ModQuickMedOrderDoseMaxPercentIncrease", Settings.Default.ModQuickMedOrderDoseMaxPercentIncrease.ToLower() },
                { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode.ToLower() },
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