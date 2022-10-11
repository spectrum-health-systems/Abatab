/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * Abatab.csproj                                                                                    v0.92.0
 * AbatabSettings.cs                                                                         b221011.074325
 * --------------------------------------------------------------------------------------------------------
 * Logic to work with configuration settings found in the local Web.Config file.
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using Abatab.Properties;
using AbatabData;
using AbatabLogging;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    public static class AbatabSettings
    {
        /// <summary>Build the abatabSession object</summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Request from Avatar.</param>
        /// <returns>Completed abatabSession object.</returns>
        public static SessionData BuildSettings(OptionObject2015 sentOptObj, string abatabRequest)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Building Abatab session settings.");
            // No LogEvent.Trace() here because the necessary information doesn't exist.

            Dictionary<string, string> abatabSettings = AbatabSettings.LoadWebConfig();

            // No LogEvent.Trace() here because the necessary information doesn't exist.
            return Instance.Build(sentOptObj, abatabRequest, abatabSettings);
        }

        /// <summary>Load local configuration settings from Web.config.</summary>
        /// <returns>Local configuration settings.</returns>
        private static Dictionary<string, string> LoadWebConfig()
        {
            /* Since we don't have the necessary information to create trace logs yet, we'll use
             * Debugger.BuildDebugLog() here instead of a LogEvent.Trace().
             */
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Loading configuration settings from Web.config.");
            // No LogEvent.Trace() here because the necessary information doesn't exist.

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
                { "ModDateMode",                       Properties.Settings.Default.ModDateMode.ToLower() },
                { "ModQuickMedOrderMode",              Properties.Settings.Default.ModQuickMedOrderMode.ToLower() },
                { "ModQuickMedOrderPrevDosePrefix",    Properties.Settings.Default.ModQuickMedOrderPrevDosePrefix.ToLower() },
                { "ModQuickMedOrderPrevDoseSuffix",    Properties.Settings.Default.ModQuickMedOrderPrevDoseSuffix.ToLower() },
                { "ModQuickMedOrderDosePercentMaxInc", Properties.Settings.Default.ModQuickMedOrderDosePercentMaxInc.ToLower() },
                { "ModPrototypeMode",                  Properties.Settings.Default.ModPrototypeMode.ToLower() },
                { "ModTestingMode",                    Properties.Settings.Default.ModTestingMode.ToLower() }
            };
        }
    }
}