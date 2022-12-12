// Abatab 23.0.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221212.0810

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    ///   <para>
    ///     Roundhouse classes determine what should be done with the Script Parameter sent from Avatar. This
    ///     particular Roundhouse class determines what should be done with the Module component.
    ///   </para>
    ///   <para>
    ///     For example, <c>QuickMedOrder-Dose-VerifyAmount</c> would be sent to the Roundhouse class of the
    ///     ModQuickMedOrder module, where it would be processed further.
    ///   </para>
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Determines which Abatab Module should get the Command-Action-Option components of the Script Parameter sent from Avatar.
        /// </summary>
        /// <param name="abatabSession">Settings and data for this session of Abatab.</param>
        /// <remarks>
        /// * The only component of the Script Parameter sent from Avatar that matters at this point is the AbatabMethod component.
        /// * Whenever a new Abatab Module is added, logic will need to be added to the switch statement using the following template:
        /// <code>
        /// case "%newmodule-name%":
        ///     LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        ///     ModNewModule.Roundhouse.ParseRequest(abatabSession);
        ///     break;
        /// </code>
        /// </remarks>
        public static void ParseRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabModule)
            {
                //case "progressnote":
                //    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                //    ModProgressNote.Roundhouse.ParseRequest(abatabSession);
                //    break;

                case "prototype":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ModPrototype.Roundhouse.ParseRequest(abatabSession);
                    break;

                case "quickmedorder":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

                    if (ModCommon.VerifyAccess.CheckIfValidUser(abatabSession.AbatabUserName, abatabSession.ModQuickMedOrderConfig.AuthorizedUsers))
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