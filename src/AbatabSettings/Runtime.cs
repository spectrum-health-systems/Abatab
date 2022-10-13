// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221013.091642

using AbatabLogging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace AbatabSettings
{
    /// <summary></summary>
    public class Runtime
    {
        /// <summary></summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSettings(string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            List<Dictionary<string, string>> runtimeSettings = new List<Dictionary<string, string>>
            {
                GetAbatabDetails(debugMode, debugLogRoot),
                GetSessionDetails(debugMode, debugLogRoot)
            };

            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return Du.WithDictionary.JoinListOf(runtimeSettings);
        }

        /// <summary></summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAbatabDetails(string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return new Dictionary<string, string>
            {
                { "AbatabVer",   FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion }
            };
        }

        /// <summary></summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSessionDetails(string debugMode, string debugLogRoot)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, debugMode, debugLogRoot, "[DEBUG]");

            return new Dictionary<string, string>
            {
                { "SessionDate", $"{DateTime.Now:yyMMdd}" }
            };
        }
    }
}
