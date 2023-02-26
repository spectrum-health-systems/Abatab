// Abatab.Roundhouse.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab
{
    public static class Roundhouse
    {
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    Module.Testing.Roundhouse.ParseCommand(abSession);
                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}