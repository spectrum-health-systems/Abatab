// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221014.081633

using Abatab.Properties;
using AbatabLogging;
using System.Collections.Generic;
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
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG]");

            return new Dictionary<string, string>
            {
                { "DebugMode",                         Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                      Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",                        Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",                        Settings.Default.AbatabRoot.ToLower() },
                { "LoggingMode",                       Settings.Default.LoggingMode.ToLower() },
                { "LoggingDetail",                     Settings.Default.LoggingDetail.ToLower() },
                { "LoggingDelay",                      Settings.Default.LoggingDelay.ToLower() },
                { "AvatarFallbackUserName",            Settings.Default.AvatarFallbackUserName.ToLower() },
                { "ModQuickMedOrderMode",              Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidUsers",        Settings.Default.ModQuickMedOrderValidUsers.ToLower() },
                { "ModQuickMedOrderDosePercentMaxInc", Settings.Default.ModQuickMedOrderDosePercentMaxInc.ToLower() },
                { "ModPrototypeMode",                  Settings.Default.ModPrototypeMode.ToLower() },
                { "ModTestingMode",                    Settings.Default.ModTestingMode.ToLower() }
            };
        }
    }
}