// Abatab.Flightpath.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Reflection;
using AbatabCatalog.Dossier;
using AbatabSession;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Handles the flow of logic for Abatab.</summary>
    public static class Flightpath
    {
        /// <summary>TBD</summary>
        /// <param name="sentOptObj"></param>
        /// <param name="scriptParam"></param>
        /// <param name="webConfig"></param>
        public static void Starter(OptionObject2015 sentOptObj, string scriptParam, Dictionary<string, string> webConfig)
        {
            SessionDetail session = Build.NewSession(sentOptObj, scriptParam, webConfig);

            AbatabLogger.LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}