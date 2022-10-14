﻿// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221014.111420

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModPrototype
{
    /// <summary>
    /// Roundhouse logic for the Prototyping module.
    /// </summary>
    public class Roundhouse
    {
        /// <summary>
        /// Parse the Abatab request command.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ParseRequest(Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing QuickMedOrder Module command.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabCommand.ToLower())
            {
                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}