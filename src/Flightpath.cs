// Abatab.Flightpath.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.Reflection;
using AbCatalog;
using AbLogger;
using AbSession;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    /// <summary>Handles the flow of logic for Abatab.</summary>
    public static class Flightpath
    {
        /// <summary>Handles the Abatab startup processes.</summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="scriptParameter"></param>
        /// <param name="webConfigContents"></param>
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContents)
        {
            if (webConfigContents["DebugMode"] == "enabled") /* For testing/debugging only */
            {
                LogEvent.Primeval(@"C:\AbatabData\Testing\", Assembly.GetExecutingAssembly().GetName().Name, scriptParameter);
            }

            SessionProperties session = Build.NewSession(sentOptionObject, scriptParameter, webConfigContents);

            Roundhouse.ParseModuleComponent(session);
        }
    }
}