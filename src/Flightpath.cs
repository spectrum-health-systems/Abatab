// Abatab.Flightpath.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.IO;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public static class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, AbSession abSession)
        {
            ;
            WebConfig.Load(abSession);

            Build.NewSession(sentOptionObject, scriptParameter, abSession);

            /* This is the earliest we can put a trace log in this method
            */
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            if (!Directory.Exists(abSession.SessionDataRoot))
            {
                LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                Refresh.Daily(abSession);
            }

            Roundhouse.ParseModule(abSession);
        }

        public static void Finisher(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            Core.DataExport.SessionInformation.ToSessionRoot(abSession);
        }
    }
}