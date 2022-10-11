// b221011.093856

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
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Load Web.config.");

            return new Dictionary<string, string>
            {
                { "DebugMode",                         Properties.Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                      Properties.Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",                        Properties.Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",                        Properties.Settings.Default.AbatabRoot.ToLower() },
                { "LoggingMode",                       Properties.Settings.Default.LoggingMode.ToLower() },
                { "LoggingDetail",                     Properties.Settings.Default.LoggingDetail.ToLower() },
                { "LoggingDelay",                      Properties.Settings.Default.LoggingDelay.ToLower() },
                { "AvatarFallbackUserName",            Properties.Settings.Default.AvatarFallbackUserName.ToLower() },
                { "ModQuickMedOrderMode",              Properties.Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidUsers",        Properties.Settings.Default.ModQuickMedOrderValidUsers.ToLower() },
                { "ModQuickMedOrderDosePercentMaxInc", Properties.Settings.Default.ModQuickMedOrderDosePercentMaxInc.ToLower() },
                { "ModPrototypeMode",                  Properties.Settings.Default.ModPrototypeMode.ToLower() },
                { "ModTestingMode",                    Properties.Settings.Default.ModTestingMode.ToLower() }
            };
        }
    }
}