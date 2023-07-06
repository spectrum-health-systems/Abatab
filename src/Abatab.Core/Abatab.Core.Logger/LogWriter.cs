﻿// b230516.0855

using System;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;

namespace Abatab.Core.Logger
{
    /// <summary>Summary goes here.</summary>
    public static class LogWriter
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void WriteAlert(AbSession abSession, string assemblyName, string callPath, string callMember)
        {
            string logPath = LogPath.Alert(abSession);
            string logMsg  = LogBuilder.BuildAlert(abSession, assemblyName, callPath, callMember);
            //int writeDelay = Convert.ToInt32(abSession.LoggerDelay); // DEVNOTE: Prob don't need.

            FileIO.WriteLocal(logPath, logMsg);
            //FileIO.WriteLocal(logPath, logMsg, writeDelay); // DEVNOTE: Prob don't need.
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void WriteSession(AbSession abSession, string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath, logMsg);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void WriteSetting(AbSession abSession, string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath, logMsg);
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Logger.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void WriteTrace(AbSession abSession, string assemblyName, string logMsg, string callPath, string callMember, int callLine)
        {
            string logPath = LogPath.Trace(abSession, assemblyName, callPath, callMember, callLine);
            int writeDelay = Convert.ToInt32(abSession.LoggerDelay);

            FileIO.WriteLocal(logPath, logMsg, writeDelay);
        }


    }
}