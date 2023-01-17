// Abatab.Roundhouse.cs b230117.0859
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

using System.Reflection;

namespace Abatab
{
    /// <summary>Determines what should be done with the <b>module</b> component of the <see href="../man/manAppendix.html#script-parameter">Script Parameter</see>.</summary>
    public static class Roundhouse
    {
        /// <summary>Parses the Script Parameter and sends valid requests to the proper destination.</summary>
        /// <param name="abatabSession">Settings and data for this session of Abatab.</param>
        /// <remarks>
        /// <list type="bullet">
        /// <item>Only parses the <b>module</b> component of the <see href="../man/manAppendix.html#script-parameter">Script Parameter</see>.</item>
        /// <item>Whenever a new Abatab Module is added, <see href="../man/manAppendix.html#script-parameter">the necessary logic</see> will need to be added here.</item>
        /// </list>
        /// </remarks>
        public static void ParseRequest(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabModule)
            {
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