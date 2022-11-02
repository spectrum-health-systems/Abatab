// Abatab 0.96.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221102.151929

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
        /// Determines which Abatab Module should get the Command, Action, and Option components of the Script Parameter sent from Avatar.
        /// </summary>
        /// <param name="abatabSession">Settings and data for this session of Abatab.</param>
        /// <remarks>
        /// * Whenever a new Abatab Module is added, logic will need to be added here.
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
                    ModQuickMedOrderExecute(abatabSession);
                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModTesting.Roundhouse.ParseRequest(abatabSession);
                    break;

                /* Whenever a new Abatab module is created, you will need to add logic to access that module to this switch statement, using the template below.
                 */
                //case "newmodule":
                //    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                //    ModNewModule.Roundhouse.ParseRequest(abatabSession);
                //    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    // Exit gracefully.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Allow verified users to execute ModQuickMedOrder functionality.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        private static void ModQuickMedOrderExecute(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            if (ModCommon.Verify.ValidUser(abatabSession.AvatarUserName, abatabSession.ModQuickMedOrderConfig.ValidUsers))
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                ModQuickMedOrder.Roundhouse.ParseRequest(abatabSession);
            }
            else
            {
                LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                LogEvent.Access(abatabSession, "Invalid ModQuickMedOrder user.");
                AbatabOptionObject.FinalObj.Finalize(abatabSession);
            }
        }
    }
}