// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221013.091642

using Abatab.Properties;
using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab
{
    public class FlightPath
    {
        public static void Start(OptionObject2015 sentOptionObject, string scriptParameter, Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, Settings.Default.DebugMode, Settings.Default.DebugLogRoot, "[DEBUG] Flightpath start.");

            List<Dictionary<string, string>> settingsCollection = new List<Dictionary<string, string>>
            {
               WebConfig.Load(),
               AbatabSettings.Runtime.GetSettings(Settings.Default.DebugMode, Settings.Default.DebugLogRoot),
               AbatabSettings.FromAvatar.GetSettings(sentOptionObject, scriptParameter, Settings.Default.DebugMode, Settings.Default.DebugLogRoot)
            };

            Dictionary<string, string> abatabSettings = Du.WithDictionary.JoinListOf(settingsCollection);

            abatabSession = AbatabSession.NewSession.Build(sentOptionObject, scriptParameter, abatabSettings);
        }
    }
}