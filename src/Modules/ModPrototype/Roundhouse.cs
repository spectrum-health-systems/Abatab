// Abatab.ModPrototype.Roundhouse.cs b230112.1247
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

using System.Reflection;

namespace ModPrototype
{
    /// <summary>Roundhouse logic for the Prototyping module.</summary>
    public class Roundhouse
    {
        /// <summary>Parse the Abatab request command.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ParseRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabCommand.ToLower())
            {
                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}