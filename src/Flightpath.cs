// Abatab.Flightpath.cs
// b230224.1700
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using Abatab.Core.Catalog;
using Abatab.Core.Session;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContent)
        {
            SessionProperties sessionProperties = Build.NewSession(sentOptionObject, scriptParameter, webConfigContent);

            Roundhouse.ParseModule(sessionProperties);
        }
    }
}