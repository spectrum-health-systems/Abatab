// Abatab.Flightpath.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Reflection;
using AbatabCatalog.Dossier;
using AbatabLogger;
using AbatabSession;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Handles the flow of logic for Abatab.</summary>
    public static class Flightpath
    {
        /// <summary>TBD</summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="scriptParameter"></param>
        /// <param name="webConfig"></param>
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfig)
        {
            SessionDetail session = Build.NewSession(sentOptionObject, scriptParameter, webConfig);

            LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}