﻿// Abatab ModTesting 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221228.0852

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModTesting
{
    /// <summary>
    /// Logic for the Testing module.
    /// </summary>
    public static class DataDump
    {
        /// <summary>
        /// Create a data dump for this session.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>

        public static void SessionData(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
            LogEvent.Session(abatabSession, "Testing data dump functionality.");
        }
    }
}