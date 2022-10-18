﻿// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221018.082641

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModQuickMedOrder
{
    /// <summary>
    /// Roundhouse logic for the Quick Medication Order module.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>Parse the Abatab request command.</summary>
        /// <param name="abatabSession">Abatab session information.</param>
        public static void ParseRequest(Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabCommand.ToLower())
            {
                case "dose":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ParseCommandDose(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Parses the Dose command.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ParseCommandDose(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabAction.ToLower())
            {
                case "verifyundermaxpercentincrease":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModQuickMedOrder.Dose.VerifyUnderMaxPercentIncrease(abatabSession);
                    AbatabOptionObject.FinalObj.Finalize(abatabSession);
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