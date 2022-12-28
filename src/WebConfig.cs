// Abatab 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221228.0852

using Abatab.Properties;
using AbatabLogging;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    /// <summary>Loads settings from the <see href="../man/manAppendix.html#configuration">Web.config</see> file.</summary>
    public static class WebConfig
    {
        /// <summary>Load the settings from the Web.config file.</summary>
        /// <returns>A dictionary containing the settings from Web.config.</returns>
        /// <remarks>
        /// <list type="bullet">
        /// <item>These <see href="../man/manAppendix.html#configuration">configuration settings</see> are setup in <i>src/Properties/Settings.settings</i>, and modified in the <see href="../man/manAppendix.html#webconfig">Web.config</see> file.</item>
        /// <item>Whenever a new value is added/removed to <i>src/Properties/Settings.settings</i>, it needs to be added/removed here as well.</item>
        /// <item>Settings are <see href="../man/manSourceCode.html#casing-and-trimming">trimmed and converted to lowercase</see>.</item>
        /// </list>
        /// </remarks>
        public static Dictionary<string, string> Load()
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, $@"{Settings.Default.AbatabDataRoot}\{Settings.Default.AvatarEnvironment}\logs", "[DEBUG]");
            // Can't really put a trace log here.

            var webConfig =  new Dictionary<string, string>
            {
                { "AbatabMode",                             Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",                             Settings.Default.AbatabRoot.ToLower() },
                { "AbatabDataRoot",                         Settings.Default.AbatabDataRoot.ToLower() },
                { "AvatarEnvironment",                      Settings.Default.AvatarEnvironment.ToLower() },
                { "DebugMode",                              Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",                           Settings.Default.DebugLogRoot.ToLower() },
                { "LogMode",                                Settings.Default.LogMode.ToLower() },
                { "LogDetail",                              Settings.Default.LogDetail.ToLower() },
                { "LogWriteDelay",                          Settings.Default.LogWriteDelay.ToLower() },
                { "AbatabFallbackUserName",                 Settings.Default.AbatabFallbackUserName.ToLower() },
                { "ModPrototypeMode",                       Settings.Default.ModPrototypeMode.ToLower() },
                { "ModQuickMedOrderMode",                   Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderValidOrderTypes",        Settings.Default.ModQuickMedOrderValidOrderTypes.ToLower() },
                { "ModQuickMedOrderAuthorizedUsers",        Settings.Default.ModQuickMedOrderAuthorizedUsers.ToLower() },
                { "ModQuickMedOrderDosePercentBoundary",    Settings.Default.ModQuickMedOrderDosePercentBoundary.ToLower() },
                { "ModQuickMedOrderDoseMilligramsBoundary", Settings.Default.ModQuickMedOrderDoseMilligramsBoundary.ToLower() },
                { "ModTestingMode",                         Settings.Default.ModTestingMode.ToLower() }
            };

            if (webConfig["DebugMode"] == "enabled")
            {
                LogEvent.WebConfigDebug(webConfig);
            }

            return webConfig;
        }
    }
}