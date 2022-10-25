// Abatab 0.95.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221025.075904

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Roundhouse functionality for Abatab.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Determines where a script parameter request should go.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
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
                    ExecuteQuickMedOrder(abatabSession);
                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModTesting.Roundhouse.ParseRequest(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Exit gracefully.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        private static void ExecuteQuickMedOrder(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            var validUser = ModCommon.Verify.ValidUser(abatabSession.AvatarUserName, abatabSession.ModQuickMedOrderConfig.ValidUsers);
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (validUser)
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                ModQuickMedOrder.Roundhouse.ParseRequest(abatabSession);
            }
            else
            {
                LogEvent.Access(abatabSession, "invalidUser");
                AbatabOptionObject.FinalObj.Finalize(abatabSession);
            }
        }
    }
}