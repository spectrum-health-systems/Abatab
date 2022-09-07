/* ========================================================================================================
 * Abatab: A custom web service for Netsmart's myAvatar™ EHR.
 * v0.0.1.0-devbuild+220907.121935
 * https://github.com/spectrum-health-systems/Abatab
 * Copyright (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * Abatab.Logging.LogEvent.cs: Logs an Abatab event.
 * b220907.122057
 * https://github.com/spectrum-health-systems/Abatab/blob/main/Documentation/Sourcecode/Sourcecode.md
 * ========================================================================================================
 */

using System.Runtime.CompilerServices;

namespace Abatab.Logging
{
    public class LogEvent
    {
        public static void Trace(string assemblyName, Session abatabSession, string logMessage = "No log message", [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            BuildContent.Message("trace", assemblyName, abatabSession, logMessage, callerFilePath, callerMemberName, callerLine);
        }


    }
}