// Abatab.Flightpath.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Session;
using Abatab.Core.Utilities;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public static class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, AbSession abSession, Dictionary<string, string> webConfigContent)
        {




            Build.NewSession(sentOptionObject, scriptParameter, abSession, webConfigContent);
            //Core.DataExport.SessionInformation.ToSessionRoot(abSession);
            if (!Directory.Exists(abSession.SessionDataRoot))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                Refresh.Daily(abSession);
            }

            if (!Directory.Exists(abSession.SessionDataDirectory))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                Directory.CreateDirectory(abSession.SessionDataDirectory);
            }

            Roundhouse.ParseModule(abSession);
        }
    }
}