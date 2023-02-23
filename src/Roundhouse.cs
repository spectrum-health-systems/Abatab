// Abatab.Roundhouse.cs bxxxxxx.xxxx
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using AbatabLogger;

namespace Abatab
{
    /// <summary>Roundhouse logic for Abatab.</summary>
    public class Roundhouse
    {
        /// <summary>Parses the module component of the ScriptParameter.</summary>
        /// <param name="sessionDetails"></param>
        public static void ParseModuleComponent(Detail sessionDetails)
        {
            LogEvent.Trace(sessionDetails, Assembly.GetExecutingAssembly().GetName().Name);

            switch (sessionDetails.AbatabRequest.Module)
            {
                case "testing":
                    LogEvent.Trace(sessionDetails, Assembly.GetExecutingAssembly().GetName().Name);
                    AbatabTesting.Roundhouse.ParseCommandComponent(sessionDetails);
                    break;

                default:
                    LogEvent.Trace(sessionDetails, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Should probably put something here to help exit gracefully.
                    break;
            }
        }
    }
}