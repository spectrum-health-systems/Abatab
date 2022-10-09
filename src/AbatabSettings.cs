/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.91.0
 * Abatab.csproj                                                                                    v0.91.0
 * AbatabSettings.cs                                                                         b221006.073240
 * ================================ (c) 2016-2022 A Pretty Cool Program ================================ */

/* Logic to work with the local configuration settings found in Web.config. Whenever a setting is added or
 * removed from Web.config, it needs to be added/removed here. If this class is modified, the entire
 * solution will need to be rebuilt.
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
    public class AbatabSettings
    {
        /// <summary>Build the abatabSession object</summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="abatabRequest"></param>
        /// <returns>Completed abatabSession object.</returns>
        public static SessionData BuildSettings(OptionObject2015 sentOptionObject, string abatabRequest)
        {
            LogDebug.Debugger(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Building Abatab session settings.");

            Dictionary<string, string> abatabSettings = AbatabSettings.LoadFromWebConfig();

            return Instance.Build(sentOptionObject, abatabRequest, abatabSettings);
        }

        /// <summary>Load local configuration settings from Web.config.</summary>
        /// <returns>Local configuration settings.</returns>
        private static Dictionary<string, string> LoadFromWebConfig()
        {
            LogDebug.Debugger(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Loading configuration settings from Web.config.");

            return new Dictionary<string, string>
            {
                { "DebugMode",              Properties.Settings.Default.DebugMode.ToLower() },
                { "DebugLogRoot",           Properties.Settings.Default.DebugLogRoot.ToLower() },
                { "AbatabMode",             Properties.Settings.Default.AbatabMode.ToLower() },
                { "AbatabRoot",             Properties.Settings.Default.AbatabRoot.ToLower() },
                { "LoggingMode",            Properties.Settings.Default.LoggingMode.ToLower() },
                { "LoggingDetail",          Properties.Settings.Default.LoggingDetail.ToLower() },
                { "LoggingDelay",           Properties.Settings.Default.LoggingDelay.ToLower() },
                { "AvatarFallbackUserName", Properties.Settings.Default.AvatarFallbackUserName.ToLower() },
                { "ModuleDateMode",         Properties.Settings.Default.ModuleDateMode.ToLower() },
                { "ModuleDoseMode",         Properties.Settings.Default.ModuleDoseMode.ToLower() },
                { "ModuleTestingMode",      Properties.Settings.Default.ModuleTestingMode.ToLower() }
            };
        }
    }
}