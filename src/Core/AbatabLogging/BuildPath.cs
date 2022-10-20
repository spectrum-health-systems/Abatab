// Abatab
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221020.101121

/* ========================================================================================================
 * PLEASE READ
 * -----------
 * Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using System;
using System.IO;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for building log file paths.
    /// </summary>
    public static class BuildPath
    {
        /// <summary>Builds a log file path.</summary>
        /// <param name="eventType">The type of log to create.</param>
        /// <param name="sessionLogRoot">The session root directory.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        /// <returns>A completed log file path.</returns>
        public static string FullPath(string eventType, string sessionLogRoot, string sessionTimeStamp, string exeAssembly = "", string callPath = "", string callMember = "", int callLine = 0)
        {
            // No log statement here (see comments at top of file)

            var timeStamp = $"{DateTime.Now:HHmmss.fffffff}";

            var fullPath = sessionLogRoot;

            AbatabSystem.Maintenance.VerifyDir(fullPath);

            switch (eventType)
            {
                case "debug":
                    AbatabSystem.Maintenance.VerifyDir($@"{fullPath}\debug");
                    fullPath += $@"\debug\{timeStamp}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debug";
                    File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\test.txt", fullPath);
                    break;

                case "quickmedorder":
                    fullPath += $@"\{timeStamp}.quickmedorder";
                    break;

                case "session":
                    fullPath += $@"\{timeStamp}.session";
                    break;

                case "trace":
                    AbatabSystem.Maintenance.VerifyDir($@"{fullPath}\trace");
                    fullPath += $@"\trace\{timeStamp}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.trace";
                    File.WriteAllText(@"C:\AvatoolWebService\Abatab_UAT\logs\test.txt", fullPath);
                    break;

                default:
                    AbatabSystem.Maintenance.VerifyDir($@"{fullPath}\lost");
                    fullPath += $@"\lost\{timeStamp}.lost";
                    File.WriteAllText($@"C:\AvatoolWebService\Abatab_UAT\logs\{timeStamp}.lost", fullPath);
                    break;
            }

            //AbatabSystem.Maintenance.VerifyDir(fullPath);

            //if (eventType != "session")
            //{
            //    fullPath += $@"\{eventType}";
            //    AbatabSystem.Maintenance.VerifyDir(fullPath);
            //}


            //fullPath += $@"\{DateTime.Now:HHmmss.fffffff}";

            //if (!string.IsNullOrWhiteSpace(exeAssembly))
            //{
            //    fullPath += $"-{exeAssembly}";
            //}

            //if (!string.IsNullOrWhiteSpace(callPath))
            //{
            //    fullPath += $"-{Path.GetFileName(callPath)}-{callMember}-{callLine}";
            //}

            return fullPath;

            //return $"{fullPath}.{eventType}";
        }
    }
}