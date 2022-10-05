/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * AbatabSettings.cs                                                                         b221005.121531
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

using Abatab.Properties;
using AbatabLogging;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    public class AbatabSettings
    {
        public static Dictionary<string, string> LoadFromWebConfig()
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Loading settings from Web.config.");

            return new Dictionary<string, string>
            {
                { "DebugMode",              Properties.Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",           Properties.Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",             Properties.Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",             Properties.Settings.Default.AbatabRoot.ToLower() },
                { "LoggingMode",            Properties.Settings.Default.LoggingMode.ToLower() },
                { "LoggingDetail",          Properties.Settings.Default.LoggingDetail.ToLower() },
                { "LoggingDelay",           Properties.Settings.Default.LoggingDelay.ToLower() },
                { "AvatarFallbackUserName", Properties.Settings.Default.AvatarFallbackUserName.ToLower() }
            };
        }
    }
}