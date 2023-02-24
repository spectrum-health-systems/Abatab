// Abatab.Roundhouse.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using AbCatalog;
using AbLogger;

namespace Abatab
{
    /// <summary>Roundhouse logic for Abatab.</summary>
    public class Roundhouse
    {
        /// <summary>Parses the module component of the ScriptParameter.</summary>
        /// <param name="session"></param>
        public static void ParseModuleComponent(SessionProperties session)
        {
            LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);

            switch (session.AbatabRequest.Module)
            {
                case "testing":
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    AbatabTesting.Roundhouse.ParseCommandComponent(session);
                    break;

                default:
                    LogEvent.Trace(session, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Should probably put something here to help exit gracefully.
                    break;
            }
        }
    }
}