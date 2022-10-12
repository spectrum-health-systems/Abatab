﻿// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using Abatab.Properties;
using AbatabData;
using AbatabLogging;
using AbatabSession;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    /// <summary></summary>
    public class FlightPath
    {
        /// <summary></summary>
        public static void End(Session abatabSession)
        {
            LogEvent.Session(abatabSession, "Session complete.");

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary></summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        public static Session Start(OptionObject2015 sentOptionObject, string scriptParameter)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Session started.");

            List<Dictionary<string, string>> settingsCollection = new List<Dictionary<string, string>>
            {
               WebConfig.Load(),
               AbatabSettings.Runtime.GetSettings(),
               AbatabSettings.FromAvatar.GetSettings(sentOptionObject, scriptParameter)
            };

            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Session started.");

            Dictionary<string, string> abatabSettings = Du.WithDictionary.JoinListOf(settingsCollection);

            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Session started.");

            return Create.New(sentOptionObject, scriptParameter, abatabSettings);
        }
    }
}