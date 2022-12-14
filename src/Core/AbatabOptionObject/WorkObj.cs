// Abatab.AbatabOptionObject.WorkObj.cs b230112.1247
// Copyright (c) A Pretty Cool Program

using AbatabData;

using AbatabLogging;

using NTST.ScriptLinkService.Objects;

using System.Reflection;

namespace AbatabOptionObject
{
    /// <summary>Logic for working with the WorkOptObj.</summary>
    public static class WorkObj
    {
        /// <summary>
        /// Builds the WorkOptObj.
        /// </summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        public static OptionObject2015 Build(OptionObject2015 sentOptObj)
        {
            // TODO Add logging functionality to this method.

            /* Eventually we may want to do something more complex when building the workOptObj, but for
             * now this doesn't really do anything.
             */
            return sentOptObj;
        }

        /// <summary>Clears the error information in the WorkOptObj.</summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        /// <param name="errCode">The error code.</param>
        /// <param name="errMsg">The error message.</param>
        public static void ClearErrorData(Session abatabSession, int errCode = 0, string errMsg = "")
        {
            LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.DebugMode, abatabSession.DebugglerConfig.DebugEventRoot, "[DEBUG]");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");

            abatabSession.WorkOptObj.ErrorCode = errCode;
            abatabSession.WorkOptObj.ErrorMesg = errMsg;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, "[TRACE]");
        }
    }
}