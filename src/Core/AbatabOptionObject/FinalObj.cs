// AbatabOptionObject 22.12.0
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221130.1026

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabOptionObject
{
    /// <summary>
    /// Logic for working with the FinalOptObj.
    /// </summary>
    public static class FinalObj
    {
        /// <summary>
        /// Finalizes an OptionObject.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void Finalize(Session abatabSession)
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            switch (abatabSession.AbatabMode.ToLower())
            {
                case "normal":
                    ForUpdate(abatabSession);
                    break;

                case "passthrough":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    ForPassthrough(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Builds the FinalOptObj stuff when the Abatab mode is set to passthrough.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ForUpdate(Session abatabSession)
        {
            // TODO Private?
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.FinalOptObj.ErrorCode       = abatabSession.WorkOptObj.ErrorCode;
            abatabSession.FinalOptObj.ErrorMesg       = abatabSession.WorkOptObj.ErrorMesg;
            abatabSession.FinalOptObj.EntityID        = abatabSession.SentOptObj.EntityID;
            abatabSession.FinalOptObj.EpisodeNumber   = abatabSession.SentOptObj.EpisodeNumber;
            abatabSession.FinalOptObj.Facility        = abatabSession.SentOptObj.Facility;
            abatabSession.FinalOptObj.OptionId        = abatabSession.SentOptObj.OptionId;
            abatabSession.FinalOptObj.OptionStaffId   = abatabSession.SentOptObj.OptionStaffId;
            abatabSession.FinalOptObj.OptionUserId    = abatabSession.SentOptObj.OptionUserId;
            abatabSession.FinalOptObj.SystemCode      = abatabSession.SentOptObj.SystemCode;
            abatabSession.FinalOptObj.ServerName      = abatabSession.SentOptObj.ServerName;
            abatabSession.FinalOptObj.NamespaceName   = abatabSession.SentOptObj.NamespaceName;
            abatabSession.FinalOptObj.ParentNamespace = abatabSession.SentOptObj.ParentNamespace;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }

        /// <summary>
        /// Builds the FinalOptObj stuff when the Abatab mode is set to passthrough.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ForPassthrough(Session abatabSession)
        {
            // TODO Private?
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.FinalOptObj.ErrorCode       = 0;
            abatabSession.FinalOptObj.ErrorMesg       = "PASSTHROUGH";
            abatabSession.FinalOptObj.EntityID        = abatabSession.SentOptObj.EntityID;
            abatabSession.FinalOptObj.EpisodeNumber   = abatabSession.SentOptObj.EpisodeNumber;
            abatabSession.FinalOptObj.Facility        = abatabSession.SentOptObj.Facility;
            abatabSession.FinalOptObj.OptionId        = abatabSession.SentOptObj.OptionId;
            abatabSession.FinalOptObj.OptionStaffId   = abatabSession.SentOptObj.OptionStaffId;
            abatabSession.FinalOptObj.OptionUserId    = abatabSession.SentOptObj.OptionUserId;
            abatabSession.FinalOptObj.SystemCode      = abatabSession.SentOptObj.SystemCode;
            abatabSession.FinalOptObj.ServerName      = abatabSession.SentOptObj.ServerName;
            abatabSession.FinalOptObj.NamespaceName   = abatabSession.SentOptObj.NamespaceName;
            abatabSession.FinalOptObj.ParentNamespace = abatabSession.SentOptObj.ParentNamespace;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}