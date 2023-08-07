// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab: A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// -----------------------------------------------------------------------------
// Abatab.Core.Logger.LogWriter.cs
// Class summary goes here.
// b230713.1524
// -----------------------------------------------------------------------------

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;

namespace Abatab.Core.Logger
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class LogWriter
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteAlert(AbSession abSession, string assemblyName, string callPath, string callMember)
        {
            string logPath = LogPath.Alert(abSession);
            string logMsg  = LogBuilder.BuildAlert(abSession, assemblyName, callPath, callMember);
            /* DEVELOPER_NOTE
             * Probably don't need this next line.
             */
            //int writeDelay = Convert.ToInt32(abSession.LoggerDelay);

            FileIO.WriteLocal(logPath, logMsg);
            /* DEVELOPER_NOTE
             * Probably don't need this next line.
             */
            //FileIO.WriteLocal(logPath, logMsg, writeDelay); // DEVNOTE: Prob don't need.
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteSession(AbSession abSession, string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath, logMsg);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteSetting(AbSession abSession, string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath, logMsg);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteTrace(AbSession abSession, string assemblyName, string logMsg, string callPath, string callMember, int callLine)
        {
            string logPath = LogPath.Trace(abSession, assemblyName, callPath, callMember, callLine);
            int writeDelay = Convert.ToInt32(abSession.LoggerDelay);

            FileIO.WriteLocal(logPath, logMsg, writeDelay);
        }
    }
}