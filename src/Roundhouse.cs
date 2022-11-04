// Abatab 0.96.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221103.213722

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Determines what should be done with the Module component of the Script Parameter sent from Avatar.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Determines which Abatab Module should get the Command/Action/Option components of the Script Parameter sent from Avatar.
        /// </summary>
        /// <param name="abatabSession">Settings and data for this session of Abatab.</param>
        /// <remarks>
        /// * Whenever a new Abatab Module is added, logic will need to be added to the switch statement using the following template:
        /// <code>
        /// case "newmodule":
        ///     LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        ///     ModNewModule.Roundhouse.ParseRequest(abatabSession);
        ///   break;
        /// </code>
        /// </remarks>
        public static void ParseRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabModule)
            {
                case "prototype":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModPrototype.Roundhouse.ParseRequest(abatabSession);
                    break;

                case "quickmedorder":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    if (ModCommon.VerifyAccess.CheckIfValidUser(abatabSession.AbatabUserName, abatabSession.ModQuickMedOrderConfig.ValidUsers))
                    {
                        ModQuickMedOrder.Roundhouse.ParseRequest(abatabSession);
                    }
                    else
                    {
                        ModCommon.VerifyAccess.InvalidUser(abatabSession);
                    }

                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModTesting.Roundhouse.ParseRequest(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // TODO Exit gracefully.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}