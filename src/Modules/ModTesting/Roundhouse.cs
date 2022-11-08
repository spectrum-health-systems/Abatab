// Abatab ModTesting 22.11.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221108.134404

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModTesting
{
    /// <summary>
    /// Roundhouse logic for the Testing module.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Parse the Abatab request command.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ParseRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabCommand)
            {
                case "datadump":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ParseCommandDataDump(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Do a data dump.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseCommandDataDump(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabAction)
            {
                case "sessiondata":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    AbatabOptionObject.FinalObj.Finalize(abatabSession);
                    DataDump.SessionData(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}