// Abatab.Roundhouse.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab
{
    /// <summary>
    /// Determines what should be done with the <b>module</b> component of the Script Parameter.
    /// </summary>
    public static class Roundhouse
    {
        /// <include file='Documentation/Abatab.xmldoc' path='XMLDoc/Class[@name="Roundhouse.cs"]/ParseModule/*' />
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    Module.Testing.Roundhouse.ParseCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    Module.ProgressNote.Roundhouse.ParseCommand(abSession);

                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    // TODO - Exit gracefully.

                    break;
            }
        }
    }
}