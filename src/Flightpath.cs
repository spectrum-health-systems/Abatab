// Abatab.Flightpath.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.IO;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Session;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public static class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, Dictionary<string, string> webConfigContent)
        {
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = Build.NewSession(sentOptionObject, scriptParameter, webConfigContent);

            if (!Directory.Exists(abSession.SessionDataRoot))
            {
                Refresh.Daily(abSession);
            }

            if (!Directory.Exists(abSession.SessionDataDirectory))
            {
                Directory.CreateDirectory(abSession.SessionDataDirectory);
            }

            Roundhouse.ParseModule(abSession);
        }
    }
}