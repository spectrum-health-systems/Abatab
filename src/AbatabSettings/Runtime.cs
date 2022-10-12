using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace AbatabSettings
{
    public class Runtime
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSettings()
        {
            List<Dictionary<string, string>> runtimeSettings = new List<Dictionary<string, string>>
            {
                GetAbatabDetails(),
                GetSessionDetails()
            };

            return Du.WithDictionary.JoinListOf(runtimeSettings);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAbatabDetails()
        {
            return new Dictionary<string, string>
            {
                { "AbatabVer",   FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion }
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSessionDetails()
        {
            return new Dictionary<string, string>
            {
                { "SessionDate", $"{DateTime.Now:yyMMdd}" }
            };
        }
    }
}
