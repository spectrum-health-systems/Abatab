﻿/* Abatab.AbatabSettings.cs 0.92.0+221011.093856
 * https://github.com/spectrum-health-systems/Abatab
 * (c)2016-2022 A Pretty Cool Program
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocHome.md
 */

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
        /// <summary>Build settings object</summary>
        /// <param name="sentOptObj">OptionObject2015 sent from myAvatar.</param>
        /// <param name="abatabRequest">Script parameter sent from Avatar.</param>
        /// <returns>Completed settings object.</returns>
        public static SessionData Build(OptionObject2015 sentOptObj, string abatabRequest)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Building Abatab session settings.");
            // No LogEvent.Trace()

            Dictionary<string, string> abatabSettings = AbatabSettings.LoadWebConfig();

            // No LogEvent.Trace()
            return Instance.Build(sentOptObj, abatabRequest, abatabSettings);
        }

        /// <summary>Load settings from Web.config.</summary>
        /// <returns>Web.config settings.</returns>
        private static Dictionary<string, string> LoadWebConfig()
        {
            // Debugger.BuildDebugLog() here instead of a LogEvent.Trace().
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Loading configuration settings from Web.config.");

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