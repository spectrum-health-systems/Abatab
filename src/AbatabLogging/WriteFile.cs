﻿/* ========================================================================================================
 * Abatab v0.8.0
 * https://github.com/spectrum-health-systems/Abatab
 * (c) 2021-2022 A Pretty Cool Program (see LICENSE file for more information)
 * --------------------------------------------------------------------------------------------------------
 * AbatabLogging v0.8.0
 * AbatabLogging.WriteFile.cs b220929.160925
 * https://github.com/spectrum-health-systems/Abatab/blob/main/doc/srcdoc/SrcDocAbatabLogging.md
 * ===================================================================================================== */

using AbatabData;
using System;
using System.IO;

namespace AbatabLogging
{
    public class WriteFile
    {
        public static void ToLocalFile(string eventType, SessionData abatabSession, string logContent)
        {
            var filePath = $@"{abatabSession.SessionLogDirectory}\{DateTime.Now.ToString("HHmmss.fffffff")}.{eventType}";

            File.WriteAllText(filePath, logContent);
        }
    }
}
