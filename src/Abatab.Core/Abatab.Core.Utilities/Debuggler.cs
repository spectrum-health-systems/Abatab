// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Abatab.Core.Utility
{
    /// <summary>Primeval log logic.</summary>
    public static class Debuggler
    {
        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void DebugLog(string debugglerMode, string exeAssembly, string logMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            if (debugglerMode == "enabled")
            {
                FileIO.WriteLocal($@"C:\AbatabData\Debuggler\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debuggler", logMsg, 100);
            }
        }

        /// <include file='../../Abatab/src/docs/doc/xml/inc/Abatab.Core.Utility.xmldoc' path='XMLDoc/Class[@name="ClassName"]/MethodName/*' />
        public static void PrimevalLog(string fileExtension)
        {
            FileIO.WriteLocal($@"C:\AbatabData\Primeval\{DateTime.Now:yyMMddHHmmssfffffff}_Abatab.{fileExtension}", "");
        }
    }
}