// Abatab.Flightpath.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.IO;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Logger;
using Abatab.Core.Session;
using Abatab.Core.Utilities;
using ScriptLinkStandard.Objects;

namespace Abatab
{
    public static class Flightpath
    {
        public static void Starter(OptionObject2015 sentOptionObject, string scriptParameter, AbSession abSession)
        {
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            WebConfig.Load(abSession);

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            Build.NewSession(sentOptionObject, scriptParameter, abSession);

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            if (!Directory.Exists(abSession.SessionDataRoot))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                Refresh.Daily(abSession);
            }

            Roundhouse.ParseModule(abSession);
        }

        public static void Finisher(AbSession abSession)
        {
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
            Core.DataExport.SessionInformation.ToSessionRoot(abSession);
        }
    }
}