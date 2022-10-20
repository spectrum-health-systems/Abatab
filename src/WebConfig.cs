// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.093428

using Abatab.Properties;
using AbatabLogging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
        /// <remarks>
        /// If a setting is added/removed/modified in Web.config, it needs to be reflected here.
        /// </remarks>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        public static Dictionary<string, string> Load()
        {
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG]");
            // Can't really put a trace log here.

            var webConfig =  new Dictionary<string, string>
            {
                { "DebugMode",                         Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                      Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",                        Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",                        Settings.Default.AbatabRoot.ToLower() },
                { "LogMode",                       Settings.Default.LogMode.ToLower() },
                { "LogDetail",                     Settings.Default.LogDetail.ToLower() },
                { "LoggingDelay",                      Settings.Default.LogWriteDelayDetail.ToLower() },
                { "AvatarFallbackUserName",            Settings.Default.AvatarFallbackUserName.ToLower() },
                { "ModQuickMedOrderMode",              Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidUsers",        Settings.Default.ModQuickMedOrderValidUsers.ToLower() },
                { "ModQuickMedOrderDosePercentMaxInc", Settings.Default.ModQuickMedOrderDosePercentMaxIncrease.ToLower() },
                { "ModPrototypeMode",                  Settings.Default.ModPrototypeMode.ToLower() },
                { "ModTestingMode",                    Settings.Default.ModTestingMode.ToLower() }
            };

            if (webConfig["DebugMode"] == "on")
            {
                WebConfigDebug(webConfig);
            }

            return webConfig;

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="webConfig"></param>
        private static void WebConfigDebug(Dictionary<string, string> webConfig)
        {
            DebugglerEvent.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG]");

            var webConfigContents = $"webConfig contents{Environment.NewLine}";

            foreach (var item in webConfig)
            {
                webConfigContents += $"{item.Key} = {item.Value}{Environment.NewLine}";
            }

            File.WriteAllText($@"{webConfig["DebugLogRoot"]}\webConfig.debug", webConfigContents);
        }
    }
}